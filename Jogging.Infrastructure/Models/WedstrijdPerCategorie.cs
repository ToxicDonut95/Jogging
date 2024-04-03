namespace Jogging.Infrastructure.Models
{
    public class WedstrijdPerCategorie
    {
        public long Id { get; set; }
        public string? Geslacht { get; set; }
        public string? AfstandNaam { get; set; }
        public int? AfstandInKm { get; set; }
        public long LeeftijdCategorieId { get; set; }
        public long WedstrijdId { get; set; }
        public DateTime? Guntime { get; set; }
    }
}
