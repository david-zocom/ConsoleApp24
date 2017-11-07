using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Book> böcker = new List<Book>();
			List<Author> författare = new List<Author>();
			var kombinerad = from bok in böcker
							 join förf in författare on
							 bok.Author equals förf.Name
							 select new
							 {
								 Title = bok.Title,
								 Author = bok.Author,
								 //Author = förf.Name,// bok.Author
								 Nationality = förf.Nationality
							 };
			Car c = new Car();
			c.IsStarting += CarStarting;
			c.IsDriving += CarStarting;
			c.Drive();
		}
		private static void CarStarting()
		{
			Console.WriteLine("Brum brum");
		}
	}
	public class Car
	{
		public event Action IsStarting;
		public event Action IsDriving;
		public void Drive()
		{
			Console.WriteLine("Startar och kör iväg");
			if(IsStarting!=null)
				IsStarting();
			IsDriving?.Invoke();
		}
	}

	public class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }
	}
	public class Author
	{
		public string Name { get; set; }
		public string Nationality { get; set; }
	}
}
