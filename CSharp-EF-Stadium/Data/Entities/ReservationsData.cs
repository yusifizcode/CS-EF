using CSharp_EF_Stadium.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_EF_Stadium.Data.Entities
{
    class ReservationsData
    {
        public void AddReservation(Reservations reservations)
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            stadiumDbContext.Reservations.Add(reservations);
            stadiumDbContext.SaveChanges();
        }

        public List<Reservations> GetAllReservations()
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            return stadiumDbContext.Reservations.ToList();
        }

        public Reservations GetReservationById(int id)
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            return stadiumDbContext.Reservations.Find(id);
        }
    }
}
