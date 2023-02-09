using System;
namespace BlazorServerEFCoreDemo.Models
{
	public class Grade
	{
		public Grade()
		{
		}

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}

