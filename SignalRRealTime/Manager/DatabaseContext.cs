using SignalRRealTime.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalRRealTime.Manager
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
            //Database Context sınıfı oluşturulma esnasında Veritabanı oluşturucu classını çağır.
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
        public DbSet<Worker> Workers { get; set; }

    }
    public class VeritabaniOlusturucu:CreateDatabaseIfNotExists<DatabaseContext>
    {
        //Oluşturulduktan Sonra
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < FakeData.NumberData.GetNumber(5,10); i++)
            {
                Worker work = new Worker()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    UserName = "user" + i,
                };
                context.Workers.Add(work);
            }
            context.SaveChanges();
        }
        //Oluşturulmadan Önce
        public override void InitializeDatabase(DatabaseContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}