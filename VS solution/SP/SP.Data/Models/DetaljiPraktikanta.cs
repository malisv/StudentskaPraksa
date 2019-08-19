using System;
using System.Collections.Generic;

namespace SP.Data.Models
{
    public partial class DetaljiPraktikanta
    {
        public int PraktikantId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }

        public virtual Praktikant Praktikant { get; set; }
    }
}
