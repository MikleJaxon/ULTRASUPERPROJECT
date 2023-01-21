using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISCREESTR.DOMAIN
{
    public class Studplan
    {
        public int Id { get; set; }
        public string? Specname { get; set; }
        public int KursNumb { get; set; }
        public string? FormControl { get; set; }
        public string? PredmName { get; set; }
        public int Clocks { get; set; }
        public int Semestr { get; set; }
        

        public int PrepId { get; set; }
        public Prep? Prep { get; set; }
    }
}
