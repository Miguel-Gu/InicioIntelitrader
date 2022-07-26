using IntelitraderMobile.Model;
using IntelitraderMobile.Services;
using IntelitraderMobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IntelitraderMobile
{
    public partial class MainPage : ContentPage
    {
        private ApiService _service = new ApiService();
        public MainPage()
        {
            InitializeComponent();
            lvUsuarios.ItemsSource = _service.Listar();
        }
        async void TelaCadastro (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastro());
        }

        void RefreshView_Refreshing(object sender, EventArgs e)
        {
            lvUsuarios.ItemsSource = _service.Listar();
            myRefreshView.IsRefreshing = false;
        }
        private void Excluir_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            Usuario usuario = menuItem.CommandParameter as Usuario;
            _ = _service.Delete(usuario.id);
            Thread.Sleep(3000);
            lvUsuarios.ItemsSource = _service.Listar();
            myRefreshView.IsRefreshing = false;
        }

        private void Atualizar_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            Usuario usuario = menuItem.CommandParameter as Usuario;
            Navigation.PushAsync(new InfoUsuario(usuario));
        }
    }
}