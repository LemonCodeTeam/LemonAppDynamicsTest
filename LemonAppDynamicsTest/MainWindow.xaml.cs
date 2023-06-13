using System.Net.Http;
using System.Net;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;

namespace LemonAppDynamicsTest
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
        public static SocketsHttpHandler GetSta() => new SocketsHttpHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip,
            KeepAlivePingPolicy = HttpKeepAlivePingPolicy.Always
        };
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using var hc = new HttpClient(GetSta());
            var a = await hc.GetAsync("https://gitee.com/TwilightLemon/LemonAppDynamics/raw/master/Windows_LemonApp_AboutPage.xaml");
            string data= await a.Content.ReadAsStringAsync();
            cons.Children.Add((Grid)XamlReader.Parse(data));
        }
    }
}
