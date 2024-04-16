using System.ComponentModel.DataAnnotations;

namespace ThucHanhWEB222.Models
{
	public class Authors
	{
		[Key]
		public int AuthorID { get; set; }	
		public string? FullName { get; set; }
		public List<BookAuthor> Book_Authors { get; set; }
	}
}
