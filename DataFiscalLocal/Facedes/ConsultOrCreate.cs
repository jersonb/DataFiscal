using DataFiscal.Data;
using DataFiscal.Models;
using System.Linq;

namespace DataFiscal.Facedes
{
    public class ConsultOrCreate
    {
        private readonly ApplicationDbContext db;

        private readonly Consult consult;

        public ConsultOrCreate(ApplicationDbContext _db)
        {
            db = _db;
            consult = new Consult(_db);
        }

        #region Operacao
        public Operacao FindOrCreate(Operacao operacao)
        {
            var findOperacao = Find(operacao);

            if (findOperacao == null)
            {
                return CreateOperacao(operacao);
            }

            return findOperacao;
        }

        private Operacao CreateOperacao(Operacao operacaoTemp)
        {
            var opercacao = new Operacao
            {
                Aliq = consult.FindByCodigo(operacaoTemp.Aliq),
                Cfop = consult.FindByCodigo(operacaoTemp.Cfop),
                Origem = consult.FindByCodigo(operacaoTemp.Origem),
                Cst = consult.FindByCodigo(operacaoTemp.Cst),
                Ncm = consult.FindByCodigo(operacaoTemp.Ncm)
            };

            opercacao.Codigo = opercacao.GetHashCode().ToString();

            opercacao.ADescricao();

            return opercacao;
        }

        private Operacao Find(Operacao operacao)
        {
            return db.Operacao.FirstOrDefault(o => o.Codigo.Equals(operacao.Codigo)); ;
        }
        #endregion

        #region Empresa (Emitente e Destinatario)
        public Empresa FindOrCreate(Empresa empresa)
        {
            var findEmpresa = FindEmpresa(empresa.Cnpj);

            if (findEmpresa == null)
            {
                return CreateEmpresa(empresa.Cnpj, empresa.RazaoSocial);
            }
            return findEmpresa;
        }

        private Empresa CreateEmpresa(string cnpj, string razaoSocial)
        {
            return new Empresa
            {
                Codigo = cnpj,
                Descricao = razaoSocial,
                Cnpj = cnpj,
                RazaoSocial = razaoSocial
            };
        }

        private Empresa FindEmpresa(string cnpj)
        {
            return db.Empresa.FirstOrDefault(e => e.Cnpj.Equals(cnpj));
        }
        #endregion

        #region Produto
        public Produto FindOrCreate(Produto produto)
        {
            var findProduto = Find(produto);

            if (findProduto == null)
            {
                return Create(produto);
            }

            return findProduto;
        }

        private Produto Create(Produto produto)
        {
            return new Produto
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao
            };
        }

        private Produto Find(Produto produto)
        {
            return db.Produto.FirstOrDefault(p => p.Codigo.Equals(produto.Codigo));
        }
        #endregion

    }
}
