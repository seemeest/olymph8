using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olymph8.Control
{
    internal class GroupController
    {

        public GroupController(int id, string name, int term1, string fk1, int sm_work1, int term2, string fk2, int sm_work2, string teacher, int konsult)
        {
            this.id = id;
            this.name = name;
            Term1 = term1;
            this.fk1 = fk1;
            Sm_work1 = sm_work1;
            Term2 = term2;
            this.fk2 = fk2;
            Sm_work2 = sm_work2;
            Teacher = teacher;
            Konsult = konsult;
        }

        int id;
        string name;
        int Term1;
        string fk1;
        int Sm_work1;


        int Term2;
        string fk2;
        int Sm_work2;

        string Teacher;
        int Konsult;



    }
}
