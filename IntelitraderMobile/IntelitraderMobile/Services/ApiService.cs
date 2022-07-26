using IntelitraderMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntelitraderMobile.Services
{
    public class ApiService
    {
        public List<Usuario> usuarios { get; set; }
        public HttpClient _httpClient = new HttpClient();
        public List<Usuario> Listar()
        {
            var response =  _httpClient.GetStringAsync("https://67da-177-33-68-169.sa.ngrok.io/api/Usuario/Listar").Result;
            usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
            return usuarios;
        }
        public void CriaUsuario(string primeiroNome, string segundoNome, int idade)
        {
            UsuarioCadastro usuario = new UsuarioCadastro { firstName = primeiroNome, surname = segundoNome, age = idade };
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("https://67da-177-33-68-169.sa.ngrok.io/api/Usuario/Cadastrar", data);
        }
        public async Task Delete(string id)
        {
            var response = await _httpClient.DeleteAsync("https://67da-177-33-68-169.sa.ngrok.io/api/Usuario/Deletar/" + id);
        }
        public async Task Put(string id, string primeiroNome, string segundoNome, int idade)
        {
            Usuario usuario = new Usuario { firstName = primeiroNome, surname = segundoNome, age = idade };
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://67da-177-33-68-169.sa.ngrok.io/api/Usuario/Atualizar/" + id, data);
        }
    }
}