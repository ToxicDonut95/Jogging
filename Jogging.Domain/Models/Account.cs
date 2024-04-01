namespace Jogging.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string passwoord { get; set; }
        public char Rechten { get; set; }
        public int PersoonId { get; set; }
        public Persoon persoon { get; set; }
    }
}
