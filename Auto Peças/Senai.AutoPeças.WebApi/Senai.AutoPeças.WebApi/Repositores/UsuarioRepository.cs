using Microsoft.EntityFrameworkCore;
using Senai.AutoPeças.WebApi.Domains;
using Senai.AutoPeças.WebApi.Interfaces;
using Senai.AutoPeças.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPeças.WebApi.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        AutoPecasContext ctx = new AutoPecasContext();

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }
    }
}
