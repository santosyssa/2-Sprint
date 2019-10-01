using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class EventosController : ControllerBase
    {
        //repositorio
        EventoRepository EventoRepository = new EventoRepository();

        //endpoint
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EventoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Eventos evento)
        {
            try
            {
                EventoRepository.Cadastrar(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erroooou" + ex.Message });
            }
        }
    }
}
