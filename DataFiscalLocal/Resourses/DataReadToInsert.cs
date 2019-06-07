using System.IO;

namespace DataFiscal.Resourses
{
    public static class DataReadToInsert
    {
        internal static readonly string[] CFOP = File.ReadAllLines(@"Resourses\tCFOP.txt");

        internal static readonly string[] ORIGEM = File.ReadAllLines(@"Resourses\tORIGEM.txt");

        internal static readonly string[] CST = File.ReadAllLines(@"Resourses\tCST.txt");

        internal static readonly string[] ALIQUOTA = File.ReadAllLines(@"Resourses\tALIQUOTA.txt");

        internal static readonly string[] NCM = File.ReadAllLines(@"Resourses\tNCM.txt");
    }
}
