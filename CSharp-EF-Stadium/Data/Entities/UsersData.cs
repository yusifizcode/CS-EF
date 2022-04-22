using CSharp_EF_Stadium.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_EF_Stadium.Data.Entities
{
    class UsersData
    {
        public void AddUser(Users users)
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            stadiumDbContext.Users.Add(users);
            stadiumDbContext.SaveChanges();
        }

        public List<Users> GetAllUsers()
        {
            StadiumDbContext stadiumDbContext = new StadiumDbContext();
            return stadiumDbContext.Users.ToList();
        }
    }
}
