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
        private const int INDICES_PERCENTUAL_ULTIMOYELD = 0;
        private const int INDICES_VALOR_ULTIMOYELD = 1;
        private const int INDICES_PATRIMONIO_FUNDO = 2;
        private const int INICES_PATRIMONIO_POR_COTA = 3;

        private const int INFORMCOES_NOME = 0;
        private const int INFORMCOES_TIPO_FUNDO = 1;
        private const int INFORMCOES_TIPO_FUNDO_ANBIMA = 2;
        private const int INFORMCOES_DATA_CRIACAO_FUNDO = 3;
        private const int INFORMCOES_TOTAL_COTAS = 0;
        private const int INFORMCOES_TOTAL_COTISTAS = 1;
        private const int INFORMCOES_CNPJ = 2;

        


        public T Fill<T>(string B3Code) where T : DadosBase, new()
        {
            return Usefull.GetCache<T>(() =>
            {
                var fund = new SiteFIIModel();
                var document = this.LoadUrl("url.site.fii", B3Code);

                var indices = document.GetElementbyId("informations--indexes")
                    .Descendants("span")
                    .Where(Usefull.PredicateFindValueClass("value")).ToList();

                fund.PercentualUltimoYeld = indices[INDICES_PERCENTUAL_ULTIMOYELD].GetValueText();
                fund.UltimoPagamento = indices[INDICES_VALOR_ULTIMOYELD].GetValueText();
                fund.PatrimonioFundo = indices[INDICES_PATRIMONIO_FUNDO].GetValueText();
                fund.PatrimonioPorCota = indices[INICES_PATRIMONIO_POR_COTA].GetValueText();


                fund.Cotacao = document.DocumentNode.Descendants("div")
                    .First(Usefull.PredicateFindValueClass("item quotation"))
                    .Descendants("span")
                    .Where(Usefull.PredicateFindValueClass("item"))
                    .First().GetValueText();
                                
                var basicInformation = document.GetElementbyId("informations--basic")
                    .Descendants("div")
                    .Where(Usefull.PredicateFindValueClass("row")).ToList();
                                

                var foundsInformation = basicInformation.First()
                    .Descendants("div")
                    .Where(Usefull.PredicateFindValueClass("item")).ToList();


                fund.Codigo = B3Code;
                fund.NomeFundo = foundsInformation[INFORMCOES_NOME].GetTextSpan();
                fund.TipoFundoB3 = foundsInformation[INFORMCOES_TIPO_FUNDO].GetTextSpan();
                fund.TipoFundoAnbima = foundsInformation[INFORMCOES_TIPO_FUNDO_ANBIMA].GetTextSpan();
                fund.DataRegistroCVM = DateTime.Parse(foundsInformation[INFORMCOES_DATA_CRIACAO_FUNDO].GetTextSpan());

                foundsInformation.Clear();

                foundsInformation = basicInformation.Last()
                    .Descendants("div")
                    .Where(Usefull.PredicateFindValueClass("item")).ToList();
                                
                fund.TotalCotas = foundsInformation[INFORMCOES_TOTAL_COTAS].GetValueSpan();
                fund.TotalCotistas = foundsInformation[INFORMCOES_TOTAL_COTISTAS].GetValueSpan();
                fund.CNPJ = foundsInformation[INFORMCOES_CNPJ].GetTextSpan();

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
