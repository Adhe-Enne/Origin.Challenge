using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Model
{
    [Table("Card")]
    public partial class Card : Core.Abstractions.IEntity
    {
        public Card()
        {
            Status = Enum.Status.UNBALANCED;
            IsEnabled = true;
            Movements = new HashSet<Movement>();
            DateAdded = DateTime.Now;
            DueDate = DateTime.Now.AddYears(7);
            Balance = 0;
        }

        [Key]
        public int Id { get; set; }

        public int OwnerId { get; set; }

        [StringLength(16)]
        public string CodeNumber { get; set; } = null!;

        [Column("PIN")]
        [StringLength(4)]
        public string Pin { get; set; } = null!;

        public double Balance { get; set; }

        public Enum.Status Status { get; set; }

        public Enum.CardType CardType { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(30)]
        public string? Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateUpdated { get; set; }

        [ForeignKey("OwnerId")]
        [InverseProperty("Cards")]
        public virtual Account Owner { get; set; } = null!;

        [InverseProperty("Card")]
        public virtual ICollection<Movement> Movements { get; set; }

    }
}
