using System;
using System.Collections.Generic;

namespace C44_G00_OOP03
{
    class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name cannot be empty or whitespace.");
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name cannot be empty or whitespace.");
                _lastName = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0 || value > 120)
                    throw new ArgumentException("Age must be a positive integer between 1 and 120.");
                _age = value;
            }
        }

        public Person(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }

        public virtual void GetDetails()
        {
            Console.WriteLine($"Full Name : {FirstName} {LastName}\nAge       : {Age}");
        }
    }

    class Student : Person
    {
        private int _gradeLevel;
        public int GradeLevel
        {
            get => _gradeLevel;
            set
            {
                if (value < 1 || value > 12)
                    throw new ArgumentException("Grade level must be between 1 and 12.");
                _gradeLevel = value;
            }
        }

        public Student(string fname, string lname, int age, int grade)
            : base(fname, lname, age)
        {
            GradeLevel = grade;
        }

        public override void GetDetails()
        {
            base.GetDetails();
            Console.WriteLine($"Grade     : {GradeLevel}");
        }
    }

    class Teacher : Person
    {
        private string _subject;
        public string Subject
        {
            get => _subject;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Subject cannot be empty.");
                _subject = value;
            }
        }

        public Teacher(string fname, string lname, int age, string subject)
            : base(fname, lname, age)
        {
            Subject = subject;
        }

        public override void GetDetails()
        {
            base.GetDetails();
            Console.WriteLine($"Subject   : {Subject}");
        }
    }

    class Admin : Person
    {
        private string _role;
        public string Role
        {
            get => _role;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Role cannot be empty.");
                _role = value;
            }
        }

        public Admin(string fname, string lname, int age, string role)
            : base(fname, lname, age)
        {
            Role = role;
        }

        public override void GetDetails()
        {
            base.GetDetails();
            Console.WriteLine($"Role      : {Role}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            try
            {
                persons.Add(new Student("Osama", "Elazab", 21, 1));
                persons.Add(new Student("Abdelhamed", "Elazab", 22, 2));
                persons.Add(new Teacher("Aymen", "Elazab", 48, "Arabic"));
                persons.Add(new Admin("Elsaid", "Elazab", 25, "Secretary"));
            }
           
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n==== Person Details ====\n");

            foreach (Person p in persons)
            {
                if (p is not null)
                {
                    p.GetDetails();
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
