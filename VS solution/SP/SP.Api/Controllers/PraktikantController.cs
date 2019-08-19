using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SP.Api.RequestModels;
using SP.Api.ResponseModels;
using SP.Data.Models;

namespace SP.Api.Controllers
{
    [Route("api/Praktikanti")]
    [ApiController]
    public class PraktikantController : ControllerBase
    {
        private readonly StudentskaPraksaContext _db;

        public PraktikantController(StudentskaPraksaContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("dodajNovogPraktikanta")]
        public ActionResult DodajPraktikanta(Praktikant praktikat)
        {
            _db.Praktikants.Add(praktikat);
            _db.SaveChanges();

            return Ok("Uspjesno ste dodali praktikanta");
        }

        [HttpPost]
        [Route("dodajNovogPraktikantaIspravno")]
        public ActionResult DodajPraktikantaIspravno(DodajPraktikantaRequestModel dodajPraktikantaRequestModel)
        {

            var praktikant = new Praktikant
            {
                StudentskaPraksaId = dodajPraktikantaRequestModel.StudentskaPraksaId,
                Username = dodajPraktikantaRequestModel.UserName,

                DetaljiPraktikanta = new DetaljiPraktikanta
                {
                    Ime = dodajPraktikantaRequestModel.Ime,
                    Prezime = dodajPraktikantaRequestModel.Prezime,
                    BrojTelefona = dodajPraktikantaRequestModel.BrojTelefona
                }
            };

            _db.Praktikants.Add(praktikant);
            _db.SaveChanges();

            return Ok("Uspjesno ste dodali praktikanta");
        }
    }
}
