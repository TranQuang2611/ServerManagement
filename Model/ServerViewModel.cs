using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ServerManagement.Model
{
    public class ServerViewModel : INotifyPropertyChanged
    {
        private Brush _borderColor = Brushes.Green;
        public Brush BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; OnPropertyChanged(nameof(BorderColor)); }
        }
        public int Index { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string Status { get; set; }
        public string Secret { get; set; }
        public ChartValues<double> CpuUsage { get; set; }
        public ChartValues<double> MemoryUsage { get; set; }
        public ObservableCollection<ProcessInfo> ProcessList { get; set; }
        public ChartValues<double> PingData { get; set; }
        public ObservableCollection<PingInfo> PingList { get; set; }
        public ServerViewModel()
        {
            CpuUsage = new ChartValues<double>();
            MemoryUsage = new ChartValues<double>();
            ProcessList = new ObservableCollection<ProcessInfo>();
            PingList = new ObservableCollection<PingInfo>();
        }


        // Ví dụ: Khi có điều kiện, đổi màu
        public void UpdateStatus(bool isError)
        {
            BorderColor = isError ? Brushes.Red : Brushes.Green;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }

    public class ProcessInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Memory { get; set; }

        public string DisplayName
        {
            get
            {
                return $"{Name.Substring(0, 12)}";
            }
        }

        public string DisplayMemory
        {
            get
            {
                return $"{Memory} MB";
            }
        }
    }

    public class PingInfo
    {
        public string Time { get; set; }
        public string Value { get; set; }
    }
}
