using AddinInvs.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinInvs.src.Model
{
    public class SiteFIIModel : DadosBase
    {
       
        public string TipoFundoAnbima { get; set; }
        public DateTime DataRegistroCVM { get; set; }
        
        public string Cotacao { get; set; }//TODO: Tipar
        public string PatrimonioFundo { get; set; }//TODO: Tipar
        public string CNPJ { get; set; }
        public string TotalCotas { get; set; }//TODO: Tipar
        public string TotalCotistas { get; set; }//TODO: Tipar

        public string PatrimonioPorCota { get; set; }//TODO: Tipar

    }
}
