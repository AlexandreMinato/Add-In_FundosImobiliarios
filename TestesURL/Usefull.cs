
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace TestesURL
{
    public static class Usefull
    {

        public enum InfoType
        {
            QUOTE,
            YELD
        }


        public static string UppercaseFirst(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            char[] a = s.ToLower().ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        internal static T GetCache<T>(Func<T> func, string key) where T : class
        {
            ObjectCache cache = MemoryCache.Default;

            key = string.Format("{0}.{1}", func.Method.Name, key);

            T cachedItem = cache[key] as T;

            if (cachedItem == null)
            {
                cachedItem = func();
                cache.Set(key, cachedItem, DateTime.Now.AddMinutes(5), null);
            }
            return cachedItem;




        }
        internal static string RemoveGoogleTAG(this string conteudo)
        {
            return conteudo.Replace("(adsbygoogle=window.adsbygoogle||[]).push({});", "", true, CultureInfo.CurrentCulture);
        }

        internal static string RemoveHtmlTAGs(this string conteudo)
        {
            return Regex.Replace(conteudo, @"<[^>]*>", String.Empty).Replace("\n",String.Empty, true, CultureInfo.CurrentCulture);
        }

        internal static string GetHtml(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            req.Method = "GET";

            using (HttpWebResponse WebResp = (HttpWebResponse)req.GetResponse())
            {
                Stream stream = WebResp.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        internal static dynamic GetContent(string url)
        { 
            return GetHtml(url)
                .RemoveGoogleTAG()
                .RemoveHtmlTAGs();
        }

        internal static dynamic GetValue(string content, string KeyStart, string KeyEnd)
        {
            string resultadoConsulta = null;

            try
            {

                bool startDelimiter = true;
                bool endDelimiter = true;

                
                    startDelimiter = true;
                    endDelimiter = true;
                    //Verifico a posição inicial de acordo com a chave.
                    var posicaoInicio = content.IndexOf(KeyStart, StringComparison.InvariantCultureIgnoreCase) + KeyStart.Length;

                    if (posicaoInicio == -1)
                        startDelimiter = false;

                    if (startDelimiter)
                    {
                        //Filtro o conteúdo de acordo com a posição inicial.
                        var conteudoFiltrado = content.Substring(posicaoInicio);

                        var posicaoFinal = conteudoFiltrado.IndexOf(KeyEnd, StringComparison.InvariantCultureIgnoreCase);

                        //Verifico se a chave final foi encontrada.
                        if (posicaoFinal == -1)
                            endDelimiter = false;

                        if (startDelimiter && endDelimiter)
                            return conteudoFiltrado.Substring(0, posicaoFinal);


                    }
                
                return "Informação não encontrada.";

            }


            catch (Exception)
            {
                resultadoConsulta = "Erro ao obter os dados";
                return resultadoConsulta;
            }
        }




    }
}
