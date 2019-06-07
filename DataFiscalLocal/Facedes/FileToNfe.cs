using DataFiscal.Data;
using DataFiscal.Models;
using DataFiscal.Nfe;
using System.Linq;

namespace DataFiscal.Facedes
{
    public class FileToNfe
    {
        private readonly ConsultOrCreate data;
        private readonly ApplicationDbContext db;

        public FileToNfe(ApplicationDbContext _db)
        {
            data = new ConsultOrCreate(_db);
            db = _db;
        }

        public NotaFiscal GetNfe(string xml)
        {
            var nfDesserealizada = UtilsNfe.DesserializaXml(xml);

            if (nfDesserealizada == null)
            {
                return null;
            }

            var nfToFind = Objects.Parse(nfDesserealizada);

            var findNf = FindByChave(nfToFind);

            if (findNf != null)
            {
                return findNf;
            }

            var inf = nfDesserealizada.NFe.infNFe;

            return new NotaFiscal
            {
                Chave = nfToFind.Chave,

                Emissao = nfToFind.Emissao,

                Itens = nfToFind.Itens.Select(i =>
                                                new Item
                                                {
                                                    Icms = i.Icms,
                                                    Quantidade = i.Quantidade,
                                                    ValorUnitario = i.ValorUnitario,
                                                    Op = data.FindOrCreate(i.Op),
                                                    Produto = data.FindOrCreate(i.Produto)

                                                }).ToList(),

                Emitente = data.FindOrCreate(nfToFind.Emitente),

                Destinatario = data.FindOrCreate(nfToFind.Destinatario)

            };
        }


        #region Nota Fiscal
        private NotaFiscal FindByChave(NotaFiscal nf)
        {
            return db.NotaFiscal.FirstOrDefault(n => n.Chave.Equals(nf.Chave));
        }

        #endregion

    }
}
