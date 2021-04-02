using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOilMVP.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public double Liter { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public double Pay { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price} - {Liter} - {Cost}";
        }
    }
}
