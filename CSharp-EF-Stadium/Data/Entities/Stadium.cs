using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_EF_Stadium.Data.Entities
{
    internal class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double HourPrice { get; set; }
        public int Capacity { get; set; }
    }
}
