using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiApp.Data;
using SamuraiApp.Domain;
    
namespace SamuraiApp.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            System.Console.ReadKey();
        }

        private static void InsertData()
        {
            var samurai1 = new Domain.Samurai()
            {
                Name = "Swagat"
            };

            using (var db=new SamuraiContext())
            {
                db.Samurais.Add(samurai1);
                db.SaveChanges();
            }
        }
    }
}
