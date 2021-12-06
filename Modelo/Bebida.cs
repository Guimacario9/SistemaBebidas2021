﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Bebida
    {
        public int Codigo { get; set; }
        public int CodPessoa { get; set; }
        public int CodDistribuicao { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string Produto { get; set; }
        public string Quantidade { get; set; }
        public string TipoTamanho { get; set; }
        
        

        #region CAMPOS AUXILIARES
        public string NomeSetor { get; set; }
        public string PessoaFisica { get; set; }
        public string PessoaJuridica { get; set; }
        public string Cidade { get; set; }
        #endregion
    }
}
