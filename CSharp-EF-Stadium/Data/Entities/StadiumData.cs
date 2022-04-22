using CSharp_EF_Stadium.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_EF_Stadium.Data.Entities
{
    internal class StadiumData
    {
        public void AddStadion(Stadium stadium)
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            stadiumDbContext.Stadium.Add(stadium);
            stadiumDbContext.SaveChanges();
        }

        public List<Stadium> GetAllStadiums()
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            return stadiumDbContext.Stadium.ToList();
        }

        public Stadium GetStadiumById(int id)
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            return stadiumDbContext.Stadium.Find(id);
        }

        public void DeleteStadiumById(int id)
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            var data = stadiumDbContext.Stadium.FirstOrDefault(x=>x.Id == id);
            stadiumDbContext.Stadium.Remove(data);
            stadiumDbContext.SaveChanges();

        }
    }
}
