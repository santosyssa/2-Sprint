using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>();
       
        public IEnumerable<EstiloDomain> Get()
        {

            return estilos;
        }

       

        [HttpGet("{id}")]

        public IActionResult BuscarPorId (int id)
        {
            EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }

        [HttpPost]
        public IActionResult Cadastrar (EstiloDomain estiloDomain)
        {
            estilos.Add(
                new EstiloDomain
            {
                IdEstilo = estilos.Count + 1,
                Nome = estiloDomain.Nome
            }
            );
            return Ok(estilos);
        }
    }
}