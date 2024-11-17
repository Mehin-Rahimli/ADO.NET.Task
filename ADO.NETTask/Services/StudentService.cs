using ADO.NETTask.Data;
using ADO.NETTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NETTask.Services
{
    internal class StudentService
    {
        private static Sql _sql;
        public StudentService()
        {

            _sql = new Sql();
        }

        public void Add(Student student)
        {
            int result = _sql.ExecuteCommand($"INSERT INTO Students VALUES('{student.Name}','{student.Surname}',{student.Age})");
            if (result > 0)
            {
                Console.WriteLine("Commands successfully completed");
            }
            else
            {
                Console.WriteLine("Error occured");
            }
        }
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            DataTable table = _sql.ExecuteQuery("SELECT*FROM Students");
            foreach (DataRow item in table.Rows)
            {
                Student student = new Student
                {
                    Id = (int)item["Id"],
                    Name = item["Name"].ToString(),
                    Surname = item["Surname"].ToString(),
                    Age = (int)item["Age"]
                };
                students.Add(student);
            }
            return students;
        }

        public void Delete(int Id)
        {
            _sql.ExecuteCommand($"DELETE FROM Students WHERE Id={Id}");
        }

        public Student Get(int Id)
        {
            DataTable table = _sql.ExecuteQuery($"SELECT* FROM Students WHERE Id={Id}");
            if (table.Rows.Count > 0)
            {
                DataRow item = table.Rows[0];

                Student student= new Student
                {
                    Id = (int)item["Id"],
                    Name = item["Name"].ToString(),
                    Surname = item["Surname"].ToString(),
                    Age = (int)item["Age"]
                };
                return student;
            }
            return null;

        }

        public void Update(Student updatestudent)
        {  
            int result= _sql.ExecuteCommand($"UPDATE Students SET Name='{updatestudent.Name}',Surname='{updatestudent.Surname}',Age={updatestudent.Age} WHERE Id={updatestudent.Id}");
            if (result>0)
            {
                Console.WriteLine("Updated successfully");
            }
            else
            {
                Console.WriteLine("Could not be found");
            }
        }
    }
}
