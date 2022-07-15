using IntelitraderAPI.Controllers;
using IntelitraderAPI.Domains;
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

            Usuario novoUsuario = new();
            novoUsuario.FirstName = "Primeiro";
            novoUsuario.Surname = "Teste";
            novoUsuario.Age = 7;

            var resultado = controlador.Cadastrar(novoUsuario);
            ObjectResult resultadoAcao = resultado as ObjectResult;
            Assert.Equal(201, resultadoAcao.StatusCode);
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

            Usuario usuarioAtualizado = new();
            usuarioAtualizado.FirstName = "Terceiro";
            usuarioAtualizado.Surname = "Teste";
            usuarioAtualizado.Age = 14;

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