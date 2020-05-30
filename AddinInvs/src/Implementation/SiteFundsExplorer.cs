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
    public class SiteFundsExplorer : ICrawler
    {
        /// <summary>
        /// Implementação concreta do site fundsexplorer.com.br
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="B3Code"></param>
        /// <returns></returns>
        public T Fill<T>(string B3Code) where T : DadosBase, new()
        {
            return Usefull.GetCache<T>(() =>
            {
                var fund = new FundsExplorerModel();
                var HtmlDocument = this.LoadUrl("url.site.fundsexplorer", B3Code);

                var indices = HtmlDocument.GetElementbyId("simulation")
                        .Descendants("div")
                        .Where(Usefull.PredicateFindValueClass("section-body"));

                var cotacao = HtmlDocument.GetElementbyId("stock-price").Descendants("span");

                fund.VariacaoCotacao = cotacao.First(p => p.GetAttributeValue("class", "").Contains("percentage ")).GetValueText();
                fund.Cotacao = cotacao.First(Usefull.PredicateFindValueClass("price")).GetValueText();

                fund.ComparacaoPoupanca = indices.First()
                .Descendants("div")
                .Where(Usefull.PredicateFindValueClass("col-md-6 col-xs-12")).ElementAt(1)
                .Descendants("li")
                .Last()
                .Descendants("span").ElementAt(1).InnerText.ClearText();


                return fund as T;


            }, B3Code);

        }

        public HtmlDocument LoadUrl(string keyUrlSite, string B3Code)
        {
            var urlSite = ConfigurationManager.AppSettings[keyUrlSite];
            var url = $"{urlSite}{B3Code}";
            var document = new HtmlDocument();
            document.getHtlmDocument(url);

            return document;
        }
    }
}
