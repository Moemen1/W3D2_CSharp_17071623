using System;
using System.Collections.Generic;
using System.Linq;

namespace W3D2_CSharp_17071623
{
    class Program
    {
        static void AddInputStudenten(StudentContext context)
        {
            Console.Write("Wilt u records aanmaken?\n" +
                          "Typ Ja of Nee: ");
            string input = Console.ReadLine().ToLower();   

            if (input == "ja")
            {
                Console.Write("Hoeveel records wilt u invullen?: ");
                int count = Int32.Parse(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.Write("Student voornaam: ");
                    string voornaam = Console.ReadLine();

                    Console.Write("Student achternaam: ");
                    string achternaam = Console.ReadLine();
                    
                    Console.Write("Student leeftijd: ");
                    int leeftijd = Int32.Parse(Console.ReadLine());

                    Console.Write("Student geslacht (1 character): ");
                    char geslacht = Console.ReadLine().ToCharArray()[0];                   

                    var student = new Student
                    {

                        Voornaam = voornaam,
                        Achternaam = achternaam,
                        Leeftijd = leeftijd,
                        Geslacht = geslacht
                    };

                    context.Add(student);
                    context.SaveChanges();
                    Console.WriteLine();
                }
             }            
        }

        static void AddStudenten(StudentContext context)
        {
            if(context.Students.Count() == 0)
            {
                context.Add(new Student()
                { Voornaam = "Bob", Achternaam = "Jansen", Leeftijd = 20, Geslacht = 'M' });
                context.Add(new Student()
                { Voornaam = "Alice", Achternaam = "Smith", Leeftijd = 22, Geslacht = 'V' });
                context.Add(new Student()
                { Voornaam = "Carl", Achternaam = "Johnson", Leeftijd = 23, Geslacht = 'M' });
                context.Add(new Student()
                { Voornaam = "John", Achternaam = "Waters", Leeftijd = 19, Geslacht = 'M' });
                context.Add(new Student()
                { Voornaam = "Will", Achternaam = "Anderson", Leeftijd = 23, Geslacht = 'M' });

                context.SaveChanges();
            }         
        }

        static List<Student> StudentOrderByLeeftijd(StudentContext context)
        {
            return context.Students.OrderBy(s => s.Leeftijd).ToList(); //Ordered op achternaam ascending
        }

        static List<Student> StudentSelectOuderDanNegentien(StudentContext context)
        {
            return context.Students.Where(s => s.Leeftijd > 19).ToList(); //Ouder dan 19 list
        }

        static Object StudentWhereAchternaamStartsWith(StudentContext context, string letter)
        {
            return context.Students
                .Where(s => s.Achternaam.StartsWith(letter, StringComparison.InvariantCultureIgnoreCase)) // filter eerst op achternaam met begin letter               
                .OrderBy(s => s.Voornaam)
                .ThenBy(s => s.Leeftijd);            
        }

        static Object StudentOuderOfGelijkAanTwintigMetGeslacht(StudentContext context, char geslacht)
        {
            return context.Students
                .Where(s => s.Geslacht == geslacht && s.Leeftijd >= 20)
                .Select(s => new { s.Voornaam, s.Achternaam }).ToList();           
        }

        static void ShowRecords(StudentContext context, Object StudentenList)
        {
            Console.WriteLine("\nStudenten in de database: ");

            foreach (var student in (IEnumerable<Object>)StudentenList)
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
                AddInputStudenten(context); // Geef invoer om records toe te voegen
                AddStudenten(context);

                //ShowRecords(context, StudentWhereAchternaamStartsWith(context, "A")); // Alle studenten
                ShowRecords(context, StudentOuderOfGelijkAanTwintigMetGeslacht(context, 'M'));
            }

            Console.ReadKey();
        }
    }
}
