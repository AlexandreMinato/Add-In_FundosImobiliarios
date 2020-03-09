using AddinInvs.src.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minato.AddinInvestidor.Util;
using AddinInvs.src.Model;

namespace AddinInvs.src.Implementation
{
    /// <summary>
    /// Implementação concreta do Crawler do site fiis.com.br
    /// </summary>
    public class FIISiteCrawler : ICrawler
    {
        public T Fill<T>(string B3Code) where T : DadosBase, new()
        {
            return Usefull.GetCache<T>(() =>
            {
                var fund = new SiteFIIModel();
                var document = this.LoadUrl("url.site.fii", B3Code);

                var indices = document.GetElementbyId("informations--indexes")
                    .Descendants("span")
                    .Where(node => node.GetAttributeValue("class", "").Equals("value")).ToList();

                fund.PercentualUltimoYeld = indices[0].InnerText; //TODO: tratar parse
                fund.UltimoPagamento = indices[1].InnerText;//TODO: tratar parse
                fund.PatrimonioFundo = indices[2].InnerText;//TODO: tratar parse
                fund.PatrimonioPorCota = indices[3].InnerText;//TODO: tratar parse


                var quote = document.DocumentNode.Descendants("div")
                    .First(p => p.GetAttributeValue("class", "").Equals("item quotation"))
                    .Descendants("span")
                    .Where(p => p.GetAttributeValue("class", "").Equals("value"))
                    .First().InnerText;
                fund.Cotacao = Double.Parse(quote.ClearText());//TODO: tratar parse

                var basicInformation = document.GetElementbyId("informations--basic")
                    .Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("row")).ToList();


                var firstRow = basicInformation.First()
                    .Descendants("div")
                    .Where(p => p.GetAttributeValue("class", "").Equals("item")).ToList();


                fund.Codigo = B3Code;
                fund.NomeFundo = firstRow[0].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
                fund.TipoFundoB3 = firstRow[1].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
                fund.TipoFundoAnbima = firstRow[2].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
                fund.DataRegistroCVM = DateTime.Parse(firstRow[3].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText);


                var lastRow = basicInformation.Last()
                    .Descendants("div")
                    .Where(p => p.GetAttributeValue("class", "").Equals("item")).ToList();

                fund.CNPJ = lastRow[2].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;

                //TODO: tratar parse
                fund.TotalCotas = lastRow[0].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
                fund.TotalCotistas = lastRow[1].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;

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
