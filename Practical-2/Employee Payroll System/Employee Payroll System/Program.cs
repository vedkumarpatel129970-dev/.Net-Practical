using System;
interface Ipayroll
{
    void CalculateSalary(); void DisplaySalary();
}
class Employee
{
    public int EmpId; public string EmpName;
    public double BasicSalary;

    public Employee(int id, string name, double salary) // constructor
    {
        EmpId = id; EmpName = name;
        BasicSalary = salary;
    }
}

class FullTimeEmployee : Employee, Ipayroll
{
    double RA, DA, GrossSalary; // variables

    public FullTimeEmployee(int id, string name, double salary) // constructor
    : base(id, name, salary)
    {
    }
    public void CalculateSalary()
    {
        RA = BasicSalary * 0.35; // 35% DA = BasicSalary * 0.15;	// 15%
        GrossSalary = BasicSalary + RA + DA;
    }
    public void DisplaySalary()
    {

        Console.WriteLine("\n===== FULL TIME EMPLOYEE PAYROLL =====");
        Console.WriteLine("Employee ID	: " + EmpId);
        Console.WriteLine("Employee  ame : " + EmpName);
        Console.WriteLine("Basic Salary	: " + BasicSalary);

        Console.WriteLine(" RA (20%)	: " + RA);
        Console.WriteLine("DA (10%)	: " + DA);
        Console.WriteLine("		");
        Console.WriteLine("Gross Salary	: " + GrossSalary);
    }
}
class partTimeEmployee : Employee, Ipayroll
{
    double TotalSalary; // variable

    public partTimeEmployee(int id, string name, double salary)    // constructor
    : base(id, name, salary)
    {
    }

    public void CalculateSalary()
    {
        TotalSalary = BasicSalary;
    }

    public void DisplaySalary()
    {
        Console.WriteLine("\n===== PART TIME EMPLOYEE PAYROLL =====");
        Console.WriteLine("Employee ID	: " + EmpId);
        Console.WriteLine("Employee  ame : " + EmpName);
        Console.WriteLine("Basic Salary	: " + BasicSalary);
        Console.WriteLine(" RA	 : 0");
        Console.WriteLine("DA	: 0");
        Console.WriteLine("		");
        Console.WriteLine("Total Salary	: " + TotalSalary);
    }
}

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== EMPLOYEE PAYROLL SYSTEM =====");

        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Basic Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nSelect Employee Type");
        Console.WriteLine("1. Full Time");
        Console.WriteLine("2. Part Time");
        Console.Write("Enter Your Choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            FullTimeEmployee emp = new FullTimeEmployee(id, name, salary);
            emp.CalculateSalary();
            emp.DisplaySalary();
        }
        else if (choice == 2)
        {
            partTimeEmployee emp = new partTimeEmployee(id, name, salary);
            emp.CalculateSalary();
            emp.DisplaySalary();
        }
        else
        {
            Console.WriteLine("Invalid Choice!");
        }
        Console.WriteLine("\npress any key to exit..."); Console.ReadKey();
    }
}