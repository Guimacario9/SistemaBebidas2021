using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;

namespace Controle
{
    public class SolicitacaoController
    {
        public List<Pessoa> BuscarTodasPessoas()
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

        public void Salvar(Solicitacao s)
        {
            try
            {
                DaoSolicitacao dao = new DaoSolicitacao();
                dao.Salvar(s);
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
                DaoSolicitacao dao = new DaoSolicitacao();
                return dao.BuscarTodasSolicitacoes();
                
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
                DaoSolicitacao dao = new DaoSolicitacao();
                return dao.BuscarPorCodigo(codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
