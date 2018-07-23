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
            //InsertData();
            //InsertMultipleData();
            //var samurais = _db.Samurais.OrderBy(x=>x.Name).LastOrDefault(x=>x.Name.StartsWith("Swa"));
            //RetriveAndUpdate();
            using (var db = new SamuraiContext())
            {
                //var sam = db.Samurais.Find(2);
                //sam.Name = "Again updated";
                //db.Entry(sam).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //db.SaveChanges();

                //var sam = new Domain.Samurai() {
                //    Name = "Samurai with Quotes",
                //    Quotes=new List<Domain.Quote>() {
                //        new Quote{
                //            Text="Samurai Quote 1"
                //        },
                //        new Quote{
                //            Text="Samurai Quote 2"
                //        }
                //    }
                //};
                //db.Samurais.Add(sam);

                //var sam = db.Samurais.Find(6);
                //sam.Quotes.Add(new Quote { Text = "Samurai Quote 3" });

                //db.Samurais.Update(sam);


                //var quotes = new Quote { Text = "Samurai Quote 3",SamuraiId=6 };
                //db.Quotes.Add(quotes);

                //var sam = db.Samurais.Include(x => x.Quotes).Where(x=>x.Id==6).ToList();
                //db.SaveChanges();
            }

            Console.ReadKey();
        }

        #region RelatedData

        #endregion

        private static void RetriveAndUpdate()
        {
            using (var db = new SamuraiContext())
            {
                var samurais = db.Samurais.ToList();
                samurais.ForEach(x =>
                {
                    x.Name += "Updated";
                });
                db.SaveChanges();
            }
        }

        private static void InsertData()
        {
            var samurai1 = new Domain.Samurai()
            {
                Name = "Swagat"
            };

            using (var db = new SamuraiContext())
            {
                db.Samurais.Add(samurai1);
                db.SaveChanges();
            }
        }
        private static void InsertMultipleData()
        {
            var samurai1 = new Domain.Samurai() { Name = "Swagat3" };
            var samurai2 = new Domain.Samurai() { Name = "Divya" };
            var samurai3 = new Domain.Samurai() { Name = "Pravat" };

            using (var db = new SamuraiContext())
            {
                db.Samurais.AddRange(samurai1, samurai2, samurai3);
                db.SaveChanges();
            }
        }
    }
}
