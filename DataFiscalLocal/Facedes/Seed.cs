using DataFiscal.Models;
using DataFiscal.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFiscal.Facedes
{
    public static class Seed
    {
        internal static readonly List<OperacaoFiscal> Cfops = GetCfops();
        internal static readonly List<OrigemImposto> Origens = GetOrigens();
        internal static readonly List<SituacaoTributaria> Csts = GetCsts();
        internal static readonly List<Aliquota> Aliquotas = GetAliquotas();
        internal static readonly List<NomenclaturaComum> Ncms = GetNcm();

        private static string Split(string line, int index)
        {
            return line.Split("|")[index];
        }

        private static List<OperacaoFiscal> GetCfops()
        {
            return DataReadToInsert.CFOP.Select(line => new OperacaoFiscal
            {
                Id = Convert.ToInt32(Split(line, 0)),
                Codigo = Split(line, 1),
                Descricao = Split(line, 2)
            }).ToList();
        }

        private static List<OrigemImposto> GetOrigens()
        {
            return DataReadToInsert.ORIGEM.Select(line => new OrigemImposto
            {
                Id = Convert.ToInt32(Split(line, 0)),
                Codigo = Split(line, 1),
                Descricao = Split(line, 2)
            }).ToList();
        }

        private static List<SituacaoTributaria> GetCsts()
        {
            return DataReadToInsert.CST.Select(line => new SituacaoTributaria
            {
                Id = Convert.ToInt32(Split(line, 0)),
                Codigo = Split(line, 1),
                Descricao = Split(line, 2)
            }).ToList();
        }

        private static List<Aliquota> GetAliquotas()
        {
            return DataReadToInsert.ALIQUOTA.Select(line => new Aliquota
            {
                Id = Convert.ToInt32(Split(line, 0)),
                Codigo = Split(line, 1),
                Descricao = Split(line, 2),
                VlAliquota = Convert.ToDecimal(Split(line, 3))
            }).ToList();
        }

        private static List<NomenclaturaComum> GetNcm()
        {
            return DataReadToInsert.NCM.Select(line => new NomenclaturaComum
            {
                Id = Convert.ToInt32(Split(line, 0)),
                Codigo = Split(line, 1),
                Descricao = Split(line, 2)
            }).ToList();
        }
    }
}
