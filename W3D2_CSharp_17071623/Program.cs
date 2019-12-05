using System;
using System.Collections.Generic;
using System.Linq;

namespace W3D2_CSharp_17071623
{
    class Program
    {
        static void AddStudentRecords(StudentContext context)
        {
            Console.Write("Wilt u records aanmaken?n/" +
                          "Typ Ja of Nee: ");
            string input = Console.ReadLine().ToLower();

            Console.Write("Hoeveel records wilt u invullen?: ");
            int count = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                if (input == "ja")
                {
                    Console.Write("Student voornaam: ");
                    string voornaam = Console.ReadLine();

                    Console.Write("Student achternaam: ");
                    string achternaam = Console.ReadLine();

                    Console.Write("Student leeftijd: ");
                    int leeftijd = Int32.Parse(Console.ReadLine());

                    var student = new Student
                    {

                        Voornaam = voornaam,
                        Achternaam = achternaam,
                        Leeftijd = leeftijd
                    };

                    context.Add(student);
                    context.SaveChanges();
                    Console.WriteLine();
                }
            }
        }

        static void AddDummyStudenten(StudentContext context)
        {

            context.Add(new Student()
                { Voornaam = "DummyStudent1", Achternaam = "DummmyAchternaam1", Leeftijd = 20 });
            context.Add(new Student()
                {Voornaam = "DummyStudent2", Achternaam = "AummmyAchternaam2", Leeftijd = 25 });
            context.Add(new Student()
                { Voornaam = "DummyStudent3", Achternaam = "ZummmyAchternaam3", Leeftijd = 23 });

            context.SaveChanges();
        }

        static List<Student> StudentOrderByLeeftijd(StudentContext context)
        {
            return context.Students.OrderBy(s => s.Leeftijd).ToList(); //Ordered op achternaam ascending
        }

        static List<Student> StudentSelectOuderDanNegentien(StudentContext context)
        {
            return context.Students.Where(s => s.Leeftijd > 19).ToList(); //Ouder dan 19 list
        }

        static List<Student> Query1(StudentContext context, string letter)
        {
            return context.Students
                .Where(s => s.Achternaam.StartsWith(letter, StringComparison.InvariantCultureIgnoreCase))
                .Select(s => s).ToList();
        }

        static void ShowRecords(StudentContext context, List<Student> StudentenList)
        {
            Console.WriteLine("\nStudenten in de database: ");

            foreach (var student in StudentenList)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
        }

        static void ShowRecords(StudentContext context)
        {
            Console.WriteLine("\nStudenten in de database: ");

            foreach (var student in context.Students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                AddStudentRecords(context); // Geef invoer om records toe te voegen

                /*ShowRecords(context, StudentOrderByLeeftijd(context)); // Records ordered bij leeftijd asc
                ShowRecords(context, StudentSelectOuderDanNegentien(context)); // Records van studenten op leeftijd ouder dan 19*/

                ShowRecords(context); // Alle studenten
            }

            Console.ReadKey();
        }
    }
}
