using Senai.AutoPeças.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPeças.WebApi.Interfaces
{
    interface IPecasRepository
    {
        List<Pecas> Listar();

        void Cadastrar(Pecas peca);

        void Atualizar(Pecas peca);

        void Deletar(int id);

        Pecas BuscarPorId(int id);
    }
}
