using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;

namespace Controle
{
    public class BebidaController
    {
        public void Salvar(Bebida v)
        {
            try
            {
                
                if (string.IsNullOrEmpty(v.Codigo))
                    throw new Exception("É necessário preencher o Codigo");

                DaoBebida dao = new DaoBebida();
                dao.Salvar(v);
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
                DaoBebida dao = new DaoBebida();
                return dao.BuscarTodos();
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
                DaoBebida dao = new DaoBebida();
                dao.Remover(codigo);
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
                DaoBebida dao = new DaoBebida();
                Veiculo v = dao.BuscarPorCodigo(codigo);
                return v;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
