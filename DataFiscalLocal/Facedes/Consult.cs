using DataFiscal.Data;
using DataFiscal.Models;
using System;
using System.Linq;

namespace DataFiscal.Facedes
{
    public class Consult
    {
        private readonly ApplicationDbContext db;

        public Consult(ApplicationDbContext _db)
        {
            db = _db;
        }

        public Aliquota FindByCodigo(Aliquota aliquota)
        {
            var findAliq = db.Aliquota.FirstOrDefault(a => a.Codigo.Equals(aliquota.Codigo));

            if (findAliq == null)
            {
                throw new Exception(
                                     string.Format("A alíquota {0} não está cadastrada! Informe ao administrador do sistema"
                                     , aliquota));
            }

            return findAliq;
        }

        public NomenclaturaComum FindByCodigo(NomenclaturaComum ncm)
        {
            var findNcm = db.Ncm.FirstOrDefault(n => n.Codigo.Equals(ncm.Codigo));

            if (findNcm == null)
            {
                throw new Exception(
                                     string.Format("A NCM {0} não está cadastrada! Informe ao administrador do sistema"
                                     , ncm));
            }

            return findNcm;
        }

        public OperacaoFiscal FindByCodigo(OperacaoFiscal cfop)
        {
            var findCfop = db.Cfop.FirstOrDefault(c => c.Codigo.Equals(cfop.Codigo));

            if (findCfop == null)
            {
                throw new Exception(
                                    string.Format("O CFOP {0} não está cadastrado! Informe ao administrador do sistema"
                                    , cfop));
            }

            return findCfop;
        }

        public SituacaoTributaria FindByCodigo(SituacaoTributaria cst)
        {
            var findCst = db.Cst.FirstOrDefault(c => c.Codigo.Equals(cst.Codigo));

            if (findCst == null)
            {
                throw new Exception(
                                   string.Format("O CST {0} não está cadastrado! Informe ao administrador do sistema"
                                   , cst));
            }

            return findCst;
        }

        public OrigemImposto FindByCodigo(OrigemImposto origem)
        {
            var findOrigem = db.Origem.FirstOrDefault(c => c.Codigo.Equals(origem.Codigo));

            if (findOrigem == null)
            {
                throw new Exception(
                                  string.Format("A Origem do CST {0} não está cadastrada! Informe ao administrador do sistema"
                                  , origem));
            }

            return findOrigem;
        }
       
    }
}
