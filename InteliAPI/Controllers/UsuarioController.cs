using InteliAPI.Domains;
using InteliAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteliAPI.Controllers
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
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                usuarioModel.Cadastrar(novoUsuario);
                _logger.LogInformation("Usuario "+ novoUsuario.FirstName + " Cadastrado");
                return StatusCode(201, novoUsuario);
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao cadastrar usuario");
                return BadRequest(new
                {
                    mensagem = "Erro ao cadastrar usuário",
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
        public IActionResult Atualizar(string id, Usuario usuarioAt)
        {
            try
            {
                Usuario usuario = usuarioModel.Atualizar(id, usuarioAt);
                _logger.LogInformation("Usuario "+ id + " Atualizado");
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
                _logger.LogInformation("Usuario  "+ id + " Deletado");
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
