using DataFiscal.Nfe.NFe;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace DataFiscal.Nfe
{
    internal static class UtilsNfe
    {
        /// <summary>
        /// Verifica se uma string contém outra string no formato chave: valor.
        /// </summary>
        public static Boolean StringContemChaveValor(String str, String chave, String valor)
        {
            if (String.IsNullOrWhiteSpace(chave)) throw new ArgumentException(nameof(chave));
            if (String.IsNullOrWhiteSpace(str)) return false;

            return Regex.IsMatch(str, $@"({chave}):?\s*{valor}", RegexOptions.IgnoreCase);
        }

        public static String TipoDFeDeChaveAcesso(String chaveAcesso)
        {
            if (String.IsNullOrWhiteSpace(chaveAcesso)) throw new ArgumentException(nameof(chaveAcesso));

            if (chaveAcesso.Length == 44)
            {
                String f = chaveAcesso.Substring(20, 2);

                if (f == "55") return "NF-e";
                else if (f == "57") return "CT-e";
                else if (f == "65") return "NFC-e";
            }

            return "DF-e Desconhecido";
        }

        public static ProcNFe DesserializaXml(string xml)
        {
            var stringReader = new StringReader(xml);
            var xmlReader = new XmlTextReader(stringReader);
            xmlReader.Read();
            var serializer = new XmlSerializer(typeof(ProcNFe));

            if (serializer.CanDeserialize(xmlReader))
            {
                return (ProcNFe)serializer.Deserialize(xmlReader);
            }

            return null;
        }
    }
}
