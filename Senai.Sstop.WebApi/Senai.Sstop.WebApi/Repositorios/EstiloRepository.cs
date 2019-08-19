using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositorios
{
    public class EstiloRepository
    {

        //aonde que será feita essa comunicação
        private string StringConexao = "Data Source=.\\SqlExpress;Intial Catalog=T_SStop;User Id=sa;Pwd=132;";

    
        public List<EstiloDomain> Listar()
        {
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            //chamar o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdE, Nome FROM Estilos";

                //abrir a conexao
                con.Open();

                //declaro para percorrera lista
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    //pegar os valores da tabela do banco e armazenar dentro da aplicação do backend
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(sdr["IdE"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                            }
                }
            }

            //executar o select
            //retornar as informações
            return estilos;
        }
        
    }
}

