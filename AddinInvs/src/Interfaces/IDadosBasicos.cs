using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinInvs.src.Interfaces
{
    public class DadosBase
    {
        public string Codigo { get; set; }
        public string NomeFundo { get; set; }
        public double PercentualUltimoYeld { get; set; }
        public string TipoFundoB3 { get; set; }
        public double UltimoPagamento { get; set; }
        public double Cotacao { get; set; }
        public double VariacaoCotacao { get; set; }
    }
}
