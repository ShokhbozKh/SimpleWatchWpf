using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer timer = new DispatcherTimer();
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VaqtKetdi();
        }
        private void VaqtKetdi()
        {
            timer.Interval = TimeSpan.FromSeconds(1); // Har 1 soniya dan

                // UI ni yangilash kodi

            timer.Tick += (sender, e) =>
            {
                // har secundda UI opacity va qiymatlari yangilanadi

                var date = DateTime.Now;
                HourTxt.Text = $"{date.TimeOfDay.Hours}";
                HourIkkiNuqtaTxt.Text = $":";
                MinuteTxt.Text = $"{date.TimeOfDay.Minutes}";
                SecundTxt.Text = $" {DateTime.Now.TimeOfDay.Seconds}";
                WeekTxt.Text = date.DayOfWeek.ToString();
                YearTxt.Text = $"{date.Month}/{date.Day}/{date.Year}";

                this.Dispatcher.Invoke(() =>
                {
                    if (SecundTxt.Opacity == 1)
                    {
                        HourIkkiNuqtaTxt.Opacity = 0.5;
                        SecundTxt.Opacity = 0.5;
                    }
                    else
                    {
                        SecundTxt.Opacity = 1;
                        HourIkkiNuqtaTxt.Opacity = 1;

                    }
                });
            };

            timer.Start();
        }

        private void DragBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {// SICHQONCHA UCHUN FUNKSIYA
            if(e.MouseDevice.LeftButton == MouseButtonState.Pressed) 
                // bu mouse ga sichqoncha CHAP TUGMA BOSSA ICHIGA KIRADI
            {
                this.DragMove();
                // QIMIRLATISHGA IMKON BERADI
            }
            if(e.ClickCount == 3)// 3 marta bosilsa dasturdan chiqib ketadi
            {
                this.Close();
            }
        }
    }
}
