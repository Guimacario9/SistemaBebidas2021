using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Solicitacao
    {

        public int Codigo { get; set; }
        public int CodVeiculo { get; set; }
        public int CodSolicitante { get; set; }
        public DateTime DataSaida { get; set; }
        public bool ComMotorista { get; set; }

        public List<Passageiro> Passageiros { get; set; }
        public string ModeloVeiculo { get; set; }
        public string NomeSolicitante { get; set; }

    }
}

