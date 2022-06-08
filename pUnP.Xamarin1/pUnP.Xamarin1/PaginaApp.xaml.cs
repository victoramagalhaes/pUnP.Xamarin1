using Newtonsoft.Json;
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
            PuxarInformacaoTempo();
        }
        public void DataHoje()
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            // DateTime DataAgora = DateTime.Today.ToLocalTime();
            DateTime DataAgora = DateTime.Now;
            ExibirData.Text = DataAgora.ToString("D", cultura).ToUpper();
        }
        private async void PuxarInformacaoTempo()
        {
            var url = "https://api.openweathermap.org/data/2.5/weather?q=Natal,BR&lang=pt_br&units=metric&appid=7c32dbd1ba5c0101dca82d5f45264953";
            var resultado = await ApiCaller.Get(url);
            if (resultado.Successful)
            {
                try
                {
                    var infoTempo = JsonConvert.DeserializeObject<WeatherInfo>(resultado.Response);
                        cidadepais.Text = $"{infoTempo.name.ToString().ToUpper()}/{infoTempo.sys.country.ToString().ToUpper()}";
                        tipodeclima.Text = infoTempo.weather[0].description.ToUpper();
                        minmax.Text = $"MIN { infoTempo.main.temp_min.ToString("0").ToUpper() } °C | MÁX {infoTempo.main.temp_max.ToString("0").ToUpper()} °C";
                        temperatura.Text = $"{infoTempo.main.temp.ToString("0").ToUpper()}°";
                        umidade.Text = $" {infoTempo.main.humidity.ToString().ToUpper()} %";
                        vento.Text = $" {infoTempo.wind.speed.ToString().ToUpper()} m/s";
                        pressao.Text = $"{infoTempo.main.pressure.ToString().ToUpper()} hPa";
                        nuvens.Text = $"{infoTempo.clouds.all.ToString().ToUpper()} %";
                        imgClima.Source = $"https://res.cloudinary.com/dcn3c3t3q/image/upload/APPUNP/{infoTempo.weather[0].icon.ToString()}";
                        
                        Title = "VER OUTRAS CIDADES";
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.ToString(), "OK");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Nenhuma informação encontrada", "OK");
            }
        }
    }
}