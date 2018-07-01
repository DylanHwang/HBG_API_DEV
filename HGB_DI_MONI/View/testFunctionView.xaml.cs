using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using HGB_DI_MONI.domain;
using HGB_DI_MONI.service;
using Newtonsoft.Json.Linq;

namespace HGB_DI_MONI.View
{
    /// <summary>
    /// Interaction logic for testFunctionView.xaml
    /// </summary>
    public partial class testFunctionView : UserControl
    {
        //private string Xsignature = "";        
        const string endpoint = "https://api.hotelbeds.com/hotel-content-api/1.0/";
        //private string fields = "hotels?fields=name%2CcountryCode%2CzoneCode%2CdestinationCode%2Ccoordinates%2CchainCode%2CaccommodationTypeCode%2Caddress%2CpostalCode%2Ccity%2Cphones%2CS2C&language=ENG&useSecondaryLanguage=false";
        private string fields = "";
        private string Api_Key = "";
        //private string Sercurity_Key = "";

        private int from = 1;
        private int to = 1000;

        private int current_from = 0;
        private int current_to = 0;
        private int total_number = 0;

        ///private string apiUrl = "";


        MainWindow mainWindow = null;

        public testFunctionView()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            //numberOfData = "&from=" + from + "&to=" + to;                                             
            ApiUrl_TB.Text = endpoint;
            Extract_btn.IsEnabled = false;
            mainWindow = new MainWindow();
        }

        List<RoomDesc> HBRoomDescList;

