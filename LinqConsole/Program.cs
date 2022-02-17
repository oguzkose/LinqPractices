using System;
using System.Linq;
using LinqConsole.DbOperations;

namespace LinqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();

            var students = _context.Students.ToList();

            Console.WriteLine("Hello World!");
        }
    }
}
