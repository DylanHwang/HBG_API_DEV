using HGB_DI_MONI.domain;
using HGB_DI_MONI.service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for BookingDetailsView.xaml
    /// </summary>
    public partial class BookingDetailsView : UserControl
    {

        private string Xsignature = "";
        const string endpoint = "https://api.hotelbeds.com/hotel-api/1.0/bookings/";                
        MainWindow mainWindow = null;
        
        public BookingDetailsView()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            mainWindow = ((MainWindow)Application.Current.MainWindow);
            ApiUrl_TB.Text = endpoint;            
        }

        private async void Start_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Booking_Ref.Text == "")
            {
                MessageBox.Show("Please Enter the HotelBeds Booking ID");
            }
            else{
                string getApiUrl = ApiUrl_TB.Text + Booking_Ref.Text;
                HttpConnects h_Conn = new HttpConnects(getApiUrl, mainWindow.ApiKey_TB.Text, mainWindow.Security_TB.Text);

                statusBar.Content = "Please wait for a Second.... Now We are Communicating with HB API ... -> Get Booking Info ";
                RSResult rsResult = await h_Conn.GetBookingDetail();

                if (rsResult.rq_status == true)
                {
                    RS_Json_TB.Text = JValue.Parse(rsResult.result).ToString(Formatting.Indented);                    

                    statusBar.Content = "Done: Checking Successfully";
                    MessageBox.Show("Booking Detail checking process has done !!");
                }
                else
                {
                    statusBar.Content = "Error: " + rsResult.result;
                    MessageBoxResult result = MessageBox.Show(rsResult.result);                    
                }
            }
        }     
    }
}
