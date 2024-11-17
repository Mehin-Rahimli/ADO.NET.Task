using ADO.NETTask.Data;
using ADO.NETTask.Models;
using ADO.NETTask.Services;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NETTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StudentService studentService = new StudentService();
            Student student=new Student { Name="Anya",Surname="Taylor Joy",Age=28};

            studentService.Add(student);

            studentService.Delete(4);

            Student studentGet=studentService.Get(5);
            if (studentGet != null)
            {
                Console.WriteLine($"Here is student: {studentGet.Id}. {studentGet.Name} {studentGet.Surname} {studentGet.Age}");
            }
            else
            {
                Console.WriteLine("Student not found");
            }

            Student updatestudent = new Student { Id = 2, Name = "Tom", Surname = "Hanks", Age = 26 };
            studentService.Update(updatestudent);

            List<Student> students = studentService.GetAll();
            foreach (var item in students)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname + " " + item.Age);
            }

        }
    }
}
