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
    public partial class Cadastro : ContentPage
    {
        private ApiService _service = new ApiService();
        public Cadastro()
        {
            InitializeComponent();
            Botao.Clicked += Botao_Clicked;
        }
        private void Botao_Clicked(object sender, EventArgs e)
        {
            if (FirstName.Text != null & Age.Text != null)
            {
                _service.CriaUsuario(FirstName.Text, SurName.Text, Convert.ToInt32(Age.Text));
                Resposta.Text = "Usuário cadastrado com sucesso";
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                Resposta.Text = "FirstName e Age são Campos obrigatórios";
            }

        }
    }
}