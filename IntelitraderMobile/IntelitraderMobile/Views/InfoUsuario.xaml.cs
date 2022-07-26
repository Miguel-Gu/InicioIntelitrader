using IntelitraderMobile.Model;
using IntelitraderMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntelitraderMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoUsuario : ContentPage
    {
        private ApiService _service = new ApiService();
        public InfoUsuario(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = usuario;
            Botao.Clicked += Botao_Clicked;
        }
        private void Botao_Clicked(object sender, EventArgs e)
        {
            if (firstName.Text != null & age.Text != null)
            {
                _ = _service.Put(id.Text, firstName.Text, surname.Text, Convert.ToInt32(age.Text));
                Resposta.Text = "Usuário atualizado com sucesso";
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                Resposta.Text = "FirstName e Age são Campos obrigatórios";
            }
        }
    }
}