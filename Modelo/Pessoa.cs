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
        
        public int Cpf { get; set; }
        public string TipoEstabelecimento { get; set; }
        public int CodSetor { get; set; }
        #endregion

        #region CAMPOS AUXILIARES
        public string NomeSetor { get; set; }
        public string PessoaFisica { get; set; }
        public string PessoaJuridica { get; set; }
        #endregion

    }
}

