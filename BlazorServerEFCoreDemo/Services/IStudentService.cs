using System;
using BlazorServerEFCoreDemo.Models;

namespace BlazorServerEFCoreDemo.Services
{
	public interface IStudentService
	{
        public List<Student> GetStudents();

        public Student GetStudentById(int studentId);

        public Student AddStudent(Student student);

    }
}

