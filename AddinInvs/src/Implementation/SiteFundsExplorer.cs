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
    class SiteFundsExplorer : ICrawler
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
                var document = this.LoadUrl("url.site.fundsexplorer", B3Code);

                var indices = document.GetElementbyId("simulation")
                        .Descendants("div")
                        .Where(node => node.GetAttributeValue("class", "").Equals("section-body")).ToList();


                var cotacao = document.GetElementbyId("stock-price").Descendants("span");

                fund.VariacaoCotacao = cotacao.First(p => p.GetAttributeValue("class", "").Contains("percentage ")).InnerText.ClearText();
                fund.Cotacao = Double.Parse(cotacao.First(p => p.GetAttributeValue("class", "").Equals("price")).InnerText.ClearText());

                fund.ComparacaoPoupanca = indices[0].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("col-md-6 col-xs-12"))
                .ToList()[1].Descendants("li").Last().Descendants("span").ToList()[1].InnerText;


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
