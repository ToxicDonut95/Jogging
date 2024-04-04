namespace Jogging.Domain.Models
{
    public class AccountDOM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char Rechten { get; set; }
        public int PersoonId { get; set; }
        public PersoonDOM persoon { get; set; }
    }
}
