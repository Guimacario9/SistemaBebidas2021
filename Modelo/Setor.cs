using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Setor
    {

        #region Campos do Banco
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodGerente { get; set; }
        #endregion

        #region Campos Auxiliares
        public string NomeGerente { get; set; }
        #endregion
    }
}

