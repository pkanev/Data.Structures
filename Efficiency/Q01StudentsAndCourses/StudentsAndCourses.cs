namespace Q01StudentsAndCourses
{
    using System;
    using System.IO;
    using Wintellect.PowerCollections;

    class StudentsAndCourses
    {
        private static readonly OrderedDictionary<string, OrderedDictionary<string, OrderedBag<string>>> studentsByCoursesLastNameAndFirstName =
            new OrderedDictionary<string, OrderedDictionary<string, OrderedBag<string>>>();

        static void Main()
        {
            using (var reader = new StreamReader("../../students.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var tokens = line.Split('|');
                    var course = tokens[2].Trim();
                    var fName = tokens[0].Trim();
                    var lName = tokens[1].Trim();

                    studentsByCoursesLastNameAndFirstName.EnsureKeyExists(course);
                    
                    studentsByCoursesLastNameAndFirstName[course].AppendValueToKey(lName, fName);

                    line = reader.ReadLine();
                }

                foreach (var studentsByCourse in studentsByCoursesLastNameAndFirstName)
                {
                    Console.Write("{0}: ", studentsByCourse.Key);
                    string orderedStudentNames = "";
                    foreach (var studentsByLastName in studentsByCourse.Value)
                    {
                        foreach (var firstName in studentsByLastName.Value)
                        {
                            orderedStudentNames += string.Format("{0} {1}, ", firstName, studentsByLastName.Key);
                        }
                    }
                    orderedStudentNames = orderedStudentNames.Substring(0, orderedStudentNames.Length - 2);
                    Console.WriteLine(orderedStudentNames);
                }
                
            }
        }
    }
}
