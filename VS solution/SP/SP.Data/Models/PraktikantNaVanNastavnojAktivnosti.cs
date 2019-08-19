using System;
using System.Collections.Generic;

namespace SP.Data.Models
{
    public partial class PraktikantNaVanNastavnojAktivnosti
    {
        public int VanNastavnaAktivnostId { get; set; }
        public int PraktikantId { get; set; }

        public virtual Praktikant Praktikant { get; set; }
        public virtual VanNastavnaAktivnost VanNastavnaAktivnost { get; set; }
    }
}
