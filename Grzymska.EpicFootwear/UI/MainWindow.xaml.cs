using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grzymska.EpicFootwear.BLC;
using System.Configuration;

namespace Grzymska.EpicFootwear.UI
{
    public partial class MainWindow : Window
    {
        static public DataProvider Provider;

        public MainWindow()
        {
            InitializeComponent();

            string DAO_Name = ConfigurationManager.AppSettings["DAO_Name"];
            if( DAO_Name != null )
            {
                Provider = new DataProvider(DAO_Name);
            }
        }
    }
}