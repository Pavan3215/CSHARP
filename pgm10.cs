public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

DB Context

using Microsoft.EntityFrameworkCore;

class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=students.db");
}

CRUD program

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        // CREATE
        db.Students.Add(new Student { Name = "Pavan", Age = 20 });
        db.SaveChanges();

        // READ
        var list = db.Students.ToList();
        list.ForEach(s => Console.WriteLine($"{s.Id} - {s.Name}"));

        // UPDATE
        var st = db.Students.First();
        st.Name = "Updated Name";
        db.SaveChanges();

        // DELETE
        db.Students.Remove(st);
        db.SaveChanges();
    }
}
