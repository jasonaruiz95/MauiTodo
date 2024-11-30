using System;
using SQLite;

namespace MauiTodo.Models
{
	public class TodoItem
	{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
		public string Title { get; set; }
		public DateTime Due { get; set; }
		public bool Done { get; set; } = false;
		public TodoItem()
		{
		}
	}
}

