using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Model
{
    [Table("Movement")]
    public partial class Movement : Core.Abstractions.IEntity
    {
        public Movement()
        {
            IsEnabled = true;
            OperationDay = DateTime.Now;
            WithdrawAmount = 0;

            //Seguramente hay una logica real para genenerar un codigo de operacion, mas no llegue a investigar lo suficiente
            //Por lo tanto encontre esta opcion que genera un valor que simulara ser un codigo de operacion
            OperationCode = Core.Framework.Common.setOperationNumber();
        }
        [Key]
        public int Id { get; set; }

        public int CardId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime OperationDay { get; set; }

        [StringLength(16)]
        public string OperationCode { get; set; } = null!;

        public double WithdrawAmount { get; set; }

        public double RemainingBalance { get; set; }

        [StringLength(30)]
        public string Description { get; set; } = null!;

        public bool IsEnabled { get; set; }


        [ForeignKey("CardId")]
        [InverseProperty("Movements")]
        public virtual Card Card { get; set; } = null!;

    }
}
