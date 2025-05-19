using LiveCharts;
using LiveCharts.Wpf;
using ServerManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ServerManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ServerViewModel> Servers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Servers = new ObservableCollection<ServerViewModel>
            {
                new ServerViewModel 
                {
                    CpuUsage = new ChartValues<double> { 67.5 },
                    MemoryUsage = new ChartValues<double> { 67.5 },
                    PingData = new ChartValues<double> { 10, 20, 30, 40, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 },
                    ProcessList = new ObservableCollection<ProcessInfo>
                    {
                        new ProcessInfo { Name = "DllImport.exe", Memory = 3.00 },
                        new ProcessInfo { Name = "DllImport.exe", Memory = 3.00},
                        new ProcessInfo { Name = "Chrome.exe", Memory = 3.00}
                    },
                    PingList = new ObservableCollection<PingInfo>
                    {
                        new PingInfo { Time = "17:12:00", Value = "2ms" },
                        new PingInfo { Time = "17:12:10", Value = "2ms" },
                        new PingInfo { Time = "17:12:20", Value = "2ms" }
                    }
                },
                new ServerViewModel { /* khởi tạo dữ liệu server 2 */ },
                new ServerViewModel { /* khởi tạo dữ liệu server 3 */ },
                new ServerViewModel { /* khởi tạo dữ liệu server 4 */ }
                // Thêm các server khác
            };
            for (int i = 0; i < Servers.Count; i++)
            {
                Servers[i].Index = i + 1; // Đánh số từ 1
            }
            DataContext = this;
        }
    }
}
