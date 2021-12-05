using DAL;
using SistemaBebidas.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Controle
{
    public class PessoaControle
    {
       public void Salvar(Pessoa p)
        {
            try
            {
                DaoPessoa dao = new DaoPessoa();
                dao.Salvar(p);
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
                DaoPessoa dao = new DaoPessoa();
                return dao.BuscarTodos();

            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<Departamento> BuscarSetores()
        //{
        //    try
        //    {
        //        DaoDepartamentodao = new DaoDepartamento();
        //        return dao.BuscarTodos();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public void Remover(int codigo)
        {
            try
            {
                DaoPessoa dao = new DaoPessoa();
                dao.Remover(codigo);
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
                DaoPessoa dao = new DaoPessoa();
                return dao.BuscarPorCodigo(codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object BuscarSetores()
        {
            throw new NotImplementedException();
        }
    }
}