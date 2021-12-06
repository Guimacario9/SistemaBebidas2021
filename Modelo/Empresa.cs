using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Empresa
    {
        #region CAMPOS DO BANCO
        public int Codigo { get; set; }
        public int CodLoja { get; set; }
        public int CodSolicitacao { get; set; }
        #endregion
        
        
        #region CAMPOS AUXILIARES
        public string Nome { get; set; }
        #endregion
    }
}
