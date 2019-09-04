using Senai.AutoPeças.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPeças.WebApi.Interfaces
{
    interface IFornecedorRepository
    {
        List<Fornecedores> Listar();

        void Cadastrar(Fornecedores fornecedor);

    }
}
