using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Dao
    {

       private const string CONNECTION_STRING = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SistemaBebidas";
       

        protected SqlCommand CriarComando(string sql, System.Data.CommandType type)
        {

            try
            {
                SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = type;

                return cmd;

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
