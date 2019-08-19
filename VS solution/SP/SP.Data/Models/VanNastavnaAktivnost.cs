using System;
using System.Collections.Generic;

namespace SP.Data.Models
{
    public partial class VanNastavnaAktivnost
    {
        public VanNastavnaAktivnost()
        {
            PraktikantNaVanNastavnojAktivnostis = new HashSet<PraktikantNaVanNastavnojAktivnosti>();
        }

        public int VanNastavnaAktivnostId { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public DateTime Vrijeme { get; set; }

        public virtual ICollection<PraktikantNaVanNastavnojAktivnosti> PraktikantNaVanNastavnojAktivnostis { get; set; }
    }
}
