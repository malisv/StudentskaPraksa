using System;
using System.Collections.Generic;

namespace SP.Data.Models
{
    public partial class StudentskaPraksa
    {
        public StudentskaPraksa()
        {
            Praktikants = new HashSet<Praktikant>();
        }

        public int StudentskaPraksaId { get; set; }
        public int Godina { get; set; }

        public virtual ICollection<Praktikant> Praktikants { get; set; }
    }
}
