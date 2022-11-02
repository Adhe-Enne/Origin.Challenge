using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Origin.Model
{
    [Table("Account")]
    public partial class Account : Core.Abstractions.IEntity
    {
        public Account()
        {
            IsEnabled = true;
            Cards = new HashSet<Card>();
            DateAdded = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Column("DNI")]
        [StringLength(9)]
        public string Dni { get; set; } = null!;

        [StringLength(30)]
        public string FirstName { get; set; } = null!;

        [StringLength(39)]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(50)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateUpdated { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<Card> Cards { get; set; }

        public string OwnerName {
            get
            {
            return this.FirstName + " " + this.LastName;    
            }
        }
    }
}
