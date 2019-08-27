﻿using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositorys
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }

        public Estilos BuscarPorId (int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Atualizar (Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);

                EstiloBuscado.Nome = estilo.Nome;

                //insert - add, delete - remove, update -update
                ctx.Estilos.Update(EstiloBuscado);

                //efetivar
                ctx.SaveChanges();
            }

        }

        public void Deletar (int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos Estilo = ctx.Estilos.Find(id);
                
                ctx.Estilos.Remove(Estilo);
                
                ctx.SaveChanges();
            }
        }
    }
}
