using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRRealTime.Models;
using SignalRRealTime.Manager;

namespace SignalRRealTime
{
    public class AddHub : Hub
    {
        DatabaseContext db = new DatabaseContext();
        public void AffixWorker(string Name,string Surname,string UserName)
        {
            Worker work = new Worker()
            {
                Name = Name,
                Surname = Surname,
                UserName = UserName
            };
            db.Workers.Add(work);
            db.SaveChanges();
            Clients.All.response(Name,Surname,UserName);
        }
    }
}