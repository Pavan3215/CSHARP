using System;

class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public virtual double CalculateBonus()
    {
        return Salary * 0.05;
    }
}

class Manager : Employee
{
    public override double CalculateBonus()
    {
        return Salary * 0.15;
    }
}

class Engineer : Employee
{
    public override double CalculateBonus()
    {
        return Salary * 0.10;
    }
}

class Program
{
    static void Main()
    {
        Employee e1 = new Manager() { Name = "John", Salary = 50000 };
        Employee e2 = new Engineer() { Name = "Raj", Salary = 40000 };

        Console.WriteLine($"{e1.Name} Bonus = {e1.CalculateBonus()}");
        Console.WriteLine($"{e2.Name} Bonus = {e2.CalculateBonus()}");
    }
}
