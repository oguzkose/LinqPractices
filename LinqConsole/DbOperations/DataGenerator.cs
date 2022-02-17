using System.Linq;
using LinqConsole.Entity;

namespace LinqConsole.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if (context.Students.Any())
                {
                    return;
                }
                context.Students.AddRange(
                    new Student()
                    {
                        Name = "John",
                        Surname = "Doe",
                        ClassId = 1
                    },
                    new Student()
                    {
                        Name = "Jane",
                        Surname = "Doe",
                        ClassId = 2

                    },
                    new Student()
                    {
                        Name = "Lars",
                        Surname = "Ulrich",
                        ClassId = 3
                    },
                    new Student()
                    {
                        Name = "Kurt",
                        Surname = "Cobain",
                        ClassId = 1
                    },
                    new Student()
                    {
                        Name = "David",
                        Surname = "Bowie",
                        ClassId = 2
                    }



                );
                context.SaveChanges();
            }
        }
    }
}