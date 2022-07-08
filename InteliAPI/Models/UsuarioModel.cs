using InteliAPI.Contexts;
using InteliAPI.Controllers;
using InteliAPI.Domains;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteliAPI.Models
{
    public class UsuarioModel
    {
        readonly IntelitraderContext ctx = new();
        public void Cadastrar(Usuario novoUsuario)
        {
            if (novoUsuario != null)
            {
                novoUsuario.Id = GeraId();
                ctx.Usuarios.Add(novoUsuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public void Atualizar(string id, Usuario usuarioAt)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.FirstName = usuarioAt.FirstName;
                usuarioBuscado.Surname = usuarioAt.Surname;
                usuarioBuscado.Age = usuarioAt.Age;
                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public void Excluir(string id)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                ctx.Usuarios.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(string id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Id == id);
        }

        public string GeraId()
        {
            bool existe = true;
            var chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var random = new Random();
            List<Usuario> lista = Listar();
            string id = "";

            do
            {
                var result = new string(
                    Enumerable.Repeat(chars, 6)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                foreach (Usuario usuario in lista)
                {
                    if (result != usuario.Id)
                    {
                        existe = false;
                        id = result;
                    }
                    else
                    {
                        existe = true;
                    }
                }
            } while (existe);

            return id;
        }
    }
}
