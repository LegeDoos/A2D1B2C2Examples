using WorkingWithEFCore.Models;
using WorkingWithEFCore.Data;

namespace WorkingWithEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Working With EF Core!!!!");

            NorthwindDb db = new NorthwindDb(); ;
            Console.WriteLine($"Provider: {db.Database.ProviderName}");
        }
    }
}