        private async void GetRoomDescrip_btn_Click(object sender, RoutedEventArgs e)
        {

            string status_barTxt = "";

            HBRoomDescList = new List<RoomDesc>();

            from = 1;
            to = 1000;
            total_number = 0;

            current_from = from;
            current_to = to;

            string getApiUrl = ApiUrl_TB.Text + "types/rooms?fields=all&language=ENG&useSecondaryLanguage=false";

            //Console.WriteLine(getApiUrl);


            HttpConnects h_Conn = new HttpConnects(getApiUrl, mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

            do
            {

                statusBar.Content = "Please wait for a Second.... Now We are Communicating with HB API ... -> Get Hotel from " + current_from + " to " + current_to;

                RSResult rsResult = await h_Conn.GetHotelContents(current_from, current_to);
                Console.WriteLine(rsResult.result);

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

            hbHotelRoom_Grid.ItemsSource = HBRoomDescList;
            
            await CreateCSVFromGenericList(HBRoomDescList, @"..\..\CSVfiles\RoomDesc.csv");

            statusBar.Content = status_barTxt;
            MessageBox.Show(status_barTxt);
           
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
                    statusBar.Content = "Please wait for a Second.... Now We have written Total " + total_count + " data";

                }
            }
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

                JArray hotel_hotels = JArray.Parse(obj["rooms"].ToString());
                foreach (JObject itemObj in hotel_hotels)
                {
                    RoomDesc contents = new RoomDesc();

                    if (itemObj.ContainsKey("code") == true)
                    {
                        contents.room_code = itemObj["code"].ToString();
                    }

                    if (itemObj.ContainsKey("description") == true)
                    {
                        contents.room_description = itemObj["description"].ToString();
                    }

                    if (itemObj.ContainsKey("type") == true)
                    {
                        contents.room_type = itemObj["type"].ToString();
                    }

                    if (itemObj.ContainsKey("typeDescription") == true)
                    {
                        contents.room_typeDescription = itemObj["typeDescription"]["content"].ToString();
                    }

                    if (itemObj.ContainsKey("characteristic") == true)
                    {
                        contents.room_characteristic = itemObj["characteristic"].ToString();
                    }

                    if (itemObj.ContainsKey("characteristicDescription") == true)
                    {
                        contents.room_characteristicDescription = itemObj["characteristicDescription"]["content"].ToString();
                    }

                    HBRoomDescList.Add(contents);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        List<RoomImage> HBRoomImageList;
        List<RoomDesc> RoomDescMomoryDB;

        private async void GetImage_btn_Click(object sender, RoutedEventArgs e)
        {
            string status_barTxt = "";

            //여기 부서 개발 시작 2018.06.27
            RoomDescMomoryDB = File.ReadAllLines(@"..\..\CSVfiles\RoomDesc.csv")
                                     .Skip(1)
                                     .Select(v => RoomDesc.FromCsv(v))
                                     .ToList();         
            //여기 부서 개발 시작


            HBRoomImageList = new List<RoomImage>();


            from = 1;
            to = 1000;
            total_number = 0;

            current_from = from;
            current_to = to;

            string getApiUrl = ApiUrl_TB.Text + "hotels?fields=name%2CcountryCode%2CdestinationCode%2Cimages&language=ENG&useSecondaryLanguage=false";

            //Console.WriteLine(getApiUrl);


            HttpConnects h_Conn = new HttpConnects(getApiUrl, mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

            do
            {

                statusBar.Content = "Please wait for a Second.... Now We are Communicating with HB API ... -> Get Hotel from " + current_from + " to " + current_to;

                RSResult rsResult = await h_Conn.GetHotelContents(current_from, current_to);
                Console.WriteLine(rsResult.result);

                if (rsResult.rq_status == true)
                {
                    //RS_Json_TB.Text = rsResult.result;
                    await Json_Paring_Img(rsResult.result);
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

            var HBRoomImageList_Oderby = (from x in HBRoomImageList
                                          orderby x.hotel_code, x.imageOrder ascending
                                          select x).ToList();

            hbHotelRoom_Grid.ItemsSource = HBRoomImageList_Oderby;

            await CreateCSVFromGenericList(HBRoomImageList_Oderby, @"..\..\CSVfiles\HBRoomImages.csv");

            statusBar.Content = status_barTxt;
            MessageBox.Show(status_barTxt);
        }

        private async Task Json_Paring_Img(string json)
        {
            try
            {               

                JObject obj = JObject.Parse(json);

                if (total_number == 0)
                {
                    //Console.WriteLine(obj["total"].ToString());
                    total_number = int.Parse(obj["total"].ToString());
                }

                JArray hotel_hotels = JArray.Parse(obj["hotels"].ToString());
                foreach (JObject itemObj in hotel_hotels)
                {


                    if (itemObj.ContainsKey("images") == true)
                    {
                        JArray hotel_images = JArray.Parse(itemObj["images"].ToString());
                        foreach (JObject itemObj2 in hotel_images)
                        {
                            if (itemObj2["imageTypeCode"].ToString().Equals("HAB"))
                            {
                                if(itemObj2.ContainsKey("roomCode") == true)
                                {
                                    RoomImage contents = new RoomImage();

                                    contents.hotel_code = Convert.ToInt64(itemObj["code"].ToString());
                                    contents.hotel_name = itemObj["name"]["content"].ToString();
                                    contents.hotel_countryCode = itemObj["countryCode"].ToString();
                                    contents.hotel_destinationCode = itemObj["destinationCode"].ToString();
                                    contents.imageOrder = Convert.ToInt64(itemObj2["order"].ToString());
                                    contents.imageTypeCode = itemObj2["imageTypeCode"].ToString();

                                    string imageroomCode_tmp = itemObj2["roomCode"].ToString();
                                    contents.imageroomCode = imageroomCode_tmp;
                                    var linq = (from r in RoomDescMomoryDB where r.room_code == imageroomCode_tmp select new { r.room_description }).First();                                   
                                    contents.room_typeDescription = linq.room_description.ToString();

                                    contents.imagePath = itemObj2["path"].ToString();

                                    HBRoomImageList.Add(contents);

                                }
                            }
                          
                        }
                    }                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        List<CountryDesc> HBCountryDescList;

        private async void GetCountry_btn_Click(object sender, RoutedEventArgs e)
        {
            string status_barTxt = "";

            HBCountryDescList = new List<CountryDesc>();

            from = 1;
            to = 1000;
            total_number = 0;

            current_from = from;
            current_to = to;

            string getApiUrl = ApiUrl_TB.Text + "locations/countries?fields=description&language=ENG&useSecondaryLanguage=false";

            //Console.WriteLine(getApiUrl);


            HttpConnects h_Conn = new HttpConnects(getApiUrl, mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

            do
            {

                statusBar.Content = "Please wait for a Second.... Now We are Communicating with HB API ... -> Get Hotel from " + current_from + " to " + current_to;

                RSResult rsResult = await h_Conn.GetHotelContents(current_from, current_to);
                Console.WriteLine(rsResult.result);

                if (rsResult.rq_status == true)
                {
                    //RS_Json_TB.Text = rsResult.result;
                    await Json_Paring_Country(rsResult.result);
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

            hbHotelRoom_Grid.ItemsSource = HBCountryDescList;
            await CreateCSVFromGenericList(HBCountryDescList, @"..\..\CSVfiles\CountryDesc.csv");

            statusBar.Content = status_barTxt;
            MessageBox.Show(status_barTxt);
        }


        private async Task Json_Paring_Country(string json)
        {
            try
            {

                JObject obj = JObject.Parse(json);

                if (total_number == 0)
                {
                    //Console.WriteLine(obj["total"].ToString());
                    total_number = int.Parse(obj["total"].ToString());
                }

                JArray hotel_countries = JArray.Parse(obj["countries"].ToString());
                foreach (JObject itemObj in hotel_countries)
                {
                    CountryDesc contents = new CountryDesc();
                    contents.country_code = itemObj["code"].ToString();
                    contents.country_description = itemObj["description"]["content"].ToString();
                    HBCountryDescList.Add(contents);                   
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        List<DestinationDesc> HBDestinationDescList;

        private async void GetdDestination_btn_Click(object sender, RoutedEventArgs e)
        {
            string status_barTxt = "";

            HBDestinationDescList = new List<DestinationDesc>();

            from = 1;
            to = 1000;
            total_number = 0;

            current_from = from;
            current_to = to;

            string getApiUrl = ApiUrl_TB.Text + "locations/destinations?fields=all&language=ENG&useSecondaryLanguage=false";

            //Console.WriteLine(getApiUrl);


            HttpConnects h_Conn = new HttpConnects(getApiUrl, mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

            do
            {

                statusBar.Content = "Please wait for a Second.... Now We are Communicating with HB API ... -> Get Hotel from " + current_from + " to " + current_to;

                RSResult rsResult = await h_Conn.GetHotelContents(current_from, current_to);
                Console.WriteLine(rsResult.result);

                if (rsResult.rq_status == true)
                {
                    //RS_Json_TB.Text = rsResult.result;
                    await Json_Paring_Destination(rsResult.result);
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

            hbHotelRoom_Grid.ItemsSource = HBDestinationDescList;
            await CreateCSVFromGenericList(HBDestinationDescList, @"..\..\CSVfiles\DestinationDesc.csv");

            statusBar.Content = status_barTxt;
            MessageBox.Show(status_barTxt);
        }

        private async Task Json_Paring_Destination(string json)
        {
            try
            {

                JObject obj = JObject.Parse(json);

                if (total_number == 0)
                {
                    //Console.WriteLine(obj["total"].ToString());
                    total_number = int.Parse(obj["total"].ToString());
                }

                JArray hotel_destination = JArray.Parse(obj["destinations"].ToString());
                foreach (JObject itemObj in hotel_destination)
                {
                    if (itemObj.ContainsKey("zones") == true)
                    {
                        JArray hotel_zones = JArray.Parse(itemObj["zones"].ToString());
                        foreach (JObject itemObj2 in hotel_zones)
                        {
                            DestinationDesc contents = new DestinationDesc();                            
                            contents.destinatin_code = itemObj["code"].ToString();                            
                            if (itemObj.ContainsKey("name") == true)
                            {
                                contents.destinatin_name = itemObj["name"]["content"].ToString();
                            }                             
                            
                            contents.destinatin_countryCode = itemObj["countryCode"].ToString();
                            
                            contents.destinatin_zonecode = itemObj2["zoneCode"].ToString();
                            
                            contents.destinatin_zonecode_name = itemObj2["name"].ToString();
                            

                            HBDestinationDescList.Add(contents);
                        }
                    }
                    else
                    {
                        DestinationDesc contents = new DestinationDesc();
                        contents.destinatin_code = itemObj["code"].ToString();
                        contents.destinatin_name = itemObj["name"]["content"].ToString();
                        contents.destinatin_countryCode = itemObj["countryCode"].ToString();

                        HBDestinationDescList.Add(contents);
                    }           

                        
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}

