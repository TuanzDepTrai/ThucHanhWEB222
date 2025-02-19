﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThucHanhWEB222.Models
{
	public class BookAuthor
	{
		[Key]
		public int ID { get; set; }
		
		public int BookID { get; set; }
		public Books Book { get; set; }

		public int AuthorID { get; set; }
		public Authors Author { get; set; }

	}
}
