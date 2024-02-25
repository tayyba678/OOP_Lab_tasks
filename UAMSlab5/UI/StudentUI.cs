using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSlab5;

namespace UAMSlab5
{
    internal class StudentUI
    {
        public static void AddStudent()
        {
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student FSC Marks: ");
            float fsc = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks: ");
            float matric = float.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Program");
            Console.WriteLine("");
            Console.WriteLine("Enter how man preferences to enter: ");
            int pre = int.Parse(Console.ReadLine());
            Console.ReadKey();

            int count = 0;
            Console.WriteLine("Enter number of pref");
            count = int.Parse((Console.ReadLine()));
            for (int i = 0; i < count;)
            {
                if (GetUserPref() != null)
                {
                    Student.Preferces.Add(GetUserPref());
                    i++;
                }
            }
        }
        public static DegreeProgram GetUserPref()
        {
            Console.WriteLine("Enter your pref");
            string preff = Console.ReadLine();
            DegreeProgram program = DegreeProgramDL.IsDegreeExist(preff);
            if (program != null)
            {
                return program;
            }
            else
            {
                return null;
            }
        }
        public static void DisplayStudent(Student student)
        {
            Console.WriteLine(student.Name + " " + student.EcatMarks + " " + student.FSCMarks + "  " + student.Age);
        }

        public static void DisplayAllStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                DisplayStudent(student);
            }
        }

    }
}
