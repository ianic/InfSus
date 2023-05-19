namespace StomatoloskaPoliklinika.Models
{
    public class Stomatolog
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public String Specijalizacija { get; set; }
        public float Cijena { get; set; }
        public virtual List<UgovoreniSastanak> UgovorniSastanciLista { get; set; } = new List<UgovoreniSastanak>();
        public Stomatolog()
        {
            
        }
    }
}
