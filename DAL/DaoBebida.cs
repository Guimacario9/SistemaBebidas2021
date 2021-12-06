using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DaoBebida
    {
        public void Salvar(Bebida v)
        {
            try
            {

                using (SqlCommand cmd = CriarComando("PROC_IU_Bebida", CommandType.StoredProcedure))
                {
                    SqlParameter par1 = new SqlParameter("Nome", v.Nome);
                    SqlParameter par2 = new SqlParameter("Produto", v.Produto);
                    SqlParameter par3 = new SqlParameter("Valor", v.Valor);
                    SqlParameter par4 = new SqlParameter("Quantidade", v.Quantidade);
                    SqlParameter par5 = new SqlParameter("TipoTamanho", v.TipoTamanho);
                    SqlParameter par6 = new SqlParameter("codigo", v.Codigo);

                    cmd.Parameters.Add(par1);
                    cmd.Parameters.Add(par2);
                    cmd.Parameters.Add(par3);
                    cmd.Parameters.Add(par4);
                    cmd.Parameters.Add(par5);
                    cmd.Parameters.Add(par6);

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bebida BuscarPorCodigo(int codigo)
        {
            try
            {

                List<Bebida> resultado = new List<Bebida>();

                using (SqlCommand cmd = CriarComando("PROC_S_BuscarPorCodigo", CommandType.StoredProcedure))
                {

                    cmd.Parameters.Add(new SqlParameter("codigo", codigo));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Bebida v = new Bebida();

                        if (reader.Read())
                        {
                            v.Codigo = int.Parse(reader["codigo"].ToString());
                            v.Nome = reader["Nome"].ToString();
                            v.Produto = reader["Produto"].ToString();
                            v.Valor = reader["Valor"].ToString();
                            v.Quantidade = reader["Quantidade"].ToString();
                            v.TipoTamanho = reader["TipoTamanho"].ToString();
                            
                        }

                        return v;
                    }
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
                using (SqlCommand cmd = CriarComando("PROC_U_RemoverBebida", CommandType.StoredProcedure))
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

        public List<Bebida> BuscarTodos()
        {
            try
            {

                List<Bebida> resultado = new List<Bebida>();
                using (SqlCommand cmd = CriarComando("PROC_S_BuscarTodosBebida", CommandType.StoredProcedure))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bebida v = new Bebida();
                            v.Codigo = int.Parse(reader["codigo"].ToString());
                            v.Nome = reader["Nome"].ToString();
                            v.Produto = reader["Produto"].ToString();
                            v.Valor = reader["Valor"].ToString();
                            v.Quantidade = reader["Quantidade"].ToString();
                            v.TipoTamanho = reader["TipoTamanho"].ToString(); ;

                            resultado.Add(v);
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
