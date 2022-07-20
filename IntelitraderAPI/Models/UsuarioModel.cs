using IntelitraderAPI.Contexts;
using IntelitraderAPI.Domains;

namespace IntelitraderAPI.Models
{
    public class UsuarioModel
    {
        readonly IntelitraderContext ctx = new();
        public Usuario Cadastrar(string firstName, string? surname, int? age)
        {
            Usuario novoUsuario = new();
            novoUsuario.FirstName = firstName;
            novoUsuario.Surname = surname;
            novoUsuario.Age = age;
            novoUsuario.Id = GeraId();
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
            return novoUsuario;

        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario? Atualizar(string id, string? firstName, string? surname, int? age)
        {
            Usuario? usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                if (firstName != null)
                {
                    usuarioBuscado.FirstName = firstName;
                }
                if (surname != null)
                {
                    usuarioBuscado.Surname = surname;
                }
                if (age != null)
                {
                    usuarioBuscado.Age = age;
                }
                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();

                return usuarioBuscado;
            }
            else
            {
                return null;
            }
        }

        public void Excluir(string id)
        {
            Usuario? usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                ctx.Usuarios.Remove(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public Usuario? BuscarPorId(string id)
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
                if (lista != null && lista.Count > 0)
                {
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
                }
                else
                {
                    existe = false;
                    id = result;
                }


            } while (existe);

            return id;
        }
    }
}
