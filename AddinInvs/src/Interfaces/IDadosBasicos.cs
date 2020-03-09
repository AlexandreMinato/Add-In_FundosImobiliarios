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
        public string PercentualUltimoYeld { get; set; }//TODO: Tipar
        public string TipoFundoB3 { get; set; }
        public string UltimoPagamento { get; set; } //TODO: Tipar
    }
}
