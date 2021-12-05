using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace DAL
{
    public class DaoSetor : Dao
    {
        public void Salvar(Setor s)
        {
            try
            {

                using (SqlCommand cmd = CriarComando("PROC_IU_Setor", CommandType.StoredProcedure))
                {
                    SqlParameter par1 = new SqlParameter("nome", s.Nome);
                    SqlParameter par2 = new SqlParameter("codGerente", s.CodGerente);
                    SqlParameter par3 = new SqlParameter("codigo", s.Codigo);
                    
                    cmd.Parameters.Add(par1);
                    cmd.Parameters.Add(par2);
                    cmd.Parameters.Add(par3);

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remover(int codigo)
        {
            try
            {
                using (SqlCommand cmd = CriarComando("PROC_U_RemoverSetor", CommandType.StoredProcedure))
                {
                    cmd.Parameters.Add(new SqlParameter("codigo", codigo));
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Setor> BuscarTodos()
        {
            try
            {

                List<Setor> resultado = new List<Setor>();

                using (SqlCommand cmd = CriarComando("PROC_S_BuscarTodosSetores", CommandType.StoredProcedure))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Setor s = new Setor();
                            s.Codigo = int.Parse(reader["codigo"].ToString());
                            s.CodGerente = int.Parse(reader["codGerente"].ToString());
                            s.Nome = reader["nome"].ToString();
                            s.NomeGerente = reader["nomeGerente"].ToString();
                            resultado.Add(s);
                        }
                    }
                }

                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
