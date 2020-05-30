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
        
        
        public double PatrimonioFundo { get; set; }//TODO: Tipar
        public string CNPJ { get; set; }
        public double TotalCotas { get; set; }//TODO: Tipar
        public double TotalCotistas { get; set; }//TODO: Tipar

        public double PatrimonioPorCota { get; set; }//TODO: Tipar

    }
}
