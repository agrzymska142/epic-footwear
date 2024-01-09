using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.UI.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Grzymska.EpicFootwear.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        static public DataProvider Provider;

        protected override void OnStartup(StartupEventArgs e)
        {
            string DAO_Name = ConfigurationManager.AppSettings["DAO_Name"];
            if (DAO_Name != null)
            {
                Provider = new DataProvider(DAO_Name);
            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(Provider)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
