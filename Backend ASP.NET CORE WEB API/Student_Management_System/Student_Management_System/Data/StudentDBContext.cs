using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;

namespace Student_Management_System;
    public class StudentDBContext : DbContext
    {
    public StudentDBContext(DbContextOptions<StudentDBContext> options)
    : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

    }


