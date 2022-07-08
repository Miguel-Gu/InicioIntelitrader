using InteliAPI.Domains;
using InteliAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        UsuarioModel usuarioModel = new();

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                usuarioModel.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception error)
            {
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
                usuarioModel.Atualizar(id, usuarioAt);
                return StatusCode(204);
            }
            catch (Exception error)
            {
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
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Erro ao excluir usuário",
                    error
                });
            }
        }
    }
}
