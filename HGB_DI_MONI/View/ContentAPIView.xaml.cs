using HGB_DI_MONI.domain;
using HGB_DI_MONI.service;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HGB_DI_MONI.View
{
    /// <summary>
    /// ContentAPIView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContentAPIView : UserControl
    {

        private string Xsignature = "";        
        const string endpoint = "https://api.hotelbeds.com/hotel-content-api/1.0/";
        private string fields = "hotels?fields=name%2CcountryCode%2CzoneCode%2CdestinationCode%2Ccoordinates%2CchainCode%2CaccommodationTypeCode%2Caddress%2CpostalCode%2Ccity%2Cphones%2CS2C&language=ENG&useSecondaryLanguage=false";
        private string Api_Key = "";
        //private string Sercurity_Key = "";
        

        private int from = 1;
        private int to = 1000;

        private int current_from = 0;
        private int current_to = 0;
        private int total_number = 0;

        private string apiUrl = "";
        

        MainWindow mainWindow = null;

        public ContentAPIView()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            //numberOfData = "&from=" + from + "&to=" + to;            
            apiUrl = endpoint + fields;                       
            ApiUrl_TB.Text = apiUrl;

            mainWindow = new MainWindow();
        }

        List<HotelInformation> hotelContentsList;

        private async void GetHotel_btn_Click(object sender, RoutedEventArgs e)
        {
            string status_barTxt = "";            

            hotelContentsList = new List<HotelInformation>();

            current_from = from;
            current_to = to;

            //Xsignature = XSignature_Generate();

            //Console.WriteLine(endpoint + fields + numberOfData);
            HttpConnects h_Conn = new HttpConnects(ApiUrl_TB.Text, mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

            do
            {
            
            statusBar.Content = "Please wait for a Second.... Now We are Communicating with HB API ... -> Get Hotel from " + current_from + " to " + current_to;

            RSResult rsResult = await h_Conn.GetImageContents(current_from, current_to);
            //Console.WriteLine(rsResult.result);

            if (rsResult.rq_status == true)
            {
                //RS_Json_TB.Text = rsResult.result;
                await Json_Paring(rsResult.result);

                status_barTxt = "Done: Successfully, Get Hotel from 1  to " + current_to; ;
                //popup_Txt = "Rate plan checking process has done !!"
                //MessageBox.Show("Rate plan checking process has done !!");
            }
            else
            {
                 status_barTxt = "Error: " + rsResult.result;
                 //MessageBoxResult result = MessageBox.Show(rsResult.result);
                

                break;
            }

             current_from = current_to + 1;
             current_to = current_from + 999;

             //Console.WriteLine("ZZZZZZZ : " +total_number);

            } while (total_number > current_from);

            hbHotelRoom_Grid.ItemsSource = hotelContentsList;

            statusBar.Content = status_barTxt;
            MessageBox.Show(status_barTxt);

        }

        private async Task Json_Paring(string json)
        {
            try
            {
                //total = 0;                

                //Console.WriteLine(json);

                JObject obj = JObject.Parse(json);


                if (total_number == 0)
                {                    
                    //Console.WriteLine(obj["total"].ToString());
                    total_number = int.Parse(obj["total"].ToString());
                }

                JArray hotel_hotels = JArray.Parse(obj["hotels"].ToString());
                foreach (JObject itemObj in hotel_hotels)
                {
                    HotelInformation contents = new HotelInformation();

                    contents.code = Convert.ToInt64(itemObj["code"].ToString());
                    //Console.WriteLine(contents.code);
                    contents.name = itemObj["name"]["content"].ToString();
                    contents.countryCode = itemObj["countryCode"].ToString();
                    contents.destinationCode = itemObj["destinationCode"].ToString();
                    contents.zoneCode = itemObj["zoneCode"].ToString();

                    if (itemObj.ContainsKey("coordinates") == true)
                    {
                        contents.longitude = itemObj["coordinates"]["longitude"].ToString();
                        contents.latitude = itemObj["coordinates"]["latitude"].ToString();
                    }

                    if (itemObj.ContainsKey("chainCode") == true)
                    {
                        contents.chainCode = itemObj["chainCode"].ToString();
                    }

                    contents.accommodationTypeCode = itemObj["accommodationTypeCode"].ToString();
                    contents.address = itemObj["address"]["content"].ToString();

                    if (itemObj.ContainsKey("postalCode") == true)
                    {
                        contents.postalCode = itemObj["postalCode"].ToString();
                    }

                    contents.city = itemObj["city"]["content"].ToString();

                    if (itemObj.ContainsKey("S2C") == true)
                    {
                        contents.S2C = itemObj["S2C"].ToString();
                    }

                    if (itemObj.ContainsKey("phones") == true)
                    {
                        JArray hotel_phones = JArray.Parse(itemObj["phones"].ToString());
                        foreach (JObject itemObj2 in hotel_phones)
                        {

                            if (itemObj2["phoneType"].ToString().Equals("PHONEBOOKING"))
                            {
                                //Console.WriteLine("phones");
                                contents.phoneNumber = itemObj2["phoneNumber"].ToString();
                                //Console.WriteLine(itemObj2["phoneNumber"].ToString()); 
                            }
                            //        //else if(itemObj2["phoneType"].ToString() == "PHONEHOTEL")
                            //        //{
                            //        //    contents.phoneNumber = itemObj2["phoneNumber"].ToString();
                            //        //}                           

                        }
                    }
                    hotelContentsList.Add(contents);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
       

        private async void Extract_btn_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "("+ DateTime.Now.ToShortDateString()+")HB_Active_Properties.csv";
            if (sfd.ShowDialog() == true)
            {
                filename = sfd.FileName;

                //Console.WriteLine(filename);

                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }

                //await ExportToCsv(HotelContentDGrid, filename);
                //await ToCSV(datatable, filename);

                if(hotelContentsList.Count > 0)
                {
                    statusBar.Content = "Please wait for a Second.... Now We are Making CSV File ...";
                    await CreateCSVFromGenericList(hotelContentsList, filename);
                    MessageBox.Show("Data Export has done, Please check CSV file");
                    statusBar.Content = "Done: Data Export has done, Please check CSV file";
                }
                else
                {
                    MessageBox.Show("There is no data to Extract");
                }               

             
            }
        }

        private async Task CreateCSVFromGenericList<T>(List<T> list, string csvNameWithExt)
        {
            if (list == null || list.Count == 0) return;

            //get type from 0th member
            Type t = list[0].GetType();
            string newLine = Environment.NewLine;

            using (var sw = new StreamWriter(csvNameWithExt))
            {
                //make a new instance of the class name we figured out to get its props
                object o = Activator.CreateInstance(t);
                //gets all properties
                PropertyInfo[] props = o.GetType().GetProperties();

                //foreach of the properties in class above, write out properties
                //this is the header row
                foreach (PropertyInfo pi in props)
                {
                    sw.Write(pi.Name.ToUpper() + "|");
                }
                sw.Write(newLine);

                int total_count = 0; 

                //this acts as datarow
                foreach (T item in list)
                {
                    string show_progress_txt = "";
                    //this acts as datacolumn
                    foreach (PropertyInfo pi in props)
                    {
                        
                        //this is the row+col intersection (the value)
                        string whatToWrite =
                            Convert.ToString(item.GetType()
                                                 .GetProperty(pi.Name)
                                                 .GetValue(item, null))
                                .Replace(',', ' ') + '|';

                        sw.Write(whatToWrite);
                        show_progress_txt += " " + whatToWrite;
                       // Console.WriteLine("1:" + whatToWrite);                       

                    }                    

                    sw.Write(newLine);

                    ++total_count;
                    statusBar.Content = "Please wait for a Second.... Now We have written Total "+ total_count + " data";

                }
            }
        }
    }
}
