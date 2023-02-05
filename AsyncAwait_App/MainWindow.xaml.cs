using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
using AsyncAwait_App.Models;

namespace AsyncAwait_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            RunSyncLoad();
            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;
            textBlock.Text += $"Total time: {time}ms\n";
        }

        public async void BtnAsync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await RunAsyncLoad();
            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;
            textBlock.Text += $"Total time: {time}ms\n";
        }

        private async Task RunAsyncLoad()
        {
            var sites = PrepareData();

            foreach (var site in sites)
            {
                var model = await Task.Run(() => DownloadSite(site));
                ReportInfo(model);
            }
        }

        private void RunSyncLoad()
        {
            var sites = PrepareData();

            foreach (var site in sites)
            {
                DataModel model = DownloadSite(site);
                ReportInfo(model);
            }
        }

        private void ReportInfo(DataModel dataModel)
        {
            textBlock.Text += $"Site: {dataModel.Url}, Length: {dataModel.Data.Length}\n";
        }

        private List<string> PrepareData()
        {
            List<string> list = new List<string>()
            {
                "https://vanutp.dev",
                "https://progtime.net",
                "https://mootfrost.ru"
            };
            return list;
        }

        private DataModel DownloadSite(string url)
        {
            DataModel dataModel = new DataModel();
            WebClient client = new WebClient();

            string data = client.DownloadString(url);
            dataModel.Url = url;
            dataModel.Data = data;

            return dataModel;
        }
    }
}
