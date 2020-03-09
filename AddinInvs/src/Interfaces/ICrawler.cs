using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinInvs.src.Interfaces
{
    public interface ICrawler
    {
        HtmlDocument LoadUrl(string keyUrlSite, string B3Code);
        T Fill<T>(string B3Code) where T : DadosBase, new();

    }
}
