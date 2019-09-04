using Senai.Cgstore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Cgstore.WebApi.Interface
{
    interface ICategoriaRepository
    {

        List<Categorias> Listar();
        void Cadastrar(Categorias categoria);
        Categorias BuscarPorId(int id);
    }
}
