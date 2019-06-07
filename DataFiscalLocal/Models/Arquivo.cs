using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFiscal.Models
{
    public class Arquivo
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Nome { get; set; }

        public NotaFiscal Nf { get; set; }

        [Required]
        public string Xml { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)")]
        public string Status { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Nome, Status);
        }
    }
}
