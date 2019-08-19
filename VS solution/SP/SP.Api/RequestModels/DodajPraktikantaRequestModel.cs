using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Api.RequestModels
{
    public class DodajPraktikantaRequestModel
    {
        [Required]
        public int StudentskaPraksaId { get; set; }
        [Required(ErrorMessage = "Polje usernameJeObavezno")]
        public string UserName { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string BrojTelefona { get; set; }
    }
}
