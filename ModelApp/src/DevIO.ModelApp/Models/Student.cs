using System;

namespace DevIO.ModelApp.Models
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
