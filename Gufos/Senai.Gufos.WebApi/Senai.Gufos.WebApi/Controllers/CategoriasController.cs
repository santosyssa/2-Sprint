using Microsoft.AspNetCore.Authorization;
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

    public class CategoriasController : ControllerBase
    {

        CategoriaRepository CategoriaRepository = new CategoriaRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categorias"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Cadastrar(Categorias categorias)
        {
            try
            {
                CategoriaRepository.Cadastrar(categorias);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Cago no pau, veado" + ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias Categoria = CategoriaRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriaRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                //pesquisar uma categoria
                Categorias CategoriaBuscada = CategoriaRepository.BuscarPorId
                    (categoria.IdCategoria);
                //caso nao encontre, not found
                if (CategoriaBuscada == null)
                    return NotFound();
                //caso contratio, se ela for encontrada, eu atualizo pq eu want
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oh Aba" });
            }
        }

    }
}
