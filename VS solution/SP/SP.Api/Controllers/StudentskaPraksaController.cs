using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP.Api.ResponseModels;
using SP.Data.Models;

namespace SP.Api.Controllers
{
    [Route("api/StudentskaPraksa")]
    [ApiController]
    public class StudentskaPraksaController : ControllerBase
    {
        private StudentskaPraksaContext _db;

        public StudentskaPraksaController(StudentskaPraksaContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("getSvePrakse")]
        public ActionResult<IEnumerable<StudentskaPraksa>> Get()
        {
            var studentskePrakse = _db.StudentskaPraksas.ToList();
            return studentskePrakse;
        }

        [HttpGet]
        [Route("getTrenutnaPraksa/{godina}")]
        public ActionResult Get(int godina)
        {
            var trazenaPraksa = _db.StudentskaPraksas
                                  .Include(pr => pr.Praktikants)
                                  .FirstOrDefault(p => p.Godina == godina);

            if (trazenaPraksa == null)
            {
                return BadRequest("Trazeni resurs ne postoji");
            }
            else
            {
                return Ok(trazenaPraksa);
            }

        }

        [HttpGet]
        [Route("getStudentskePraksePremaKlijentovomModelu")]
        public ActionResult GetStudentskePraksePremaKlijentovomModelu()
        {
            var trazenePrakse = _db.StudentskaPraksas
                                  .Include(pr => pr.Praktikants)
                                  .Select(sp => new PraksaDetailsResponseModel
                                  {
                                      Godina = sp.Godina,
                                      KorisnickaImena = sp.Praktikants.Select(prakt => prakt.Username).ToList()
                                  }).ToList();

            return Ok(trazenePrakse);
        }

        [HttpPost]
        [Route("dodajStudentskuPraksu")]
        public ActionResult DodajStudentskuPraksu(StudentskaPraksa studentskaPraksa)
        {
            _db.StudentskaPraksas.Add(studentskaPraksa);
            _db.SaveChanges();

            return Ok("Uspjesno ste dodali studentsku praksu");
        }
    }
}
