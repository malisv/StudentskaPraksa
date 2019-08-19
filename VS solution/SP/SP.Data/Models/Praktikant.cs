using System;
using System.Collections.Generic;

namespace SP.Data.Models
{
    public partial class Praktikant
    {
        public Praktikant()
        {
            PraktikantNaVanNastavnojAktivnostis = new HashSet<PraktikantNaVanNastavnojAktivnosti>();
        }

        public int PraktikantId { get; set; }
        public int StudentskaPraksaId { get; set; }
        public string Username { get; set; }

        public virtual StudentskaPraksa StudentskaPraksa { get; set; }
        public virtual DetaljiPraktikanta DetaljiPraktikanta { get; set; }
        public virtual ICollection<PraktikantNaVanNastavnojAktivnosti> PraktikantNaVanNastavnojAktivnostis { get; set; }
    }
}
