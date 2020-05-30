using AddinInvs.src.Implementation;
using AddinInvs.src.Interfaces;
using ExcelDna.Integration;
using Minato.AddinInvestidor.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinInvs.src
{

    public partial class InterfaceExcel
    {
        public static ICrawler crawlerRanking = new FIIs_FundsExplorer_Ranking();
        
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_SETOR([ExcelArgument(Name = "SETOR", Description = "SETOR")] string fundo) =>
           Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).Setor, fundo);

        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_LIQUIDEZDIARIA([ExcelArgument(Name = "LIQUIDEZDIARIA", Description = "LIQUIDEZDIARIA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).LiquidezDiaria, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DIVIDENDO([ExcelArgument(Name = "DIVIDENDO", Description = "DIVIDENDO")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).Dividendo, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DIVIDENDYELD([ExcelArgument(Name = "DIVIDENDYELD", Description = "DIVIDENDYELD")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DividendYeld, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_3M([ExcelArgument(Name = "DY_3M", Description = "DY_3M")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_3M, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_6M([ExcelArgument(Name = "DY_6M", Description = "DY_6M")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_6M, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_12M([ExcelArgument(Name = "DY_12M", Description = "DY_12M")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_12M, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_3M_MEDIA([ExcelArgument(Name = "DY_3M_MEDIA", Description = "DY_3M_MEDIA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_3M_Media, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_6M_MEDIA([ExcelArgument(Name = "DY_6M_MEDIA", Description = "DY_6M_MEDIA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_6M_Media, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_12M_MEDIA([ExcelArgument(Name = "DY_12M_MEDIA", Description = "DY_12M_MEDIA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_12M_Media, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_ANO([ExcelArgument(Name = "DY_ANO", Description = "DY_ANO")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_ano, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_VARIACAO_PRECO([ExcelArgument(Name = "VARIACAO_PRECO", Description = "VARIACAO_PRECO")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).variacao_preco, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_RENTABILIADE_PERIODO([ExcelArgument(Name = "RENTABILIADE_PERIODO", Description = "RENTABILIADE_PERIODO")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).rentabiliade_Periodo, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_RENTABILIADE_ACUMULADA([ExcelArgument(Name = "RENTABILIADE_ACUMULADA", Description = "RENTABILIADE_ACUMULADA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).rentabiliade_Acumulada, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_PATRIMONIO_LIQUIDO([ExcelArgument(Name = "PATRIMONIO_LIQUIDO", Description = "PATRIMONIO_LIQUIDO")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).Patrimonio_Liquido, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_VPA([ExcelArgument(Name = "VPA", Description = "VPA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).VPA, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_P_VPA([ExcelArgument(Name = "P_VPA", Description = "P_VPA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).P_VPA, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_DY_PATRIMONIAL([ExcelArgument(Name = "DY_PATRIMONIAL", Description = "DY_PATRIMONIAL")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).DY_Patrimonial, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_VARIACAO_PATRIMONIAL([ExcelArgument(Name = "VARIACAO_PATRIMONIAL", Description = "VARIACAO_PATRIMONIAL")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).Variacao_Patrimonial, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_RENTABILIDADE_PATRIMONIO_PERIODO([ExcelArgument(Name = "RENTABILIDADE_PATRIMONIO_PERIODO", Description = "RENTABILIDADE_PATRIMONIO_PERIODO")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).rentabilidade_patrimonio_Periodo, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_RENTABILIDADE_PATRIMONIO_ACUMULADA([ExcelArgument(Name = "RENTABILIDADE_PATRIMONIO_ACUMULADA", Description = "RENTABILIDADE_PATRIMONIO_ACUMULADA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).rentabilidade_patrimonio_Acumulada, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_VACANCIA_FISICA([ExcelArgument(Name = "VACANCIA_FISICA", Description = "VACANCIA_FISICA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).Vacancia_fisica, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_VACANCIA_FINANCERIA([ExcelArgument(Name = "VACANCIA_FINANCERIA", Description = "VACANCIA_FINANCERIA")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).Vacancia_financeria, fundo);
        [ExcelFunction(Description = "Consulta a vacancia fisica de um FII. Fonte > https://www.fundsexplorer.com.br/ranking")]
        public static dynamic FII_QT_ATIVOS([ExcelArgument(Name = "QT_ATIVOS", Description = "QT_ATIVOS")] string fundo) =>
                   Usefull.Run(() => crawlerRanking.Fill<RankingModel>(fundo).qt_Ativos, fundo);


    }
}
