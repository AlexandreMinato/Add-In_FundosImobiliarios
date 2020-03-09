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
        public string PercentualUltimoYeld { get; set; }//TODO: Tipar
        public string TipoFundoB3 { get; set; }
        public string TipoFundoAnbima { get; set; }
        public DateTime DataRegistroCVM { get; set; }
        public string UltimoPagamento { get; set; } //TODO: Tipar
        public string Cotacao { get; set; }//TODO: Tipar
        public string PatrimonioFundo { get; set; }//TODO: Tipar
        public string CNPJ { get; set; }
        public string TotalCotas { get; set; }//TODO: Tipar
        public string TotalCotistas { get; set; }//TODO: Tipar

        public string PatrimonioPorCota { get; set; }//TODO: Tipar

    }
}
