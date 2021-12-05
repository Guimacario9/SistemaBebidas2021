using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;

namespace Controle
{
    public class SetorController
    {
        public void Salvar(Setor s)
        {
            try
            {

                if (string.IsNullOrEmpty(s.Nome))
                    throw new Exception("É necessário preencher o campo Nome");

                DaoSetor dao = new DaoSetor();
                dao.Salvar(s);
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
                DaoSetor dao = new DaoSetor();
                return dao.BuscarTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Pessoa> BuscarFuncionarios()
        {
            try
            {
                DaoPessoa dao = new DaoPessoa();
                return dao.BuscarTodos().Where(x => x.EFuncionario).ToList();
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
                DaoSetor dao = new DaoSetor();
                dao.Remover(codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Setor BuscarPorCodigo(int codigo)
        {
            return BuscarTodos().Where(x => x.Codigo == codigo)
                .FirstOrDefault();
        }
    }
}
