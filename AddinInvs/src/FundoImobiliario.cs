//using AddinInvs.src.Model;
//using HtmlAgilityPack;
//using Minato.AddinInvestidor.Util;
//using System;
//using System.Configuration;
//using System.Linq;

//namespace Minato.AddinInvestidor
//{
//    public static class FundoImobiliario
//    {
//        /// <summary>
//        /// Metodo responsável por executar o Crawler da página
//        /// </summary>
//        /// <param name="B3Code">Código da B3</param>
//        /// <returns>Instancia preenchida com informações do fundo.</returns>
//        private static SiteFIIModel RunCrawler(string B3Code)
//        {
//            var urlSite = ConfigurationManager.AppSettings["url.site.fii"];
//            var url = $"{urlSite}{B3Code}";
//            var document = new HtmlDocument();
//            document.getHtlmDocument(url);

//            var fund = new SiteFIIModel();

//            var indices = document.GetElementbyId("informations--indexes")
//                .Descendants("span")
//                .Where(node => node.GetAttributeValue("class", "").Equals("value")).ToList();

//            fund.PercentualUltimoYeld = indices[0].InnerText; //TODO: tratar parse
//            fund.UltimoPagamento = indices[1].InnerText;//TODO: tratar parse
//            fund.PatrimonioFundo = indices[2].InnerText;//TODO: tratar parse
//            fund.PatrimonioPorCota = indices[3].InnerText;//TODO: tratar parse


//            var quote = document.DocumentNode.Descendants("div")
//                .First(p => p.GetAttributeValue("class", "").Equals("item quotation"))
//                .Descendants("span")
//                .Where(p => p.GetAttributeValue("class", "").Equals("value"))
//                .First().InnerText;
//            fund.Cotacao = quote;//TODO: tratar parse

//            var basicInformation = document.GetElementbyId("informations--basic")
//                .Descendants("div")
//                .Where(node => node.GetAttributeValue("class", "").Equals("row")).ToList();


//            var firstRow = basicInformation.First()
//                .Descendants("div")
//                .Where(p => p.GetAttributeValue("class", "").Equals("item")).ToList();


//            fund.Codigo = B3Code;
//            fund.NomeFundo = firstRow[0].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
//            fund.TipoFundoB3 = firstRow[1].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
//            fund.TipoFundoAnbima = firstRow[2].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
//            fund.DataRegistroCVM = DateTime.Parse(firstRow[3].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText);


//            var lastRow = basicInformation.Last()
//                .Descendants("div")
//                .Where(p => p.GetAttributeValue("class", "").Equals("item")).ToList();

//            fund.CNPJ = lastRow[2].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;

//            //TODO: tratar parse
//            fund.TotalCotas = lastRow[0].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;
//            fund.TotalCotistas = lastRow[1].Descendants("span").Where(p => p.GetAttributeValue("class", "").Equals("value")).First().InnerText;

//            return fund;

//        }

//        /// <summary>
//        /// Metodo responsavel por invocar o Cache (ou preenche-lo) e serve como facade para o Crawler.
//        /// </summary>
//        /// <param name="B3Code">Código da bovespa</param>
//        /// <returns>Instacia do cache preenchida</returns>
//        internal static SiteFIIModel GetCachedInformation(string B3Code)
//        {
//            return Usefull.GetCache<SiteFIIModel>(() => RunCrawler(B3Code), B3Code);
//        }
//    }
//}
