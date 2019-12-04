using System;
using System.Collections.Generic;
using System.Linq;

namespace W3D2_CSharp_17071623
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                Console.Write("Wilt u records aanmaken?n/" +
                              "Typ Ja of Nee: " );
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

                        /*context.Add(new Student()
                            { Voornaam = "DummyStudent1", Achternaam = "DummmyAchternaam1", Leeftijd = 20 });
                        context.Add(new Student()
                            {Voornaam = "DummyStudent2", Achternaam = "AummmyAchternaam2", Leeftijd = 25 });
                        context.Add(new Student()
                            { Voornaam = "DummyStudent3", Achternaam = "ZummmyAchternaam3", Leeftijd = 23 });*/
                        

                        context.Add(student);
                        context.SaveChanges();
                        Console.WriteLine();
                    }
                }
               
                Console.WriteLine("\nAlle studenten in de database: ");

                var StudentListOrderByNaam = context.Students.OrderBy(s => s.Achternaam).ToList(); //Ordered op achternaam ascending
                var StudentListOuderDanTwintig = context.Students.Where(s => s.Leeftijd >= 20).ToList(); //Ouder dan 20 list

                foreach (var student in StudentListOuderDanTwintig)
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
