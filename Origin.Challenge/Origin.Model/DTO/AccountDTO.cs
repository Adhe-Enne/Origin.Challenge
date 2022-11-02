namespace Origin.Model.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Dni { get; set; } = null!;
        public string? Owner { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; } = null!;

        public DateTime DateAdded { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}
