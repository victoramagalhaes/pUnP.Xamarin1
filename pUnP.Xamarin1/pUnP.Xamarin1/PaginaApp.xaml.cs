using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pUnP.Xamarin1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaApp : ContentPage
    {
        public PaginaApp()
        {
            InitializeComponent();
            DataHoje();
        }
        public void DataHoje()
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            // DateTime DataAgora = DateTime.Today.ToLocalTime();
            DateTime DataAgora = DateTime.Now;
            ExibirData.Text = DataAgora.ToString("D", cultura).ToUpper();
        }
    }
}