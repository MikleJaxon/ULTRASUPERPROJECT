using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISCREESTR.DOMAIN
{
    public class Prep
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Otcestvo { get; set; }

        public string? Mail { get; set; }

        public int Phone { get; set; }

        public List<Studplan> Studplans { get; set; }  = new List<Studplan>();
        public void AddStudplan(Studplan studplan)
        {
            Studplans.Add(studplan);
        }
        public void RemoveAt(int index)
        {
            Studplans.RemoveAt(index);
        }
    }
}
