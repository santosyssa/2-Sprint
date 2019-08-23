using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domians;
using Senai.BookStore.WebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class GenerosController : ControllerBase
    {
        GenerosRepository GenerosRepository = new GenerosRepository();


        [HttpGet]
        public IEnumerable<GenerosDomain> Listar()
        {
            return GenerosRepository.Listar();
        }
    }
}
