using Senai.AutoPeças.WebApi.Domains;
using Senai.AutoPeças.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPeças.WebApi.Interfaces
{
        public interface IUsuarioRepository
        {
            Usuarios BuscarPorEmailESenha(LoginViewModel login);

        void Cadastrar(Usuarios usuario);
        }

}
