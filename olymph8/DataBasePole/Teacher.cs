using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olymph8.DataBasePole
{
    public class Teacher
    {
  

        public int Id { get; set; }
        public string Name { get; set; }
        public int WeeklyHours { get; set; }
        public string WeeklyDays { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
    }

}
