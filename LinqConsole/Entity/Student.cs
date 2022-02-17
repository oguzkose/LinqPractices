using System.ComponentModel.DataAnnotations.Schema;

namespace LinqConsole.Entity
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassId { get; set; }
    }
}