using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFiscal.Models
{
    public class Aliquota : Entidade
    {
        public Aliquota()
        {
        }

        public Aliquota(string codigo)
        {
            Codigo = codigo.Replace(".","").PadLeft(3,'0');
            Descricao = "";
        }

        [Required,DisplayFormat(DataFormatString = "{0:P1}"),Column(TypeName = "decimal(3,3)")]
        public decimal VlAliquota { get; set; }

    }

    
}
