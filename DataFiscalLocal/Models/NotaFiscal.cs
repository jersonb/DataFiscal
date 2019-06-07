using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFiscal.Models
{
    public class NotaFiscal
    {

        public NotaFiscal()
        {
            Itens = new List<Item>();
            Emitente = new Empresa();
            Destinatario = new Empresa();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(44)")]
        public string Chave { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        public DateTime Emissao { get; set; }

        [Required]
        public Empresa Emitente { get; set; }

        [Required]
        public Empresa Destinatario { get; set; }

        public List<Item> Itens { get; set; }

        public override string ToString()
        {
            return Chave;
        }
    }
}
