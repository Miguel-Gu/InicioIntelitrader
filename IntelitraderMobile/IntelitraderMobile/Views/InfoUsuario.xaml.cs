using IntelitraderMobile.Model;
using IntelitraderMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntelitraderMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoUsuario : ContentPage
    {
        private ApiService _service = new ApiService();
        private Usuario user { get; set; }
        public InfoUsuario(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = usuario;
            user = usuario;
            Botao.Clicked += Botao_Clicked;
        }
        private void Botao_Clicked(object sender, EventArgs e)
        {
            Botao.IsEnabled = false;
            Resposta.Text = "Carregando...";
            if (firstName.Text != null & age.Text != null)
            {
                _ = _service.Put(user.id, firstName.Text, surname.Text, Convert.ToInt32(age.Text));
                Resposta.Text = "Usuário atualizado com sucesso. Redirecionando...";
                Thread.Sleep(5000);
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                Resposta.Text = "FirstName e Age são Campos obrigatórios";
            }
        }
    }
}