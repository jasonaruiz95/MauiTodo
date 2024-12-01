using MauiTodo.Data;
using MauiTodo.Models;
using System.Collections.ObjectModel;

namespace MauiTodo;

public partial class MainPage : ContentPage
{
	public ObservableCollection<TodoItem> Todos { get; set; } = new();
	
	readonly Database _database;

	public MainPage()
	{
		InitializeComponent();
		_database = new Database();

		_ = Initialize();
	}

	private async Task Initialize()
	{
		var todos = await _database.GetTodos();

		foreach (var todo in todos)
		{
			Todos.Add(todo);
		}
			
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var todo = new TodoItem
		{
			Due = DueDatepicker.Date,
			Title = TodoTitleEntry.Text
		};


		var inserted = await _database.AddTodo(todo);

		if(inserted != 0)
		{
            Todos.Add(todo);

            TodoTitleEntry.Text = String.Empty;
			DueDatepicker.Date = DateTime.Now;
		}
	}
}


