using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _db = new SamuraiContext();
        static void Main(string[] args)
        {

            //AddSamurais();
            //PrintSamurais();

            //AddBattleToSamurai();

            PrintSamuraiWithBattles();

            Console.ReadKey();
        }

        private static void PrintSamuraiWithBattles()
        {
            var sams = _db.Samurais
                            .Include(x => x.SamuraiBattles)
                            .ThenInclude(y => y.Battle)
                            .ToList();

            foreach (var s in sams)
            {
                Console.WriteLine($"{s.Id} - {s.Name}");
                Console.WriteLine("---------------------------------------------");
                foreach (var b in s.Battles())
                {
                    Console.WriteLine($"Battle id - {b.Id}  -  {b.Name}");
                }
            }
        }


        #region RelatedData
        private static void PrintSamurais()
        {
            var sams = _db.Samurais.ToList();
            Console.WriteLine("\n\nPrinting Samurais............");

            foreach (var s in sams)
            {
                Console.WriteLine($"{s.Id} - {s.Name}");
            }
        }
        private static void AddSamurais()
        {
            if (!_db.Samurais.Any())
            {
                var sams = new List<Domain.Samurai>()
                {
                     new Domain.Samurai() { Name = "Divya" }
                    ,new Domain.Samurai() { Name = "Swagat" }
                    ,new Domain.Samurai() { Name = "Pradeep" }
                    ,new Domain.Samurai() { Name = "Rahul" }
                };
                _db.AddRange(sams);
                _db.SaveChanges();
            }
        }

        private static void AddBattleToSamurai()
        {
            var sam = _db.Samurais.Include(x => x.SamuraiBattles).FirstOrDefault(x=>x.Id==12);
            if (sam != null && !sam.SamuraiBattles.Any())
            {
                sam.SamuraiBattles.Add(new SamuraiBattle {
                    Battle=new Battle
                    {
                        Name="Panipath Yudh"
                    }
                });
                _db.SaveChanges();
            }
        }

        
        #endregion

    }
}
