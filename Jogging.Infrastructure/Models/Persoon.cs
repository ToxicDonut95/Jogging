namespace Jogging.Infrastructure.Models
{
    public class Persoon
    {
        public long Id { get; set; }
        public string FamilieNaam { get; set; }
        public string Voornaam { get; set; }
        public string GeboorteDatum { get; set; }
        public string? IBANNummer { get; set; }
        public long SchoolId { get; set; }
        public long AdressId { get; set; }
        public int? UserId { get; set; }
    }
}
