using System;

class Program
{
    static void Main()
    {
        int n;
        double amount, total = 0.0;
        string place, mode;

        try
        {
            Console.Write("How many expenses do you want to add? ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\nExpense " + i);

                Console.Write("Where did you spend? ");
                place = Console.ReadLine();

                Console.Write("Enter Expense Amount: ");
                amount = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Payment Mode (Cash/Card/UPI): ");
                mode = Console.ReadLine();

                total = total + amount;

                Console.WriteLine("Expense Added Successfully!");
            }

            Console.WriteLine("\nTotal Expense = Rs." + total);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Input! Please enter valid numbers.");
        }

        Console.ReadLine();
    }
}
