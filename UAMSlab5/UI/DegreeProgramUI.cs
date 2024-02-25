using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UAMSlab5
{
    internal class DegreeProgramUI
    {
        public static DegreeProgram GetDegreeFromUser()
        {
            DegreeProgram degreeProgram = new DegreeProgram();
            Console.WriteLine("Enter degree title");
            degreeProgram.Title = Console.ReadLine();
            Console.WriteLine("Enter Duration ");
            degreeProgram.Duration = int.Parse(Console.ReadLine());

            Console.WriteLine("How many subjects you have in this degree");
            int subjectscount = int.Parse(Console.ReadLine());
            List<Subject> subjects = new List<Subject>();
            for (int i = 0; i < subjectscount; i++)
            {
                subjects.Add(GetSubjectsFromUser());
            }

            degreeProgram.subjectofdegree = subjects;

            return degreeProgram;
        }

        public static Subject GetSubjectsFromUser()
        {
            Subject subject = new Subject();
            Console.WriteLine("Enter Subject Code ");
            subject.SubjectCode = Console.ReadLine();
            Console.WriteLine("Enter Subject Credit Hours");
            subject.CreditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fee for the subject ");
            subject.SubjectFee = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Type of the subject");
            subject.SubjectType = Console.ReadLine();
            return subject;
        }
        public static void GenerateMerit()
        {
            foreach(Student student in Student)
            {
                Console.WriteLine($"{Student.Name} ")
            }
        }
    }
}
