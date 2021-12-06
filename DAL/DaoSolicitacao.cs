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
    public class DaoSolicitacao : Dao
    {
        public void Salvar(Solicitacao s)
        {
            try
            {
                using (SqlCommand cmd = CriarComando("PROC_I_SolicitacaoBebida", CommandType.StoredProcedure))
                {
                    SqlParameter par2 = new SqlParameter("codBebida", s.CodBebida);
                    SqlParameter par3 = new SqlParameter("codSolicitante", s.CodSolicitante);
                    SqlParameter par4 = new SqlParameter("data", s.DataVenda);
                    

                    cmd.Parameters.Add(par2);
                    cmd.Parameters.Add(par3);
                    cmd.Parameters.Add(par4);
                    

                    SqlParameter parBebidas = new SqlParameter();
                    parBebidas.ParameterName = "bebidas";

                    parBebidas.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(parBebidas);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Solicitacao BuscarPorCodigo(int codigo)
        {
            try
            {
                using (SqlCommand cmd = CriarComando("PROC_S_BuscarSolicitacaoPorCodigo", CommandType.StoredProcedure))
                {
                    Solicitacao s = new Solicitacao();
                    cmd.Parameters.Add(new SqlParameter("codigo", codigo));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            s.Codigo = int.Parse(reader["codigo"].ToString());
                            s.CodBebida = int.Parse(reader["CodBebida"].ToString());
                            s.CodSolicitante = int.Parse(reader["CodSolicitante"].ToString());

                            s.DataVenda = DateTime.Parse(reader["DataVenda"].ToString());
                            
                            
                        }

                        if (reader.NextResult())
                        {
                            s.Empresa = new List<Empresa>();
                            while (reader.Read())
                            {
                                Bebida p = new Bebida();
                                p.Codigo = int.Parse(reader["codigo"].ToString());
                                p.CodPessoa = int.Parse(reader["CodPessoa"].ToString());
                                p.CodDistribuicao = int.Parse(reader["CodSolicitacao"].ToString());
                                p.Nome = reader["Nome"].ToString();

                                s.Empresa.Add(p);
                            }
                        }

                    }

                    return s;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Solicitacao> BuscarTodasSolicitacoes()
        {
            try
            {

                List<Solicitacao> resultado = new List<Solicitacao>();

                using (SqlCommand cmd = CriarComando("PROC_S_BuscarTodasSolicitacoes", CommandType.StoredProcedure))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Solicitacao p = new Solicitacao();
                            p.Codigo = int.Parse(reader["codigo"].ToString());
                            p.CodBebida = int.Parse(reader["CodBebida"].ToString());
                            p.CodSolicitante = int.Parse(reader["CodSolicitante"].ToString());

                            p.DataVenda = DateTime.Parse(reader["DataVenda"].ToString());
                           

                            resultado.Add(p);
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

        private DataTable criarEstruturaPassageiros(List<Bebida> lista)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("codigo", typeof(int));
                dt.Columns.Add("codPessoa", typeof(int));
                dt.Columns.Add("codSolicitacao", typeof(int));

                foreach (Bebida item in lista)
                {
                    DataRow row = dt.NewRow();
                    row["codigo"] = item.Codigo;
                    row["codPessoa"] = item.CodPessoa;
                    row["codSolicitacao"] = item.CodDistribuicao;

                    dt.Rows.Add(row);
                }

                return dt;
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

