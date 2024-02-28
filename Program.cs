using System;
using System.Collections.Generic;


namespace Library
{
	internal class Program
	{
		static void Main()
		{
			const string CommandAddBook = "1";
			const string CommandRemoveBook = "2";
			const string CommandShowAllBooks = "3";
			const string CommandShowByName = "4";
			const string CommandShowByAuthor = "5";
			const string CommandShowByYear = "6";
			const string CommandExit = "7";

			BookStorage bookStorage = new BookStorage();

			bool isProgramActive = true;

			while (isProgramActive)
			{
				Console.WriteLine("Список команд:\n" +
						$"{CommandAddBook} - добавить книгу\n" +
						$"{CommandRemoveBook} - удалить книгу\n" +
						$"{CommandShowAllBooks} - показать все книги\n" +
						$"{CommandShowByName} - показать книги по названию\n" +
						$"{CommandShowByAuthor} - показать книги по автору\n" +
						$"{CommandShowByYear} - показать книги по году выхода\n" +
						$"{CommandExit} - выход из программы");
				Console.Write("Введите команду: ");
				string input = Console.ReadLine();

				switch (input)
				{
					case CommandAddBook:
						bookStorage.AddBook();
						break;

					case CommandRemoveBook:
						bookStorage.RemoveBook();
						break;

					case CommandShowAllBooks:
						bookStorage.ShowAllBooks();
						break;

					case CommandShowByName:
						bookStorage.ShowByName();
						break;

					case CommandShowByAuthor:
						bookStorage.ShowByAuthor();
						break;

					case CommandShowByYear:
						bookStorage.ShowByYear();
						break;

					case CommandExit:
						isProgramActive = false;
						break;

					default:
						Console.WriteLine("Неизвестная команда!");
						break;
				}

				Console.Write("Нажмите любую кнопку чтобы продолжить: ");
				Console.ReadKey();
				Console.Clear();
			}
		}
	}
}

class Book
{
	public Book(string name, string author, int yearRelease, int uniqueNumber)
	{
		Name = name;
		Author = author;
		YearRelease = yearRelease;
		UniqueNumber = uniqueNumber;
	}

	public string Name { get; private set; }
	public string Author { get; private set; }
	public int YearRelease { get; private set; }
	public int UniqueNumber { get; private set; }
}

class BookStorage
{
	private List<Book> _books;
	private int _uniqueNumber;

	public BookStorage()
	{
		_books = new List<Book>();
		_uniqueNumber = 1;
	}

	public void AddBook()
	{
		Console.Write("Введите название: ");
		string name = Console.ReadLine();

		Console.Write("Введите автора: ");
		string author = Console.ReadLine();

		Console.Write("Введите год выхода книги: ");

		if (int.TryParse(Console.ReadLine(), out int yearRelease))
		{
			_books.Add(new Book(name, author, yearRelease, _uniqueNumber));
			_uniqueNumber++;
		}
		else
		{
			Console.WriteLine("Неправильный вод года выхода книги.");
			Console.WriteLine("Попробуйте снова.");
		}
	}

	public void RemoveBook()
	{
		Console.Write("Напишите уникальный код книги, которую хотите удалить: ");

		if (int.TryParse(Console.ReadLine(), out int uniqueNumber))
		{
			Book bookToRemove = _books.Find(book => book.UniqueNumber == uniqueNumber);
			if (bookToRemove == null)
				Console.WriteLine("Нет книги с таким уникальным кодом");
			else
				_books.Remove(bookToRemove);
		}
		else
		{
			Console.WriteLine("Неправильный вод уникального кода. Попробуйте снова.");
		}
	}

	public void ShowAllBooks()
	{
		for (int i = 0; i < _books.Count; i++)
		{
			ShowBook(i);
		}
	}

	public void ShowByName()
	{
		Console.Write("Введите название книги: ");
		string name = Console.ReadLine();

		for (int i = 0; i < _books.Count; i++)
		{
			if (name.ToLower() == _books[i].Name.ToLower())
				ShowBook(i);
		}
	}

	public void ShowByAuthor()
	{
		Console.Write("Введите автора: ");
		string author = Console.ReadLine();

		for (int i = 0; i < _books.Count; i++)
		{
			if (author.ToLower() == _books[i].Author.ToLower())
				ShowBook(i);
		}
	}

	public void ShowByYear()
	{
		Console.Write("Введите год выхода книги: ");

		if (int.TryParse(Console.ReadLine(), out int year))
		{

			for (int i = 0; i < _books.Count; i++)
			{
				if (year == _books[i].YearRelease)
					ShowBook(i);
			}
		}
		else
		{
			Console.WriteLine("Неправильный вод года выхода книги.");
			Console.WriteLine("Попробуйте снова.");
		}
	}

	private void ShowBook(int index)
	{
		Console.WriteLine($"Уникальный номер книги {_books[index].UniqueNumber}: Название - {_books[index].Name}, " +
			$"автор - {_books[index].Author}, год выхода книги -  {_books[index].YearRelease}.");
	}
}