using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace olymph8.DataBasePole
{
    public class Discipline
    {
     

        public int Id { get; set; }
        public string Name { get; set; }
        public int Semester1Hours { get; set; }
        public int Semester1WeeklyHours { get; set; }
        public string Semester1ControlForm { get; set; }
        public int Semester2Hours { get; set; }
        public int Semester2WeeklyHours { get; set; }
        public string Semester2ControlForm { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
