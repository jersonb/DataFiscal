using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace DataFiscal.Models
{
    public abstract class Entidade : IEquatable<Entidade>
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Código")]
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Preencha o Código")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column(TypeName = "varchar(1000)")]
        [Required(ErrorMessage = "Preencha a Descrição")]
        public string Descricao { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entidade);
        }

        public bool Equals(Entidade other)
        {
            return other != null &&
                   Codigo == other.Codigo;
        }

        public static bool operator ==(Entidade left, Entidade right)
        {
            return EqualityComparer<Entidade>.Default.Equals(left, right);
        }

        public static bool operator !=(Entidade left, Entidade right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return Descricao;
        }

        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }
       
    }
}
