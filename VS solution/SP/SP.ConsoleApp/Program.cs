using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SP.Data.Models;

namespace SP.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new StudentskaPraksaContext();

            /*  var praktikanti = db.Praktikants.Where(pr => pr.Username.Contains("jovan") && pr.DetaljiPraktikanta != null).ToList();
              var prakseSaPraktikantima = db.StudentskaPraksas.Where(praksa => praksa.Praktikants.Any()).ToList();

              var praksa2019 = db.StudentskaPraksas.Find(1);
              var praksa2019praktikanti = praksa2019.Praktikants;

            var prviPraktikant = db.Praktikants.Any(p => p.Username.Contains("sdsdsdsd"));

            var praksaDetails = db.StudentskaPraksas.Include(p => p.Praktikants).Select(sp => new PraksaDetails
            {
                Godina = sp.Godina,
                KorisnickaImena = sp.Praktikants.Select(s => s.Username).ToList()
            }).ToList();


             var noviPraktikant = new Praktikant
             {
                 StudentskaPraksaId = 1,
                 Username = "miroslavc"
             };

             var novaPraksa = new StudentskaPraksa
             {
                 Godina = 2026,
             };

             novaPraksa.Praktikants = new List<Praktikant>
             {
               new Praktikant {
                   Username = "jovanav",
                   DetaljiPraktikanta = new DetaljiPraktikanta
                   {
                       BrojTelefona = "12312313",
                       Ime = "Jovana",
                       Prezime = "Vezmar"
                   }
               },
               new Praktikant {
                   Username = "stefant",
                   DetaljiPraktikanta = new DetaljiPraktikanta
                   {
                       BrojTelefona = "12312313",
                       Ime = "Stefan",
                       Prezime = "Turanjanin"
                   }
               },
             };

             db.StudentskaPraksas.Add(novaPraksa);



            var vlade = db.Praktikants.Find(2);
            vlade.Username = "mitarm";

            var vladoviDetalji = db.DetaljiPraktikantas.Find(2);
            vladoviDetalji.Ime = "Mitar";
            vladoviDetalji.Prezime = "Mitrovic";
            vladoviDetalji.BrojTelefona = "123123";*/

            var jovani = db.Praktikants.Where(p => p.Username == "jovang");

            db.Praktikants.RemoveRange(jovani);

            db.SaveChanges();

            Console.WriteLine("Dobrodosli na studentsku praksu ");

            Console.ReadKey();
        }
    }
}
