using AddinInvs.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinInvs.src.Model
{
    public class RankingModel : DadosBase
    {

        public string Setor { get; set; }
        public string PrecoAtual { get; set; }
        public string LiquidezDiaria { get; set; }
        public string Dividendo { get; set; }
        public string DividendYeld { get; set; }
        public string DY_3M { get; set; }
        public string DY_6M { get; set; }
        public string DY_12M { get; set; }

        public string DY_3M_Media { get; set; }
        public string DY_6M_Media { get; set; }
        public string DY_12M_Media { get; set; }
        public string DY_ano { get; set; }
        public string variacao_preco { get; set; }
        public string rentabiliade_Periodo { get; set; }
        public string rentabiliade_Acumulada { get; set; }
        public string Patrimonio_Liquido { get; set; }
        public string VPA { get; set; }
        public string P_VPA { get; set; }
        public string DY_Patrimonial { get; set; }
        public string Variacao_Patrimonial { get; set; }
        public string rentabilidade_patrimonio_Periodo { get; set; }
        public string rentabilidade_patrimonio_Acumulada { get; set; }
        public string Vacancia_fisica { get; set; }
        public string Vacancia_financeria { get; set; }
        public string qt_Ativos { get; set; }


    }
}
