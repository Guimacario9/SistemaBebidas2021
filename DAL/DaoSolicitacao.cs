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
                using (SqlCommand cmd = CriarComando("PROC_I_SolicitacaoVeiculo", CommandType.StoredProcedure))
                {
                    SqlParameter par2 = new SqlParameter("codVeiculo", s.CodVeiculo);
                    SqlParameter par3 = new SqlParameter("codSolicitante", s.CodSolicitante);
                    SqlParameter par4 = new SqlParameter("data", s.DataSaida);
                    SqlParameter par5 = new SqlParameter("comMotorista", s.ComMotorista);

                    cmd.Parameters.Add(par2);
                    cmd.Parameters.Add(par3);
                    cmd.Parameters.Add(par4);
                    cmd.Parameters.Add(par5);

                    SqlParameter parPassageiros = new SqlParameter();
                    parPassageiros.ParameterName = "passageiros";
                   
                    parPassageiros.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(parPassageiros);

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
                            s.CodVeiculo = int.Parse(reader["CodVeiculo"].ToString());
                            s.CodSolicitante = int.Parse(reader["CodSolicitante"].ToString());

                            s.DataSaida = DateTime.Parse(reader["DataSaida"].ToString());
                            s.ComMotorista = bool.Parse(reader["ComMotorista"].ToString());

                            s.ModeloVeiculo = reader["ModeloVeiculo"].ToString();
                            s.NomeSolicitante = reader["NomeSolicitante"].ToString();
                            
                        }

                        if (reader.NextResult())
                        {
                            s.Passageiros = new List<Bebida>();
                            while (reader.Read())
                            {
                                Bebida p = new Bebida();
                                p.Codigo = int.Parse(reader["codigo"].ToString());
                                p.CodPessoa = int.Parse(reader["CodPessoa"].ToString());
                                p.CodDistribuicao = int.Parse(reader["CodSolicitacao"].ToString());
                                p.Nome = reader["Nome"].ToString();

                                s.Passageiros.Add(p);
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
                            p.CodVeiculo = int.Parse(reader["CodVeiculo"].ToString());
                            p.CodSolicitante = int.Parse(reader["CodSolicitante"].ToString());

                            p.DataSaida = DateTime.Parse(reader["DataSaida"].ToString());
                            p.ComMotorista = bool.Parse(reader["ComMotorista"].ToString());

                            p.ModeloVeiculo = reader["ModeloVeiculo"].ToString();
                            p.NomeSolicitante = reader["NomeSolicitante"].ToString();

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

