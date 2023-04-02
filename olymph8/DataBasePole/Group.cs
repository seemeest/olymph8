using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olymph8.DataBasePole
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCount { get; set; }
        public int Semester1DisciplinesHours { get; set; }
        public int Semester2DisciplinesHours { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
