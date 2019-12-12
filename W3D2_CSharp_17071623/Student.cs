using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace W3D2_CSharp_17071623
{
    class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=W3D3CSharpOpdracht;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }        
    }

    class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required,StringLength(15)]
        public string Voornaam { get; set; }
        [Required, StringLength(20)]
        public string Achternaam { get; set; }
        public int? Leeftijd { get; set; }
        [Required, StringLength(1)]
        public char Geslacht { get; set; }

        public override string ToString()
        {
            if(Leeftijd == null)
            {
                return $"id: {StudentId} | Voornaam: {Voornaam} | Achternaam: {Achternaam}";
            }
            return $"id: {StudentId} | Voornaam: {Voornaam} | Achternaam: {Achternaam} | Leeftijd: {Leeftijd}";
        }
    }
}
