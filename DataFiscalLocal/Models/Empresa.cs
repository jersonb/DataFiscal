using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFiscal.Models
{
    public class Empresa : Entidade
    {
        public Empresa()
        {
        }

        [DisplayName("Nome Fantasia")]
        [Column(TypeName = "varchar(200)")]
        public string NomeFantasia { get; set; }

        [DisplayName("Razão Social")]
        [Column(TypeName = "varchar(200)")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage ="Preencha o CNPJ")]
        [DisplayName("CNPJ")]
        [Column(TypeName = "varchar(14)")]
        public string Cnpj { get; set; }
    }
}
