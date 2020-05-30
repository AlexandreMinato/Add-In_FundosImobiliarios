using AddinInvs.src.Interfaces;
using AddinInvs.src.Model;
using HtmlAgilityPack;
using Minato.AddinInvestidor.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinInvs.src.Implementation
{

    
    public class FIIs_FundsExplorer_Ranking : ICrawler
    {
        public T Fill<T>(string B3Code) where T : DadosBase, new()
        {

            var lista = Usefull.GetCache<List<RankingModel>>(()=> GetRanking(), "ranking.fundos").OrderBy(p => p.Codigo);

            T retorno = lista.FirstOrDefault(p => p.Codigo == B3Code) as T;
            
            return retorno;
        }

        public HtmlDocument LoadUrl(string keyUrlSite, string B3Code = null)
        {
            var urlSite = ConfigurationManager.AppSettings[keyUrlSite];
            var url = $"{urlSite}";
            var document = new HtmlDocument();
            document.getHtlmDocument(url);

            return document;
        }

        private List<RankingModel> GetRanking()

        {

            var lista = new List<RankingModel>();
            var document = this.LoadUrl("url.site.fundsexplorer.ranking");

            var indices = document.GetElementbyId("table-ranking")
                    .Descendants("tbody").First()
                    .Descendants("tr");

            foreach (var item in indices)
            {
                lista.Add(new RankingModel()
                {
                    Codigo = item.Descendants("td").ElementAt(0).InnerText,
                    Setor = item.Descendants("td").ElementAt(1).InnerText,
                    PrecoAtual = item.Descendants("td").ElementAt(2).InnerText,
                    LiquidezDiaria = item.Descendants("td").ElementAt(3).InnerText,
                    Dividendo = item.Descendants("td").ElementAt(4).InnerText,
                    DividendYeld = item.Descendants("td").ElementAt(5).InnerText,
                    DY_3M = item.Descendants("td").ElementAt(6).InnerText,
                    DY_6M = item.Descendants("td").ElementAt(7).InnerText,
                    DY_12M = item.Descendants("td").ElementAt(8).InnerText,

                    DY_3M_Media = item.Descendants("td").ElementAt(9).InnerText,
                    DY_6M_Media = item.Descendants("td").ElementAt(10).InnerText,
                    DY_12M_Media = item.Descendants("td").ElementAt(11).InnerText,
                    DY_ano = item.Descendants("td").ElementAt(12).InnerText,
                    variacao_preco = item.Descendants("td").ElementAt(13).InnerText,
                    rentabiliade_Periodo = item.Descendants("td").ElementAt(14).InnerText,
                    rentabiliade_Acumulada = item.Descendants("td").ElementAt(15).InnerText,
                    Patrimonio_Liquido = item.Descendants("td").ElementAt(16).InnerText,
                    VPA = item.Descendants("td").ElementAt(17).InnerText,
                    P_VPA = item.Descendants("td").ElementAt(18).InnerText,
                    DY_Patrimonial = item.Descendants("td").ElementAt(19).InnerText,
                    Variacao_Patrimonial = item.Descendants("td").ElementAt(20).InnerText,
                    rentabilidade_patrimonio_Periodo = item.Descendants("td").ElementAt(21).InnerText,
                    rentabilidade_patrimonio_Acumulada = item.Descendants("td").ElementAt(22).InnerText,
                    Vacancia_fisica = item.Descendants("td").ElementAt(23).InnerText,
                    Vacancia_financeria = item.Descendants("td").ElementAt(24).InnerText,
                    qt_Ativos = item.Descendants("td").ElementAt(25).InnerText

                });


            }


            return lista;

        }
    }
}
