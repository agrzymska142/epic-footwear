using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.UI.ViewModels;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace Grzymska.EpicFootwear.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DataProvider _provider;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            string DAO_Name = ConfigurationManager.AppSettings["DAO_Name"];
            if (DAO_Name != null)
            {
                try
                {
                    _provider = new DataProvider(DAO_Name);
                }
                catch(FileNotFoundException) 
                {
                    MessageBox.Show($"Library file named {DAO_Name}.dll was not found!", "No dll file error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                }
            }

            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateShoeListViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore,
                                                new NavigationService(_navigationStore, CreateShoeListViewModel),
                                                new NavigationService(_navigationStore, CreateBrandListViewModel))
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private ShoeListViewModel CreateShoeListViewModel()
        {
            return new ShoeListViewModel(_provider, new NavigationService(_navigationStore, CreateShoeViewModel));
        }

        private ShoeViewModel CreateShoeViewModel()
        {
            return new ShoeViewModel(_provider, new NavigationService(_navigationStore, CreateShoeListViewModel));
        }

        private BrandListViewModel CreateBrandListViewModel()
        {
            return new BrandListViewModel(_provider, new NavigationService(_navigationStore, CreateBrandViewModel));
        }

        private BrandViewModel CreateBrandViewModel()
        {
            return new BrandViewModel(_provider, new NavigationService(_navigationStore, CreateBrandListViewModel));
        }

    }
}
