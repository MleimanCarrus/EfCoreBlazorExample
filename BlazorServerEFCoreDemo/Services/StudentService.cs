using System;
using BlazorServerEFCoreDemo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerEFCoreDemo.Services
{
	public class StudentService : IStudentService
	{
		[Inject] private IDbContextFactory<ApplicationDbContext> _dbFactory { get; set; }

		private ApplicationDbContext _dbContext;

		public StudentService(IDbContextFactory<ApplicationDbContext> dbFactory, ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbFactory = dbFactory;
		}

		public List<Student> GetStudents()
		{
			try
			{
				using var db = _dbFactory.CreateDbContext();
				return db.Students
					.Include(x => x.Grade)
					.ToList();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public Student GetStudentById(int studentId)
		{
            try
            {
                using var db = _dbFactory.CreateDbContext();
				Student result = db.Students
					.Include(x => x.Grade)
					.Where(x => x.StudentID == studentId)
					.AsNoTracking()
					.FirstOrDefault();

				result ??= new Student();
				return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

		public Student AddStudent(Student student)
		{
			try
			{
				var grade = new Grade();
				grade.GradeId = student.StudentID;
                string[] grades = { "A", "B", "C", "D", "F" };
                Random rand = new Random();
                int index = rand.Next(grades.Length);
				grade.GradeName = grades[index];
				grade.Section = "History";


                using var db = _dbFactory.CreateDbContext();
				student.Photo = GetByteArray(5);
				student.Grade = grade;
                db.Students.Add(student);
                db.SaveChanges();

                return student;
            }
			catch (Exception ex)
			{
				throw;
				return null;
			}	
		}


		public Grade GetGrade(int GradeId)
		{
            try
            {
                using var db = _dbFactory.CreateDbContext();
                Grade result = db.Grades
                    .Include(x => x.Students)
                    .Where(x => x.GradeId == GradeId)
                    .AsNoTracking()
                    .FirstOrDefault();

                result ??= new Grade();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private byte[] GetByteArray(int sizeInKb)
        {
            Random rnd = new Random();
            byte[] b = new byte[sizeInKb * 1024]; // convert kb to byte
            rnd.NextBytes(b);
            return b;
        }

    }
}

