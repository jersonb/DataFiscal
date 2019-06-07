using DataFiscal.Models;
using DataFiscal.Nfe.NFe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFiscal.Facedes
{
    public static class Objects
    {
        public static NotaFiscal Parse(ProcNFe nf)
        {
            var inf = nf.NFe.infNFe;

            return new NotaFiscal
            {
                Chave = nf.protNFe.infProt.chNFe,
                Emissao = DateTime.Parse(inf.ide.dhEmi != null
                                                        ? inf.ide.dhEmi.Value.ToString() 
                                                        : inf.ide.dEmi.Value.ToString()),
                Emitente = GetEmitente(inf.emit),
                Destinatario = GetDestinatario(inf.dest),
                Itens = GetItens(inf.det)

            };
        }

        private static Empresa GetDestinatario(Destinatario dest)
        {
            return new Empresa
            {
                Codigo = dest.CNPJ ?? dest.CPF,
                Cnpj = dest.CNPJ ?? dest.CPF,
                RazaoSocial = dest.xNome,
                Descricao = dest.xNome,
            };
        }

        private static Empresa GetEmitente(Emitente emit)
        {
            return new Empresa
            {
                Codigo = emit.CNPJ,
                Cnpj = emit.CNPJ,
                RazaoSocial = emit.xNome,
                Descricao = emit.xFant
            };
        }

        private static List<Item> GetItens(List<Detalhe> det)
        {

            var teste = det.Select(i => GetIten(i))
                           .GroupBy(o => o.Op.GetHashCode())
                           .Select(o => o.First()).ToList();

            return teste;
        }

        private static Item GetIten(Detalhe d)
        {
            var produto = d.prod;
            return new Item
            {
                Icms = Convert.ToDecimal(d.imposto.ICMS.ICMS.vICMS),
                Quantidade = Convert.ToDecimal(produto.qCom),
                ValorUnitario = Convert.ToDecimal(produto.vProd),
                Produto = GetProduto(produto),
                Op = GetOperacao(d)
            };
        }

        private static Produto GetProduto(ProdutoNf produto)
        {
            return new Produto
            {
                Codigo = produto.cProd,
                Descricao = produto.xProd
            };
        }

        private static Operacao GetOperacao(Detalhe d)
        {
            var produto = d.prod;
            var icms = d.imposto.ICMS.ICMS;

            string ncm = produto.NCM;
            string cfop = produto.CFOP.ToString();
            string origem = icms.orig;
            string cst = icms.CST;
            string aliquota = icms.pICMS.ToString();

            var operacao = new Operacao
            {
                Ncm = new NomenclaturaComum(ncm),
                Cfop = new OperacaoFiscal(cfop),
                Origem = new OrigemImposto(origem),
                Cst = new SituacaoTributaria(cst),
                Aliq = new Aliquota(aliquota),
            };

            operacao.Codigo = operacao.GetHashCode().ToString();

            return operacao;
        }

    }
}
