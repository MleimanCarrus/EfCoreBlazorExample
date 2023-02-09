using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerEFCoreDemo.Models
{
	public class Car
	{
		public Car()
		{
		}


	public int Id { get; set; }
	public string Make { get; set; }
	public int year { get; set; }
public string Model { get; set; }
	}
}

