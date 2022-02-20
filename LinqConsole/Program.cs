using System;
using System.Linq;
using LinqConsole.DbOperations;
using LinqConsole.Entity;

namespace LinqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();


            Console.WriteLine("***** ToList() , ToList<Entity>() *****");
            // ToList<entity>() veya ToList() Tüm veriyi List tipinde döner.
            var students = _context.Students.ToList<Student>();
            foreach (var item in students)
            {
                Console.WriteLine(item.Name);
            }


            Console.WriteLine("***** Find() *****");
            //Find() PrimaryKey'e göre veriyi döner.
            var student = _context.Students.Find(5);
            Console.WriteLine(student.Name);


            Console.WriteLine("***** Where() *****");
            // Where() Sorgu yazmamıza olanak tanır.
            var student2 = _context.Students.Where(x => x.StudentId == 2).ToList();
            foreach (var item in student2)
            {
                Console.WriteLine(item.Name + " " + item.Surname);

            }


            Console.WriteLine("***** FirstOrDefault() *****");
            //FirstOrDefault()
            var student3 = _context.Students.Where(x => x.ClassId == 2).FirstOrDefault();
            Console.WriteLine(student3.Name);

            var student4 = _context.Students.Where(x => x.Name == "James").FirstOrDefault();
            Console.WriteLine(student4.Name + " " + student4.Surname);

            var student5 = _context.Students.FirstOrDefault(x => x.Name == "James");
            Console.WriteLine(student5.Name + " " + student5.Surname);

            // First() ile FirstOrDefault() farkı : eğer aradığım kriterde veri yoksa FirsOrDefault
            // null dönerken , First hata fırlatır.

            try
            {
                var student6 = _context.Students.First(x => x.Surname == "Mustane");
                System.Console.WriteLine(student6.ClassId);
            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine("Message First():" + " " + ex.Message);
            }


            Console.WriteLine("***** SingleOrDefault() *****");


            //SingleOrDefault()
            // Tek bir veri veya null döneceğinden emin olduğumuz durumlarda SingleOrDefault'u kullanabiliriz.
            //Aksi takdirde hata fırlatır
            try
            {
                var student7 = _context.Students.SingleOrDefault(x => x.Name == "James");
                System.Console.WriteLine(student7.Surname);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Message SingleOrDefault():" + " " + ex.Message);
            }

            var student8 = _context.Students.SingleOrDefault(x => x.Name == "Kurt");
            Console.WriteLine(student8.Name + " " + student8.Surname);



            Console.WriteLine("***** OrderBy() *****");
            // a-z veya 1-n sıralama
            var studentList = _context.Students.OrderBy(x => x.StudentId).ToList();
            foreach (var std in studentList)
            {
                System.Console.WriteLine(std.StudentId + " " + std.Name + " " + std.Surname + " " + "Class: " + std.ClassId);
            }


            Console.WriteLine("***** OrderByDescending() *****");
            //z-a veya n-1 sıralama
            studentList = _context.Students.OrderByDescending(x => x.StudentId).ToList<Student>();

            foreach (var std in studentList)
            {
                System.Console.WriteLine(std.StudentId + " " + std.Name + " " + std.Surname + " " + "Class: " + std.ClassId);
            }

            System.Console.WriteLine("*****Anonymous Object Result*****");
            //Select() ile yeni bir object yaratılabilir
            var anonymousObject = _context.Students
                .Where(x => x.ClassId == 3)
                .Select(x => new
                {
                    Id = x.StudentId,
                    Fullname = x.Name + " " + x.Surname,
                    ClassId = x.ClassId
                });

            foreach (var obj in anonymousObject)
            {
                System.Console.WriteLine(obj.Id + "-" + obj.Fullname + "-" + obj.ClassId);
            }

        }
    }
}
