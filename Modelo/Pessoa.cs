using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pessoa
    {

        #region CAMPOS BANCO
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public bool EFuncionario { get; set; }
        public int CodSetor { get; set; }
        #endregion

        #region CAMPOS AUXILIARES
        public string NomeSetor { get; set; }
        #endregion

    }
}

