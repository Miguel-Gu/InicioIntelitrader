using IntelitraderAPI.Domains;
using IntelitraderAPI.Models;
using IntelitraderAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntelitraderAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }
        private readonly UsuarioModel usuarioModel = new();

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(CadastroViewModel novoUsuario)
        {
            try
            {
                Usuario usuarioCadastrado = usuarioModel.Cadastrar(novoUsuario.firstName, novoUsuario.surname, novoUsuario.age);
                _logger.LogInformation("Usuario " + usuarioCadastrado.FirstName + " Cadastrado");
                return StatusCode(201, usuarioCadastrado);
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao cadastrar usuário. FirstName, Surname e age são campos obrigatórios");
                return BadRequest(new
                {
                    mensagem = "Erro ao cadastrar usuário. FirstName, Surname e age são campos obrigatórios",
                    error
                });
            }
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(usuarioModel.Listar());
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao listar usuários");
                return BadRequest(new
                {
                    mensagem = "Erro ao listar usuários",
                    error
                });
            }
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, AtualizarViewModel usuarioAtualizado)
        {
            try
            {
                Usuario? usuario = usuarioModel.Atualizar(id, usuarioAtualizado.firstName, usuarioAtualizado.surname, usuarioAtualizado.age);
                _logger.LogInformation("Usuario " + id + " Atualizado");
                return Ok(usuario);
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao atualizar usuário");
                return BadRequest(new
                {
                    mensagem = "Erro ao atualizar usuário",
                    error
                });
            }
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Excluir(string id)
        {
            try
            {
                usuarioModel.Excluir(id);
                _logger.LogInformation("Usuario  " + id + " Deletado");
                return NoContent();
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao excluir usuário");
                return BadRequest(new
                {
                    mensagem = "Erro ao excluir usuário",
                    error
                });
            }
        }
    }
}
