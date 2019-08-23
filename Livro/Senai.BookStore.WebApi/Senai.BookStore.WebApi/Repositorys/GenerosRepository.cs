using Senai.BookStore.WebApi.Domians;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositorys
{
    public class GenerosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";

        public List<GenerosDomain> Listar()
        {
            List<GenerosDomain> generos = new List<GenerosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Descricao FROM Generos";

                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GenerosDomain genero = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Descricao = sdr["Descricao"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
    }
}
