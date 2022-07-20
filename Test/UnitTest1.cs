using IntelitraderAPI.Controllers;
using IntelitraderAPI.Domains;
using IntelitraderAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void TesteCadastro()
        {
            var logger = new Mock<ILogger<UsuarioController>>();
            var controlador = new UsuarioController(logger.Object);

            CadastroViewModel novoUsuario = new();
            novoUsuario.firstName = "Primeiro";
            novoUsuario.surname = "Teste";
            novoUsuario.age = 7;

            var resultado = controlador.Cadastrar(novoUsuario);
            ObjectResult? resultadoAcao = resultado as ObjectResult;
            if (resultadoAcao != null)
            {
                Assert.Equal(201, resultadoAcao.StatusCode);
            }
        }

        [Fact]
        public void TesteListagem()
        {
            var logger = new Mock<ILogger<UsuarioController>>();
            var controlador = new UsuarioController(logger.Object);

            var resultado = controlador.Listar();
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void TesteAtualizacao()
        {
            var logger = new Mock<ILogger<UsuarioController>>();
            var controlador = new UsuarioController(logger.Object);

            AtualizarViewModel usuarioAtualizado = new();
            usuarioAtualizado.firstName = "Primeiro";
            usuarioAtualizado.surname = "Teste";
            usuarioAtualizado.age = 7;

            var resultado = controlador.Atualizar("1eefCL", usuarioAtualizado);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void TesteExclusao()
        {
            var logger = new Mock<ILogger<UsuarioController>>();
            var controlador = new UsuarioController(logger.Object);

            var resultado = controlador.Excluir("eQ5uTP");
            Assert.IsType<NoContentResult>(resultado);
        }
    }
}