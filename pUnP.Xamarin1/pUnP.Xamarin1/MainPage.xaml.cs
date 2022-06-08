using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pUnP.Xamarin1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (EntrySenha.IsPassword == true)
            {
                EntrySenha.IsPassword = false;
            }
            else
            {
                EntrySenha.IsPassword = true;
            }
        }

        private void EsqueciSenha_Clicked(object sender, EventArgs e)
        {
        }

        private void BotaoRegistro_Clicked(object sender, EventArgs e)
        {

        }

        private void BotaoLogin_Clicked(object sender, EventArgs e)
        {
            if (EntryUsuario.Text == null || EntryUsuario.Text == "" && EntrySenha.Text == null || EntrySenha.Text == "")
            {
                DisplayAlert("Erro", "Usuário e Senha não preenchido corretamente", "Ok");
            }
            else if (EntryUsuario.Text == null || EntryUsuario.Text == "")
            {
                DisplayAlert("Erro", "Usuario não preenchido corretamente", "Ok");
            }
            else if (EntrySenha.Text == null || EntrySenha.Text == "")
            {
                DisplayAlert("Erro", "Senha não preenchida corretamente", "Ok");
            }
            else if (EntryUsuario.Text == "admin" && EntrySenha.Text == "123")
            {
                Navigation.PushAsync(new PaginaApp());
            }
            else
            {
                DisplayAlert("Erro", "Usuário ou Senha não preenchida corretamente", "Ok");
            }
        }
    }
}
