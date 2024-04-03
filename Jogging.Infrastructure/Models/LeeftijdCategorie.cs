namespace Jogging.Infrastructure.Models
{
    public class LeeftijdCategorie
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public int MinimumLeeftijd { get; set; }
        public int MaximumLeeftijd { get; set; }
    }
}
