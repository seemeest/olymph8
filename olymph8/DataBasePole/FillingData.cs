using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace olymph8.DataBasePole
{




    public class FillingData
    {

        string connectionString = "Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;Integrated Security=True";
        SqlConnection connection;

        List<Discipline> disciplines;
        List<Group> groups;
        List<Schedule> schedules;
        List<Teacher> teachers;

        public FillingData() {
            disciplines = new List<Discipline>();
            groups = new List<Group>();
            schedules = new List<Schedule>();
            teachers = new List<Teacher>();
            connection = new SqlConnection(connectionString);
            connection.Open();

        }

        public void GetData()
        {


        }


    }


    public class DatabaseReader
    {
        private readonly string connectionString;

        public DatabaseReader(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM teachers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Teacher teacher = new Teacher();
                            teacher.Id = (int)reader["id"];
                            teacher.Name = (string)reader["name"];
                            teacher.WeeklyHours = (int)reader["weekly_hours"];
                            teacher.WeeklyDays = (string)reader["weekly_days"];

                            teachers.Add(teacher);
                        }
                    }
                }
            }

            return teachers;
        }

        public List<Discipline> GetDisciplines()
        {
            List<Discipline> disciplines = new List<Discipline>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM disciplines";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Discipline discipline = new Discipline();
                            discipline.Id = (int)reader["id"];
                            discipline.Name = (string)reader["name"];
                            discipline.Semester1Hours = (int)reader["semester1_hours"];
                            discipline.Semester1WeeklyHours = (int)reader["semester1_weekly_hours"];
                            discipline.Semester1ControlForm = (string)reader["semester1_control_form"];
                            discipline.Semester2Hours = (int)reader["semester2_hours"];
                            discipline.Semester2WeeklyHours = (int)reader["semester2_weekly_hours"];
                            discipline.Semester2ControlForm = (string)reader["semester2_control_form"];
                            discipline.TeacherId = (int)reader["teacher_id"];

                            disciplines.Add(discipline);
                        }
                    }
                }
            }

            return disciplines;
        }

        public List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM groups";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Group group = new Group();
                            group.Id = (int)reader["id"];
                            group.Name = (string)reader["name"];
                            group.StudentsCount = (int)reader["students_count"];
                            group.Semester1DisciplinesHours = (int)reader["semester1_disciplines_hours"];
                            group.Semester2DisciplinesHours = (int)reader["semester2_disciplines_hours"];

                            groups.Add(group);
                        }
                    }
                }
            }

            return groups;
        }

        public List<Schedule> GetSchedule()
        {
            List<Schedule> schedule = new List<Schedule>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT s.*, d.*, g.* 
                         FROM schedule s 
                         INNER JOIN discipline d ON s.discipline_id = d.id 
                         INNER JOIN [group] g ON s.group_id = g.id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Schedule scheduleItem = new Schedule();
                            scheduleItem.Id = (int)reader["s.id"];
                            scheduleItem.DayOfWeek = (string)reader["day_of_week"];
                            scheduleItem.LessonNumber = (int)reader["lesson_number"];

                            // Заполнение свойства Discipline, используя данные из таблицы discipline
                            scheduleItem.DisciplineId = (int)reader["discipline_id"];
                            Discipline discipline = new Discipline();
                            discipline.Id = (int)reader["d.id"];
                            discipline.Name = (string)reader["name"];
                            scheduleItem.Discipline = discipline;

                            // Заполнение свойства Group, используя данные из таблицы group
                            scheduleItem.GroupId = (int)reader["group_id"];
                            Group group = new Group();
                            group.Id = (int)reader["g.id"];
                            group.Name = (string)reader["name"];
                            scheduleItem.Group = group;

                            schedule.Add(scheduleItem);
                        }
                    }
                }
            }

            return schedule;
        }


    }

}

