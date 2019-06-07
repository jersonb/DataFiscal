using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFiscal.Models
{
    public class Item : IEquatable<Item>
    {
        public Item()
        {
            Op = new Operacao();
            Produto = new Produto();
        }

        [Key]
        public long Id { get; set; }

        public Produto Produto { get; set; }

        [DisplayName("Vl. Unitário")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorUnitario { get; set; }

        [DisplayName("Qnt.")]
        public decimal Quantidade { get; set; }

        [DisplayName("ICMS")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Icms { get; set; }

        [DisplayName("Operação")]
        public Operacao Op { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public bool Equals(Item other)
        {
            return other != null &&
                   EqualityComparer<Operacao>.Default.Equals(Op, other.Op);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Op);
        }

        public static bool operator ==(Item left, Item right)
        {
            return EqualityComparer<Item>.Default.Equals(left, right);
        }

        public static bool operator !=(Item left, Item right)
        {
            return !(left == right);
        }
    }
}
