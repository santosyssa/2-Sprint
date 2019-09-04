using Senai.AutoPeças.WebApi.Domains;
using Senai.AutoPeças.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPeças.WebApi.Repositores
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public List<Fornecedores> Listar()
        {
                using (AutoPecasContext ctx = new AutoPecasContext())
                {
                    return ctx.Fornecedores.ToList();

                }
        }

        public void Cadastrar (Fornecedores fornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Fornecedores.Add(fornecedor);
                ctx.SaveChanges();
            }
        }
    }
}
