namespace Origin.Model.DTO
{
    public class CardDTO
    {
        public CardDTO() { }
        public int id { get; set; }
        public string? codeNumber { get; set; }
        public string? pinNumber { get; set; }
        public double Balance { get; set; } 
        public double WithDraw { get; set; }
        public string? cardType { get; set; }
        public string? Owner { get; set; }
        public string? description { get; set; }
        public string? dueDate{ get; set; }
    }
}
