using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_EF_Stadium.Data.Entities
{
    class Reservations
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public int UserId { get; set; }
        public Stadium Stadium { get; set; }
        public Users Users { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
    }
}
