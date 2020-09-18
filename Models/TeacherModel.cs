using System;
using System.Data.Entity;

namespace Teacher_.Models
{
    public class TeacherModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Subject { get; set; }
        public decimal Salary { get; set; }
    }

    public class TeacherDBContext : DbContext
    {
        public DbSet<TeacherModel> Teachers { get; set; }
    }
}