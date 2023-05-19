using System;
namespace StomatoloskaPoliklinika.Models
{
	public class UgovoreniSastanak
	{
        public int Id { get; set; }

        public DateTime DatumVrijeme { get; set; }
        public string Status { get; set; }

        public int? PacijentId { get; set; }

        public virtual Pacijent pacijent { get; private set; }

        public UgovoreniSastanak()
		{
		}
	}
}

