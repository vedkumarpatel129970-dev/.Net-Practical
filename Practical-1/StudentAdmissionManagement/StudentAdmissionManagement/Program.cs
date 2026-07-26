using System;
namespace StudentAdmissionManagement
{
    class Student
    {
        private int studentId; 
        private string studentName; 
        private int age;
        private string course; 
        private double fees;

        public Student()
        {
            studentId = 0; 
            studentName = ""; 
            age = 0;
            course = ""; fees = 0;
        }
        public Student(int id, string name, int age, string course, double fees)
        {
            studentId = id; 
            studentName = name; 
            this.age = age; 
            this.course = course; 
            this.fees = fees;
        }

        public void DisplayStudent()
        {
            Console.WriteLine("\n------ Student Admission Details	");
            Console.WriteLine("Student ID	: " + studentId); Console.WriteLine("Student  ame : " + studentName); Console.WriteLine("Age	: " + age); Console.WriteLine("Course	: " + course); Console.WriteLine("Fees	: " + fees);
        }
    }


    class flrogram
    {
        static void Main(string[] args)
        {
            int id, age;
            string name, course; double fees;
            Console.WriteLine("===== Student Admission Management ====="); Console.Write("Enter Student ID: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student  ame: "); name = Console.ReadLine();
            Console.Write("Enter Age: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Course: "); course = Console.ReadLine();

            Console.Write("Enter Fees: ");
            fees = Convert.ToDouble(Console.ReadLine());
            Student s1 = new Student(id, name, age, course, fees); s1.DisplayStudent();
            Console.WriteLine("\nflress any key to exit..."); Console.ReadKey();
        }
    }
}

