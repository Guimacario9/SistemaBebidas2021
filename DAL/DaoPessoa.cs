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
    public class DaoPessoa : Dao
    {
        public void Salvar(Pessoa p)
        {
            try
            {

                using (SqlCommand cmd = CriarComando("PROC_I_Pessoa", System.Data.CommandType.StoredProcedure))
                {
                    cmd.Parameters.Add(new SqlParameter("codigo", p.Codigo));
                    cmd.Parameters.Add(new SqlParameter("nome", p.Nome));
                    cmd.Parameters.Add(new SqlParameter("endereco", p.Endereco));
                    cmd.Parameters.Add(new SqlParameter("telefone", p.Telefone));
                    cmd.Parameters.Add(new SqlParameter("TipoEstabelecimento", p.TipoEstabelecimento));
                    cmd.Parameters.Add(new SqlParameter("Cpf", p.Cpf));
                    cmd.Parameters.Add(new SqlParameter("PessoaFisica", p.PessoaFisica));
                    cmd.Parameters.Add(new SqlParameter("PessoaJuridica", p.PessoaJuridica));
                    

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
                try
                {
                    using (SqlCommand cmd = CriarComando("PROC_U_RemoverPessoa", CommandType.StoredProcedure))
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
            catch (Exception)
            {
                throw;
            }
        }

        public Pessoa BuscarPorCodigo(int codigo)
        {
            try
            {

                List<Pessoa> resultado = new List<Pessoa>();

                using (SqlCommand cmd = CriarComando("PROC_S_BuscarPessoaPorCodigo", CommandType.StoredProcedure))
                {

                    cmd.Parameters.Add(new SqlParameter("codigo", codigo));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Pessoa p = new Pessoa();

                        if (reader.Read())
                        {
                            p.Codigo = int.Parse(reader["codigo"].ToString());
                            p.Nome = reader["nome"].ToString();
                            p.Endereco = reader["Endereco"].ToString();
                            p.Telefone = reader["Telefone"].ToString();
                            p.TipoEstabelecimento = reader["TipoEstabelecimento"].ToString();
                            p.PessoaJuridica = reader["PessoaJuridica"].ToString();
                            p.PessoaFisica = reader["PessoaFisica"].ToString();
                            p.Cpf = int.Parse(reader["Cpf"].ToString());
                            p.CodSetor = string.IsNullOrEmpty(reader["codSetor"].ToString()) ? 0 : int.Parse(reader["codSetor"].ToString());

                        }

                        return p;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Pessoa> BuscarTodos()
        {
            try
            {
                List<Pessoa> resultado = new List<Pessoa>();

                using (SqlCommand cmd = CriarComando("PROC_S_BuscarTodasPessoas", CommandType.StoredProcedure))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pessoa p = new Pessoa();
                            p.Codigo = int.Parse(reader["codigo"].ToString());
                            p.Nome = reader["nome"].ToString();
                            p.Endereco = reader["Endereco"].ToString();
                            p.Telefone = reader["Telefone"].ToString();
                            p.TipoEstabelecimento = reader["TipoEstabelecimento"].ToString();
                            p.PessoaJuridica = reader["PessoaJuridica"].ToString();
                            p.PessoaFisica = reader["PessoaFisica"].ToString();
                            p.Cpf = int.Parse(reader["Cpf"].ToString());
                            p.CodSetor = string.IsNullOrEmpty(reader["codSetor"].ToString()) ? 0 : int.Parse(reader["codSetor"].ToString());
                            p.NomeSetor = reader["NomeSetor"].ToString();
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
    }
}
