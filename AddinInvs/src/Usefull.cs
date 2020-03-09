using ExcelDna.Integration;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minato.AddinInvestidor.Util
{

    public static class Usefull
    {
        /// <summary>
        /// Trato de forma assincrona todas as chamadas para não travar o Excel e enquanto o metodo não retornar p
        /// </summary>
        /// <param name="func">Delegate que será executado</param>
        /// <param name="parametro">CorrelationID que utilizo para saber para qual delegate retorno o resultado da função</param>
        /// <returns></returns>
        public static dynamic Run(ExcelFunc func, string parametro)
        {
            var stackTrace = new StackTrace();
            string methodBase = stackTrace.GetFrame(1).GetMethod().Name;

            try
            {
                dynamic rt = ExcelAsyncUtil.Run(methodBase, parametro, func);

                if (rt is ExcelError)
                {
                    //Mensagem que será exibida ao usuário enquanto o delegate está sendo executado.
                    if (rt == ExcelError.ExcelErrorNA)
                        return "#Aguarde...";
                }
                return rt;

            }
            catch (Exception ex)
            {

                return "Ops, " + ex.Message;
            }
        }
        internal static void getHtlmDocument(this HtmlDocument htmlDocument, string url)
        {
            
            var httpClient = new HttpClient();

            ///Excel DNA não dá suporte para Tasks/await, então executo a task de forma sincrona aqui!'
            var html = Task.Run(() => httpClient.GetStringAsync(url));
            htmlDocument.LoadHtml(html.Result);
        }

        internal static string ClearText(this string text)
        {
            return text.Replace("R$", "").Replace("\n", "").Trim();
        }

        /// <summary>
        /// Meto que verifica se tem Cache na consulta do fundo, se tiver usa do cache, senão usa um delegate para executar o metodo e colocar o resultado no cache
        /// </summary>
        /// <typeparam name="T">Tipo de parametro</typeparam>
        /// <param name="func">delegate</param>
        /// <param name="key">chave</param>
        /// <returns>Uma instancia preenchida de '<T>'</returns>
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
        
    }
}
