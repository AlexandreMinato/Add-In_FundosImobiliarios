using AddinInvs.src.Implementation;
using AddinInvs.src.Interfaces;
using AddinInvs.src.Model;
using ExcelDna.Integration;
using ExcelDna.IntelliSense;
using Minato.AddinInvestidor;
using Minato.AddinInvestidor.Util;

namespace Minato.AddinInvestidor
{
    /// <summary>
    /// Classe responsável pelo Facade com o Excel.
    /// </summary>
    public class InterfaceExcel : IExcelAddIn
    {
        public static ICrawler crawler;
        public static SiteFIIModel model;

        public static void Main(){}
        public void AutoOpen() 
        {
            IntelliSenseServer.Install();
            crawler = new FIISiteCrawler();
        }
        public void AutoClose() => IntelliSenseServer.Uninstall();


        [ExcelFunction(Description = "Consulta o CNPJ do fundo.")]
        public static dynamic FII_CNPJ([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).CNPJ,fundo);
        
        [ExcelFunction(Description = "Consulta a cotação do fundo.")]
        public static dynamic FII_COTACAO([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).Cotacao, fundo);


        [ExcelFunction(Description = "Consulta da data de registro na CVM.")]
        public static dynamic FII_DATA_REGISTRO_CVM([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).DataRegistroCVM, fundo);


        [ExcelFunction(Description = "Nome do fundo na Bolsa.")]
        public static dynamic FII_NOME_FUNDO([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).NomeFundo, fundo);


        [ExcelFunction(Description = "Valor total do patrimonio do fundo.")]
        public static dynamic FII_PATRIMONIO_TOTAL([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).PatrimonioFundo, fundo);


        [ExcelFunction(Description = "Valor da cota, dividindo o patrimonio pelo numero de cotas emitidas.")]
        public static dynamic FII_COTA_POR_PATRIMONIO([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).PatrimonioPorCota, fundo);


        [ExcelFunction(Description = "Percentual do rendimento x Cota do ultimo Yeld.")]
        public static dynamic FII_ULTIMO_YELD_PERCENTUAL([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).PercentualUltimoYeld, fundo);


        [ExcelFunction(Description = "Tipo de fundo na Anbima.")]
        public static dynamic FII_TIPO_FUNDO_ANBIMA([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).TipoFundoAnbima, fundo);


        [ExcelFunction(Description = "Tipo de Fundo na B3.")]
        public static dynamic FII_TIPO_FUNDO_B3([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).TipoFundoB3, fundo);

        [ExcelFunction(Description = "Quantidade de cotas total emitidas pelo fundo.")]
        public static dynamic FII_QUANTIDADE_TOTAL_COTAS([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).TotalCotas, fundo);


        [ExcelFunction(Description = "Quantidade de cotistas no fundo.")]
        public static dynamic FII_TOTAL_COTISTAS([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).TotalCotistas, fundo);

        [ExcelFunction(Description = "Valor do Ultimo pagamento.")]
        public static dynamic FII_VALOR_COTA_PATRIMONIO([ExcelArgument(Name = "Código do Fundo", Description = "Código na B3 do Fundo Imobiliário")] string fundo) =>
            Usefull.Run(() => crawler.Fill<SiteFIIModel>(fundo).UltimoPagamento, fundo);





    }
}
