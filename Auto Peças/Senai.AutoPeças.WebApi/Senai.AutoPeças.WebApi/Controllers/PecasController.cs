using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPeças.WebApi.Domains;
using Senai.AutoPeças.WebApi.Interfaces;
using Senai.AutoPeças.WebApi.Repositores;

namespace Senai.AutoPeças.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecasRepository PecaRepository { get; set; }

        public PecasController()
        {
            PecaRepository = new PecaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarPecas()
        {
            return Ok(PecaRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPecaPorId(int id)
        {
            try
            {
                Pecas peca = PecaRepository.BuscarPorId(id);
                if (peca == null)
                    return NotFound();
                return Ok(peca);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult CadastrarPecas(Pecas peca)
        {
            try
            {
                PecaRepository.Cadastrar(peca);             
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult AtualizarPecas(Pecas peca)
        {
            try
            {
                Pecas PecaEncontrada = PecaRepository.BuscarPorId(peca.IdPecas);

                if (PecaEncontrada == null)
                    return NotFound();
                
                PecaRepository.Atualizar(peca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult DeletarPecas(int id)
        {
            PecaRepository.Deletar(id);
            return Ok();
        }
           
    }
}