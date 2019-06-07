using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFiscal.Models
{
    public class Operacao : Entidade, ICloneable
    {
        public Operacao()
        {
            Codigo = "";
            Descricao = "";
            Cfop = new OperacaoFiscal();
            Cst = new SituacaoTributaria();
            Origem = new OrigemImposto();
            Aliq = new Aliquota();
            Ncm = new NomenclaturaComum();
            Valida = "";
        }

        [DisplayName("CST")]
        public string OrigemCst => Origem.Codigo + Cst.Codigo;

        [DisplayName("CFOP")]
        [Required]
        public OperacaoFiscal Cfop { get; set; }

        [Required]
        public OrigemImposto Origem { get; set; }
       
        [Required]
        public SituacaoTributaria Cst { get; set; }

        [DisplayName("Alíquota")]
        [Required]
        public Aliquota Aliq { get; set; }

        [DisplayName("NCM")]
        [Required]
        public NomenclaturaComum Ncm { get; set; }

        [DisplayName("Válida?")]
        [Column(TypeName = "varchar(3)")]
        public string Valida { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Operacao operacao &&
                   base.Equals(obj) &&
                   EqualityComparer<OperacaoFiscal>.Default.Equals(Cfop, operacao.Cfop) &&
                   EqualityComparer<OrigemImposto>.Default.Equals(Origem, operacao.Origem) &&
                   EqualityComparer<SituacaoTributaria>.Default.Equals(Cst, operacao.Cst) &&
                   EqualityComparer<Aliquota>.Default.Equals(Aliq, operacao.Aliq) &&
                   EqualityComparer<NomenclaturaComum>.Default.Equals(Ncm, operacao.Ncm);
        }

        public override int GetHashCode()
        {
         return Math.Abs( 
                    HashCode.Combine(
                                 Cfop.GetHashCode(),
                                 Origem.GetHashCode(), 
                                 Cst.GetHashCode(), 
                                 Aliq.GetHashCode(),
                                 Ncm.GetHashCode()
                                 ));
        }

        public void ADescricao()
        {
            Descricao = string.Format("CFOP: {0}\nCST: {1}-{2}\nNCM: {3}\nAlíquota: {4}",
                                                Cfop, Origem, Cst, Ncm, Aliq);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
