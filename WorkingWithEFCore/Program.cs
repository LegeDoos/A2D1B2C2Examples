using WorkingWithEFCore.Data;

namespace WorkingWithEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Working With EF Core!!!!");

            Northwind db = new Northwind(); ;
            Console.WriteLine($"Provider: {db.Database.ProviderName}");
        }
    }
}