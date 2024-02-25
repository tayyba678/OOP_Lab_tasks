using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSlab5
{
    internal class DegreeProgramDL
    {
        public static List<DegreeProgram> degreeProgramsList = new List<DegreeProgram>();

        public static DegreeProgram AddDegree(DegreeProgram degreeProgram)
        {
            degreeProgramsList.Add(degreeProgram);
            return degreeProgram;
        }

        public static DegreeProgram IsDegreeExist(string title)
        {
            foreach (DegreeProgram degreeProgram in degreeProgramsList)
            {
                if (degreeProgram.Title == title) 
                    return degreeProgram;
            }
            return null;
        }
        public static void RemoveDegree(DegreeProgram degreeProgram)
        {
            degreeProgramsList.Remove(degreeProgram);
        }
        public static DegreeProgram IsDegreeExistDuration(int duration)
        {
            foreach (DegreeProgram degreeProgram in degreeProgramsList)
            {
                if (degreeProgram.Duration == duration)
                    return degreeProgram;
            }
            return null;
        }
    }
}
