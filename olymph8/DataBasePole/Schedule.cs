using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olymph8.DataBasePole
{
    public class Schedule
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public int LessonNumber { get; set; }

        // Связь с таблицей Discipline
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        // Связь с таблицей Group
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }

}
