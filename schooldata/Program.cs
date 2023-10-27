using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schooldata
{
    internal class schooldata
    {


        private static schooldata instance;

        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private List<Subject> subjects = new List<Subject>();

        private schooldata() { }

        public static schooldata Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new schooldata();
                }
                return instance;
            }
        }

        public List<Student> Students => students;
        public List<Teacher> Teachers => teachers;
        public List<Subject> Subjects => subjects;
    }

    // Student class
    public class Student
    {
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }

    // Teacher class
    public class Teacher
    {
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }

    // Subject class
    public class Subject
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public Teacher Teacher { get; set; }
    }

    // Factory Method for creating school objects
    public static class SchoolFactory
    {
        public static Student CreateStudent(string name, string classAndSection)
        {
            var student = new Student { Name = name, ClassAndSection = classAndSection };
            schooldata.Instance.Students.Add(student);
            return student;
        }

        public static Teacher CreateTeacher(string name, string classAndSection)
        {
            var teacher = new Teacher { Name = name, ClassAndSection = classAndSection };
            schooldata.Instance.Teachers.Add(teacher);
            return teacher;
        }

        public static Subject CreateSubject(string name, string subjectCode, Teacher teacher)
        {
            var subject = new Subject { Name = name, SubjectCode = subjectCode, Teacher = teacher };
            schooldata.Instance.Subjects.Add(subject);
            return subject;
        }
    }

    class program
    {
        static void Main()
        {
            var schoolRepo = schooldata.Instance;

            var student1 = SchoolFactory.CreateStudent("Student A", "Class 10");
            var student2 = SchoolFactory.CreateStudent("Student B", "Class 9");

            var teacher1 = SchoolFactory.CreateTeacher(" Dasharath", "Class 10");
            var teacher2 = SchoolFactory.CreateTeacher("Manisha ", "Class 9");

            var subject1 = SchoolFactory.CreateSubject("Math", "MATH101", teacher1);
            var subject2 = SchoolFactory.CreateSubject("Science", "SCI101", teacher2);


            // Retrieve and display data
            Console.WriteLine("Students:");
            foreach (var student in schoolRepo.Students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.ClassAndSection}");
            }

            Console.WriteLine("\nSubjects:");
            foreach (var subject in schoolRepo.Subjects)
            {
                Console.WriteLine($"Name: {subject.Name}, Code: {subject.SubjectCode}, Teacher: {subject.Teacher.Name}");
                Console.ReadLine();
            }
        }
    }


}