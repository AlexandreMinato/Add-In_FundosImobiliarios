using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinInvs.src.Model
{
    public class FundoImobiliarioModel
    {
        public string Codigo { get; set; }
        public string NomeFunfo { get; set; }
        public string PercentualUltimoYeld { get; set; }
        public string TipoFundoB3 { get; set; }
        public string TipoFundoAnbima { get; set; }

        public DateTime DataRegistroCVM { get; set; }
        public string UltimoPagamento { get; set; }
        public string Cotacao { get; set; }
        public string PatrimonioFundo { get; set; }
        public string CNPJ { get; set; }
        public string TotalCotas { get; set; }
        public string TotalCotistas { get; set; }
        
        public string PatrimonioPorCota { get; set; }

    }
}
