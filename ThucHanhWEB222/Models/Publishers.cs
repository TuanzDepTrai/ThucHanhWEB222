﻿		using System.ComponentModel.DataAnnotations;

		namespace ThucHanhWEB222.Models
		{
			public class Publishers
			{
				[Key]
				public int PublisherID { get; set; }	
				public string? Name { get; set; }
				public List<Books> Book { get; set; }
			}
		}
