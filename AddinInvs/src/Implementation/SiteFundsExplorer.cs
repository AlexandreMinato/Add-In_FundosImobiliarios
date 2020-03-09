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
        public T Fill<T>(string B3Code) where T : DadosBase, new()
        {
            var fund = new FundsExplorerModel();
            var document = this.LoadUrl("url.site.fundsexplorer", B3Code);

            //TODO: Implementar FundsExplorer

            return fund as T;

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
