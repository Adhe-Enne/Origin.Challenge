using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origin.Model.DTO
{
    public class MovementDTO
    {
        public int Id { get; set; }

        public string? Owner { get; set; }

        public string? CardNumber { get; set; }
        public string? OperationDay { get; set; }
        public double WithdrawAmount { get; set; }
        public double RemainingBalance { get; set; }
        public string? OperationCode { get; set; }
        public string? Description { get; set; } 

    }
}
