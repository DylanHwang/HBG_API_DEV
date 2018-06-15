using HGB_DI_MONI.domain;
using HGB_DI_MONI.service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Json;
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
    /// AvailabilityView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AvailabilityView : UserControl
    {
        private string Xsignature = "";
        const string endpoint = "https://api.hotelbeds.com/hotel-api/1.0";
        //private string Api_Key = "f5jbfmqaw2g2t3qzt863kenk";
        //private string Sercurity_Key = "kEBasrGDwB";
        private int roomNight = 0;
        MainWindow mainWindow = null;

        List<HotelRooms> hotelRommsContionList;

        public AvailabilityView()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            mainWindow = new MainWindow();
            ApiUrl_TB.Text = endpoint;
            //ApiKey_TB.Text = Api_Key;
            //Security_TB.Text = Sercurity_Key;
            HotelCodes_TB.Text = "1067,1070,1075,135813,145214,1506,1508,1526,1533,1539,1550,161032,170542,182125,187939,212167,215417,228671,229318,23476";
            CheckIn.SelectedDate = DateTime.Today;
            CheckOut.SelectedDate = DateTime.Today.AddDays(1);

            TimeSpan diff = CheckOut.SelectedDate.Value.Date.Subtract(CheckIn.SelectedDate.Value.Date);
            roomNight = int.Parse(diff.TotalDays.ToString());

            //ChildNum_CB.IsEnabled = false;

            //RQ_Json_TB.Text = Json_RQ4HotelList().ToString();
        }        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {


            //Xsignature = XSignature_Generate();

            HttpConnects h_Conn = new HttpConnects(ApiUrl_TB.Text + "/hotels", mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

            var Json_RQ = Json_RQ4HotelList().ToString();
            RQ_Json_TB.Text = Json_RQ;



            change_button_status();

            RSResult rsResult = await h_Conn.searhAllRoomsInHotelS(Json_RQ);

            if (rsResult.rq_status == true)
            {
                RS_Json_TB.Text = rsResult.result;
                hotelRommsContionList = await Json_Paring(rsResult.result);
                hbHotelRoom_Grid.ItemsSource = hotelRommsContionList;
                statusBar.Content = "Done: Checking Successfully";                

                MessageBox.Show("Rate plan checking process has done !!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(rsResult.result);
                statusBar.Content = "Error: " + rsResult.result;
            }

            change_button_status();
        }


        private void change_button_status()
        {
            if (Start_btn.IsEnabled)
            {
                Start_btn.Content = "Progress...";
                Start_btn.IsEnabled = false;
            }
            else
            {
                Start_btn.Content = "Start";
                Start_btn.IsEnabled = true;
            }

        }


        private int testi = 0;
        private int total_checking_rooms;

        private async Task<List<HotelRooms>> Json_Paring(string json)
        {
            total_checking_rooms = 0;

            JObject obj = JObject.Parse(json);

            List<HotelRooms> hotelRomms = new List<HotelRooms>();

            if (int.Parse(obj["hotels"]["total"].ToString()) > 0)
            {
                JArray hotel_hotels = JArray.Parse(obj["hotels"]["hotels"].ToString());



                foreach (JObject itemObj in hotel_hotels)
                {

                    JArray hotel_rooms = JArray.Parse(itemObj["rooms"].ToString());


                    foreach (JObject itemObj2 in hotel_rooms)
                    {

                        JArray hotel_rates = JArray.Parse(itemObj2["rates"].ToString());

                        total_checking_rooms += hotel_rates.Count;

                        foreach (JObject itemObj3 in hotel_rates)
                        {
                            HotelRooms hotelRoom = new HotelRooms();

                            hotelRoom.checkIn = obj["hotels"]["checkIn"].ToString();
                            hotelRoom.checkOut = obj["hotels"]["checkOut"].ToString();
                            hotelRoom.hotel_code = Convert.ToInt64(itemObj["code"].ToString());
                            hotelRoom.hotel_name = itemObj["name"].ToString();
                            hotelRoom.hotel_destinationCode = itemObj["destinationCode"].ToString();
                            hotelRoom.hotel_destinationName = itemObj["destinationName"].ToString();
                            hotelRoom.hotel_zoneCode = Convert.ToInt64(itemObj["zoneCode"].ToString());
                            hotelRoom.hotel_zoneName = itemObj["zoneName"].ToString();
                            hotelRoom.room_code = itemObj2["code"].ToString();
                            hotelRoom.room_name = itemObj2["name"].ToString();
                            hotelRoom.rateKey = itemObj3["rateKey"].ToString();
                            hotelRoom.rateType = itemObj3["rateType"].ToString();


                            Console.WriteLine(testi);

                            //** Checek Actual Availability Rate:**//
                            if (RateCheck_YN.IsChecked == true)
                            {
                                hotelRoom.callBack = await hotelCheckRates(itemObj3["rateKey"].ToString());
                            }


                            Console.WriteLine(testi);

                            hotelRoom.net = itemObj3["net"].ToString();

                            if (itemObj3.ContainsKey("sellingRate") == true)
                            {
                                hotelRoom.sellingRate = itemObj3["sellingRate"].ToString();
                            }

                            hotelRoom.packaging = bool.Parse(itemObj3["packaging"].ToString());

                            hotelRomms.Add(hotelRoom);

                            Console.WriteLine(" TOT :" + total_checking_rooms);
                            statusBar.Content = "Please waith for a Second.... We Start Checking the Health of System ... ->Cheked... :" + total_checking_rooms;

                            testi++;

                        }
                    }
                }
            }

            //var test2 = JsonConvert.SerializeObject(hotelRomms);
            //Console.WriteLine(test2);


            return hotelRomms;
        }

        private async Task<bool> hotelCheckRates(string rateKey)
        {
            bool check_rst = false;

            try
            {
                HttpConnects h_Conn = new HttpConnects(ApiUrl_TB.Text + "/checkrates", mainWindow.ApiKey_TB.Text, Xsignature);

                string rq_json = Json_RQ4RateCheck(rateKey).ToString();
                Console.WriteLine(rq_json);

                Console.WriteLine(testi);
                var result = await h_Conn.searhAllRoomsInHotelS(rq_json);
                Console.WriteLine(result);

                if (result.rq_status == false || result.result == null || result.result == "")
                {
                    check_rst = false;
                }
                else
                {
                    //check_rst = true;
                    JObject obj = JObject.Parse(result.result);
                    if (obj.ContainsKey("hotel") == true)
                    {
                        Console.WriteLine(obj.ContainsKey("hotel"));

                        JArray rooms_Jarr = JArray.Parse(obj["hotel"]["rooms"].ToString());

                        foreach (JObject itemObj in rooms_Jarr)
                        {

                            JArray hotel_rates_Jarr = JArray.Parse(itemObj["rates"].ToString());

                            foreach (JObject itemObj1 in hotel_rates_Jarr)
                            {
                                if (itemObj1["rateType"].ToString().Equals("BOOKABLE") == true)
                                {
                                    check_rst = true;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                check_rst = false;
            }

            return check_rst;
        }

        //public string XSignature_Generate()
        //{
        //    Api_Key = mainWindow.ApiKey_TB.Text;
        //    Sercurity_Key = mainWindow.Security_TB.Text;

        //     Compute the signature to be used in the API call (combined key + secret + timestamp in seconds)
        //    string signature;
        //    using (var sha = SHA256.Create())
        //    {
        //        long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
        //        Console.WriteLine("Timestamp: " + ts);
        //        var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(Api_Key + Sercurity_Key + ts));
        //        signature = BitConverter.ToString(computedHash).Replace("-", "");
        //    }

        //    Xsignature = signature;
        //    return signature;
        //}


        public object Json_RQ4HotelList()
        {
            JsonObjectCollection res = new JsonObjectCollection();

            JsonObjectCollection stay = new JsonObjectCollection("stay");

            // Console.WriteLine(String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(CheckIn.Text)));
            // Console.WriteLine(String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(CheckOut.Text)));

            stay.Add(new JsonStringValue("checkIn", String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(CheckIn.Text))));
            stay.Add(new JsonStringValue("checkOut", String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(CheckOut.Text))));
            res.Add(stay);

            JsonArrayCollection occupancies = new JsonArrayCollection("occupancies");
            JsonObjectCollection room1 = new JsonObjectCollection();

            ComboBoxItem roomNumCombo = (ComboBoxItem)RoomNum_CB.SelectedItem;
            int rooms = int.Parse(roomNumCombo.Content.ToString());

            ComboBoxItem adultNumCombo = (ComboBoxItem)AdultNum_CB.SelectedItem;
            int adults = int.Parse(adultNumCombo.Content.ToString());


            room1.Add(new JsonNumericValue("rooms", rooms));
            room1.Add(new JsonNumericValue("adults", adults));
            room1.Add(new JsonNumericValue("children", 0));
            occupancies.Add(new JsonObjectCollection(null, room1));
            res.Add(occupancies);


            JsonObjectCollection hotels = new JsonObjectCollection("hotels");

            JsonArrayCollection hotel = new JsonArrayCollection("hotel");

            string[] hotel_codes = HotelCodes_TB.Text.ToString().Split(',');



            foreach (string hotel_code in hotel_codes)
            {

                //    Console.WriteLine(hotel_code);
                hotel.Add(new JsonNumericValue(null, int.Parse(hotel_code)));
            }
            //hotel.Add(new JsonNumericValue(null, 23476));

            hotels.Add(hotel);
            res.Add(hotels);

            return res;
        }


        public object Json_RQ4RateCheck(string rateKey)
        {
            JsonObjectCollection res = new JsonObjectCollection();

            JsonArrayCollection rooms = new JsonArrayCollection("rooms");
            JsonObjectCollection rateKeyItem = new JsonObjectCollection();
            rateKeyItem.Add(new JsonStringValue("rateKey", rateKey));
            rooms.Add(new JsonObjectCollection(null, rateKeyItem));

            res.Add(rooms);

            return res;

        }

        private void CheckIn_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckIn.SelectedDate != null)
            {
                if (CheckIn.SelectedDate >= CheckOut.SelectedDate)
                {
                    CheckOut.SelectedDate = CheckIn.SelectedDate.Value.AddDays(roomNight);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please Check the Check-in date: Not Null ... ");
                CheckIn.SelectedDate = DateTime.Today;
            }


        }

        private void CheckOut_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CheckOut.SelectedDate != null)
            {
                if (CheckIn.SelectedDate >= CheckOut.SelectedDate)
                {
                    MessageBoxResult result = MessageBox.Show("Please Check the Check-Out date: Eariy date ...");
                    CheckOut.SelectedDate = CheckIn.SelectedDate.Value.AddDays(roomNight);
                }
                else
                {
                    roomNight = CheckOut.SelectedDate.Value.Day - CheckIn.SelectedDate.Value.Day;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please Check the Check-Out date: Not Null ...");
                CheckOut.SelectedDate = CheckIn.SelectedDate.Value.AddDays(roomNight);
            }


        }

        
    }
}
