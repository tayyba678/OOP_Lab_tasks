using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UAMSlab5
{
    class Student
    {
        public string Name;
        public int Age;
        public float FSCMarks;
        public float EcatMarks;
        public float TotalMarks;
        public float Merit;
        public List<Subject> subjects = new List<Subject>();
        public static List<DegreeProgram> Preferces = new List<DegreeProgram>();
        public List<Student> GenerateMerit()
        {
            var students = StudentDL.GetStudentsList();
            foreach (var student in students)
            {
                student.TotalMarks = CalculateTotalMarks(student.FSCMarks, student.EcatMarks);
            }
            var sortedStudents = students.OrderByDescending(s => s.TotalMarks).ToList();
            return sortedStudents;
        }
        public float CalculateTotalMarks(float fscMarks, float ecatMarks)
        {
            float totalMarks = (fscMarks / 1100) * 60 + (ecatMarks / 400) * 40;

            return totalMarks;
        }
        public void GenerateMeritList(int availableSeats)
        {
            var sortedStudents = GenerateMerit();
            for (int i = 0; i < Math.Min(availableSeats, sortedStudents.Count); i++)
            {
                Console.WriteLine($"Merit Position {i + 1}: {sortedStudents[i].Name} - Total Marks: {sortedStudents[i].TotalMarks}");
            }
        }
            public void RegisterSubjects()
            {
                Console.WriteLine("Enter the student name:");
                string studentName = Console.ReadLine();
                var student = GenerateMeritList.FirstOrDefault(s => s.Name == studentName);

                if (student != null)
                {
                    Console.WriteLine($"Student {studentName} found in the registered students list.");                  
                    Console.WriteLine("Enter the subject code to register:");
                    string subjectCode = Console.ReadLine();
                    var subject = GetSubjectByCode(subjectCode);
                    if (subject != null)
                    {
                        if (!student.subjects.Contains(subject))
                        {
                            student.subjects.Add(subject);
                            Console.WriteLine($"Subject {subject.Name} registered successfully for {studentName}.");
                        }
                        else
                        {
                            Console.WriteLine($"Subject {subject.Name} is already registered for {studentName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Subject with code {subjectCode} not found.");
                    }
                }
                else
                {
                    Console.WriteLine($"Student {studentName} not found in the registered students list.");
                }
            }
        public void GenerateFeeForAllStudents()
        {
            foreach (var student in RegisterSubjects)
            {
                float fee = CalculateFee(student);
                Console.WriteLine($"Fee generated for {student.Name}: {fee}");
            }
        }
        private float CalculateFee(Student student)
        {
            float totalFee = 0;
            foreach (var subject in student.subjects)
            {
                totalFee += subject.SubjectFee;
            }
            return totalFee;
        }
    }

    }

