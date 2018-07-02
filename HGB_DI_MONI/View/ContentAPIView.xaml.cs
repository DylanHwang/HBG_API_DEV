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


        const string endpoint = "https://api.hotelbeds.com/hotel-content-api/1.0/";
        //private string fields = "hotels?fields=name%2CcountryCode%2CzoneCode%2CdestinationCode%2Ccoordinates%2CchainCode%2CaccommodationTypeCode%2Caddress%2CpostalCode%2Ccity%2Cphones%2CS2C&language=ENG&useSecondaryLanguage=false";
        private string fields = "";
        private int from = 1;
        private int to = 1000;

        private int current_from = 0;
        private int current_to = 0;
        private int total_number = 0;

        private string GL_target_Data = "";

        MainWindow mainWindow = null;
        WrapPanel option_wrapPanel;



        public ContentAPIView()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            //numberOfData = "&from=" + from + "&to=" + to;                                             
            ApiUrl_TB.Text = endpoint;
            Extract_btn.IsEnabled = false;

            mainWindow = ((MainWindow)Application.Current.MainWindow);
        }

        List<HotelInformation> hotelContentsList;
        List<RoomImage> HBRoomImageList;
        List<RoomDesc> RoomDescMomoryDB;
        List<CountryDesc> CountryDescMomoryDB;
        List<DestinationDesc> DestinationDescMomoryDB;

        private async void GetHotel_btn_Click(object sender, RoutedEventArgs e)
        {
            //In Memory DB 불러오기.
            CountryDescMomoryDB = File.ReadAllLines(@"..\..\CSVfiles\CountryDesc.csv")
                                      .Skip(1)
                                      .Select(v => CountryDesc.FromCsv(v))
                                      .ToList();

            DestinationDescMomoryDB = File.ReadAllLines(@"..\..\CSVfiles\DestinationDesc.csv")
                                     .Skip(1)
                                     .Select(v => DestinationDesc.FromCsv(v))
                                     .ToList();

            RoomDescMomoryDB = File.ReadAllLines(@"..\..\CSVfiles\RoomDesc.csv")
                                    .Skip(1)
                                    .Select(v => RoomDesc.FromCsv(v))
                                    .ToList();

            change_button_status();

            string status_barTxt = "";

            hotelContentsList = new List<HotelInformation>();
            HBRoomImageList = new List<RoomImage>();

            from = 1;
            to = 1000;
            total_number = 0;

            current_from = from;
            current_to = to;


            string getApiUrl = ApiUrl_TB.Text + setField4HotelContents(GL_target_Data);

            //Console.WriteLine(getApiUrl);


            HttpConnects h_Conn = new HttpConnects(getApiUrl, mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

            do
            {

                statusBar.Content = "Please wait for a Second.... Now We are Communicating with HB API ... -> Get Hotel from " + current_from + " to " + current_to;

                RSResult rsResult = await h_Conn.GetHotelContents(current_from, current_to);
                //Console.WriteLine(rsResult.result);

                if (rsResult.rq_status == true)
                {                    
                    await Json_Paring(GL_target_Data, rsResult.result);
                    status_barTxt = "Done: Successfully, Get Hotel from 1  to " + current_to; ;
                    
                }
                else
                {
                    status_barTxt = "Error: " + rsResult.result;
                    MessageBoxResult result = MessageBox.Show(rsResult.result);

                    break;
                }

                current_from = current_to + 1;
                current_to = current_from + 999;
                

            } while (total_number > current_from);


            switch (GL_target_Data)
            {
                case "HT":
                    //** THIS "hotelContentsList" Cooming from Json_Paring() function as a Global parameter
                    hbHotelRoom_Grid.ItemsSource = hotelContentsList;
                    break;
                case "IMG":
                    //** THIS "hotelContentsList" Cooming from Json_Paring() function as a Global parameter
                    HBRoomImageList = (from x in HBRoomImageList
                                                  orderby x.hotel_code, x.imageOrder ascending
                                                  select x).ToList();
                    hbHotelRoom_Grid.ItemsSource = HBRoomImageList;
                    break;
                default:
                    hbHotelRoom_Grid.ItemsSource = hotelContentsList;
                    break;

            }


            statusBar.Content = status_barTxt;
            MessageBox.Show(status_barTxt);

            change_button_status();
        }

        private async Task Json_Paring(string target_parsing_Data, string json)
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

                switch (target_parsing_Data)
                {
                    case "HT":

                        foreach (JObject itemObj in hotel_hotels)
                        {
                            HotelInformation contents = new HotelInformation();

                            contents.code = Convert.ToInt64(itemObj["code"].ToString());
                            contents.name = itemObj["name"]["content"].ToString();


                            if (itemObj.ContainsKey("exclusiveDeal") == true)
                            {

                                if (Convert.ToInt64(itemObj["exclusiveDeal"].ToString()) == 1)
                                {
                                    contents.isGnD = "Y";
                                }
                            }

                            if (itemObj.ContainsKey("countryCode") == true)
                            {
                                string countryCode_tmp = itemObj["countryCode"].ToString();
                                contents.countryCode = countryCode_tmp;
                                var linq = (from c in CountryDescMomoryDB where c.country_code == countryCode_tmp select new { c.country_description }).First();
                                contents.countryName = linq.country_description.ToString();
                            }

                            if (itemObj.ContainsKey("destinationCode") == true)
                            {
                                string destinationCode_tmp = itemObj["destinationCode"].ToString();
                                contents.destinationCode = destinationCode_tmp;
                                var linq = (from d in DestinationDescMomoryDB where d.destinatin_code == destinationCode_tmp select new { d.destinatin_name }).First();
                                contents.destinationName = linq.destinatin_name.ToString();
                            }

                            if (itemObj.ContainsKey("zoneCode") == true)
                            {
                                contents.zoneCode = itemObj["zoneCode"].ToString();
                            }

                            if (itemObj.ContainsKey("coordinates") == true)
                            {
                                contents.longitude = itemObj["coordinates"]["longitude"].ToString();
                                contents.latitude = itemObj["coordinates"]["latitude"].ToString();
                            }

                            if (itemObj.ContainsKey("chainCode") == true)
                            {
                                contents.chainCode = itemObj["chainCode"].ToString();
                            }

                            if (itemObj.ContainsKey("accommodationTypeCode") == true)
                            {
                                contents.accommodationTypeCode = itemObj["accommodationTypeCode"].ToString();
                            }

                            if (itemObj.ContainsKey("address") == true)
                            {
                                contents.address = itemObj["address"]["content"].ToString();
                            }

                            if (itemObj.ContainsKey("postalCode") == true)
                            {
                                contents.postalCode = itemObj["postalCode"].ToString();
                            }

                            if (itemObj.ContainsKey("city") == true)
                            {
                                contents.city = itemObj["city"]["content"].ToString();
                            }

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
                        break;

                    case "IMG":

                        foreach (JObject itemObj in hotel_hotels)
                        {

                            if (itemObj.ContainsKey("images") == true)
                            {
                                JArray hotel_images = JArray.Parse(itemObj["images"].ToString());
                                foreach (JObject itemObj2 in hotel_images)
                                {

                                    string room_only_yn = "";

                                    for (int i = 0; i < option_wrapPanel.Children.Count; i++)
                                    {
                                        CheckBox option_chbx = (CheckBox)option_wrapPanel.Children[i];
                                        if ((bool)option_chbx.IsChecked)
                                        {
                                            room_only_yn = option_chbx.Name;
                                        }
                                        Console.WriteLine(room_only_yn);
                                    }

                                    if( room_only_yn == "")
                                    {
                                        RoomImage contents = new RoomImage();

                                        contents.hotel_code = Convert.ToInt64(itemObj["code"].ToString());
                                        contents.hotel_name = itemObj["name"]["content"].ToString();


                                        if (itemObj.ContainsKey("countryCode") == true)
                                        {
                                            string countryCode_tmp = itemObj["countryCode"].ToString();
                                            contents.hotel_countryCode = countryCode_tmp;
                                            var linq = (from c in CountryDescMomoryDB where c.country_code == countryCode_tmp select new { c.country_description }).First();
                                            contents.hotel_countryName = linq.country_description.ToString();
                                        }


                                        if (itemObj.ContainsKey("destinationCode") == true)
                                        {
                                            string destinationCode_tmp = itemObj["destinationCode"].ToString();
                                            contents.hotel_destinationCode = destinationCode_tmp;
                                            var linq = (from d in DestinationDescMomoryDB where d.destinatin_code == destinationCode_tmp select new { d.destinatin_name }).First();
                                            contents.hotel_destinationName = linq.destinatin_name.ToString();
                                        }

                                        contents.imageOrder = Convert.ToInt64(itemObj2["order"].ToString());
                                        contents.imageTypeCode = itemObj2["imageTypeCode"].ToString();
                                        if (itemObj2.ContainsKey("roomCode") == true)
                                        {
                                            string imageroomCode_tmp = itemObj2["roomCode"].ToString();
                                            contents.imageroomCode = imageroomCode_tmp;
                                            var linq = (from r in RoomDescMomoryDB where r.room_code == imageroomCode_tmp select new { r.room_description }).First();
                                            contents.room_typeDescription = linq.room_description.ToString();
                                        }
                                        contents.imagePath = itemObj2["path"].ToString();

                                        HBRoomImageList.Add(contents);
                                    }
                                    else
                                    {
                                        if (itemObj2["imageTypeCode"].ToString().Equals("HAB"))
                                        {
                                            if (itemObj2.ContainsKey("roomCode") == true)
                                            {
                                                RoomImage contents = new RoomImage();

                                                contents.hotel_code = Convert.ToInt64(itemObj["code"].ToString());
                                                contents.hotel_name = itemObj["name"]["content"].ToString();
                                                if (itemObj.ContainsKey("countryCode") == true)
                                                {
                                                    string countryCode_tmp = itemObj["countryCode"].ToString();
                                                    contents.hotel_countryCode = countryCode_tmp;
                                                    var roonm_only_linq = (from c in CountryDescMomoryDB where c.country_code == countryCode_tmp select new { c.country_description }).First();
                                                    contents.hotel_countryName = roonm_only_linq.country_description.ToString();
                                                }


                                                if (itemObj.ContainsKey("destinationCode") == true)
                                                {
                                                    string destinationCode_tmp = itemObj["destinationCode"].ToString();
                                                    contents.hotel_destinationCode = destinationCode_tmp;
                                                    var roonm_only_linq = (from d in DestinationDescMomoryDB where d.destinatin_code == destinationCode_tmp select new { d.destinatin_name }).First();
                                                    contents.hotel_destinationName = roonm_only_linq.destinatin_name.ToString();
                                                }
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
                        break;
                    case "HDTL":
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        private async void Extract_btn_Click(object sender, RoutedEventArgs e)
        {
            change_button_status();

            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";


            //* Changes file name depend on what kind of data wanted to exported.            

            if (GL_target_Data.Equals("IMG"))
            {
                sfd.FileName = "(" + DateTime.Now.ToShortDateString() + ") HB_Active_Image_Properties.csv";
            }
            else
            {
                sfd.FileName = "(" + DateTime.Now.ToShortDateString() + ") HB_Active_Hotel_Properties.csv";
            }

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

                if (GL_target_Data.Equals("IMG"))
                {
                    if (HBRoomImageList.Count > 0)
                    {
                        statusBar.Content = "Please wait for a Second.... Now We are Making CSV File ...";
                        await CreateCSVFromGenericList(HBRoomImageList, filename);
                        MessageBox.Show("Data Export has done, Please check CSV file");
                        statusBar.Content = "Done: Data Export has done, Please check CSV file";
                    }
                    else
                    {
                        MessageBox.Show("There is no data to Extract");
                    }
                }
                else
                {
                    if (hotelContentsList.Count > 0)
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
            change_button_status();
        }

        private async Task CreateCSVFromGenericList<T>(List<T> list, string csvNameWithExt)
        {
            if (list == null || list.Count == 0) return;

            //get type from 0th member
            Type t = list[0].GetType();
            string newLine = Environment.NewLine;

            using (var sw = new StreamWriter(csvNameWithExt, false, Encoding.UTF8))
            {
                //make a new instance of the class name we figured out to get its props
                object o = Activator.CreateInstance(t);
                //gets all properties
                PropertyInfo[] props = o.GetType().GetProperties();

                //foreach of the properties in class above, write out properties
                //this is the header row
                foreach (PropertyInfo pi in props)
                {
                    sw.Write(pi.Name.ToUpper() + ",");
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
                                .Replace(",", " ").Replace("\"", "").Replace("\t", " ").Replace("\v", " ").Replace("＼f", "").Replace(Environment.NewLine, "").Replace("\r\n", "").Replace("\n", "").Replace("\r", "") + ',';
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

        private void change_button_status()
        {
            if (GetHotel_btn.IsEnabled)
            {
                //GetHotel_btn.Content = "Progress...";
                GetHotel_btn.IsEnabled = false;
                Extract_btn.IsEnabled = false;
            }
            else
            {
                //GetHotel_btn.Content = "Get All Hotel Information";
                GetHotel_btn.IsEnabled = true;
                Extract_btn.IsEnabled = true;
            }

        }

        private void extract_Opt_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem ComboItem = (ComboBoxItem)extract_Opt_Combo.SelectedItem;
            string name = ComboItem.Name;

            switch (name)
            {
                case "HT":
                    GL_target_Data = "HT";
                    CreatCheckBox4Column("HT");
                    break;
                case "IMG":
                    GL_target_Data = "IMG";
                    CreatCheckBox4Column("IMG");                    
                    break;
                case "HDTL":
                    GL_target_Data = "HDTL";
                    extract_Opt_Combo.SelectedIndex = 0;
                    MessageBox.Show("Hotel Detail Search: Comming Soon...");
                    break;
            }

        }

        private void CreatCheckBox4Column(string option)
        {

            option_wrapPanel = new WrapPanel();
            option_wrapPanel.Orientation = Orientation.Horizontal;
            option_wrapPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            option_wrapPanel.Width = double.NaN;
            option_wrapPanel.Margin = new Thickness(10, 0, 0, 0);


            if (option.Equals("HT"))
            {

                CheckBox chb = new CheckBox();
                chb.Margin = new Thickness(10, 0, 0, 0);
                chb.Foreground = new SolidColorBrush(Colors.White);
                chb.Content = "Code";
                chb.Name = "Code";
                chb.IsChecked = true;
                chb.IsEnabled = false;
                option_wrapPanel.Children.Add(chb);

                chb = new CheckBox();
                chb.Margin = new Thickness(10, 0, 0, 0);
                chb.Foreground = new SolidColorBrush(Colors.White);
                chb.Content = "All";
                chb.Name = "all";
                chb.IsChecked = true;
                chb.IsEnabled = false;
                option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "Hotel Name";
                //chb.Name = "name";
                //chb.IsChecked = true;
                //chb.IsEnabled = false;
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "Country Code";
                //chb.Name = "countryCode";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "Destination Code";
                //chb.Name = "destinationCode";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "Zone Code";
                //chb.Name = "zoneCode";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "Coordinates";
                //chb.Name = "coordinates";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);           



                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "ChainCode";
                //chb.Name = "chainCode";
                //chb.IsChecked = true;      
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "AccommodationTypeCode";
                //chb.Name = "accommodationTypeCode";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "Address";
                //chb.Name = "address";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "PostalCode";
                //chb.Name = "postalCode";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);


                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "City";
                //chb.Name = "city";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);

                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "PhoneNumber";
                //chb.Name = "phones";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);

                //chb = new CheckBox();
                //chb.Margin = new Thickness(10, 0, 0, 0);
                //chb.Foreground = new SolidColorBrush(Colors.White);
                //chb.Content = "S2C";
                //chb.Name = "S2C";
                //chb.IsChecked = true;
                //option_wrapPanel.Children.Add(chb);
            }
            else if (option.Equals("IMG"))
            {
                CheckBox chb = new CheckBox();
                chb.Margin = new Thickness(10, 0, 0, 0);
                chb.Foreground = new SolidColorBrush(Colors.White);
                chb.Content = "Room Image Only";
                chb.Name = "roomImage";
                chb.IsChecked = false;
                option_wrapPanel.Children.Add(chb);

            }

            // Clear/Remove checkbox area before adding new check box option

            int getRow = 0, getCol = 1;
            for (int i = 0; i < Option_Grid.Children.Count; i++)
            {
                if ((Grid.GetRow(Option_Grid.Children[i]) == getRow)
                    && (Grid.GetColumn(Option_Grid.Children[i]) == getCol))
                {
                    Option_Grid.Children.Remove(Option_Grid.Children[i]);
                    break;
                }
            }

            // dd new CheckBox option as a children.

            Option_Grid.Children.Add(option_wrapPanel);
            Grid.SetRow(option_wrapPanel, 0);
            Grid.SetColumn(option_wrapPanel, 1);

        }



        private string setField4HotelContents(string target_extract_Data)
        {
            switch (target_extract_Data)
            {
                case "HT":

                    fields = "hotels?fields=";

                    for (int i = 0; i < option_wrapPanel.Children.Count; i++)
                    {
                        CheckBox obj = (CheckBox)option_wrapPanel.Children[i];

                        if ((bool)obj.IsChecked)
                        {
                            if (i > 0)  // to remove "code" fileds (error occuring)
                            {
                                if (i > 1)
                                {
                                    fields += "%2C";
                                }
                                fields += obj.Name;
                            }
                        }

                        Console.WriteLine(fields);
                    }

                    break;

                case "IMG":

                    fields = "hotels?fields=name%2CcountryCode%2CdestinationCode%2Cimages";
                    break;
            }

            fields += "&language=ENG&useSecondaryLanguage=false";

            return fields;

        }


    }
}
