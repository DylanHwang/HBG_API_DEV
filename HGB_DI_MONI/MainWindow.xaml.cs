using HGB_DI_MONI.domain;
using HGB_DI_MONI.service;
using HGB_DI_MONI.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HGB_DI_MONI
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        

        //private string Xsignature = "";
        const string endpoint = "https://api.test.hotelbeds.com/hotel-api/1.0";
        public string Api_Key = "766sm2mjnvtwct5gkhs7z4g8";
        public string Sercurity_Key = "duYZZUp9eX";
        //private int roomNight = 0;

        //List<HotelRooms> hotelRommsContionList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }        

        private void Window_Initialized(object sender, EventArgs e)
        {

            ApiKey_TB.Text = Api_Key;
            Security_TB.Text = Sercurity_Key;
            DataContext = new ContentAPIViewModel();

        }

        private void Availability_btn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AvailabilityAPIViewModel();
        }

        private void BookingDetail_btn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BookingDetailsViewModel();
        }

        private void Content_btn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ContentAPIViewModel();
        }

        private void test_btn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new testFunctionViewModel();
        }            
    }

}
