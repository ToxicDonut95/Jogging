namespace Jogging.Infrastructure.Models
{
    public class Inschrijving
    {
        public long Id { get; set; }
        public Int16? LoopNummer { get; set; }
        public DateTime? EindTijd { get; set; }
        public long WedstrijdPerCategorieId { get; set; }
    }
}
