using Microsoft.EntityFrameworkCore;
using Senai.AutoPeças.WebApi.Domains;
using Senai.AutoPeças.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPeças.WebApi.Repositores
{
    public class PecaRepository : IPecasRepository
    {
        AutoPecasContext ctx = new AutoPecasContext();

        public void Atualizar(Pecas peca)
        {
            Pecas PecaProcurada = ctx.Pecas.FirstOrDefault(x => x.IdPecas == peca.IdPecas);
            PecaProcurada.CodigoPeca = peca.CodigoPeca;
            PecaProcurada.Descricao = peca.Descricao;
            PecaProcurada.Peso = peca.Peso;
            PecaProcurada.PrecoCusto = peca.PrecoCusto;
            PecaProcurada.PrecoVenda = peca.PrecoVenda;
            PecaProcurada.IdFornecedor = peca.IdFornecedor;
            ctx.Pecas.Update(PecaProcurada);
            ctx.SaveChanges();
        }

        public Pecas BuscarPorId(int id)
        {
            Pecas peca = ctx.Pecas.FirstOrDefault(x => x.IdPecas == id);
            return peca;
        }

        public void Cadastrar(Pecas peca)
        {
            ctx.Pecas.Add(peca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pecas peca = ctx.Pecas.Find(id);
            ctx.Pecas.Remove(peca);
            ctx.SaveChanges();
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Include(x => x.IdFornecedorNavigation).ToList();
            }
        }
    }
}
