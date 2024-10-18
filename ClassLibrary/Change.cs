using System;
using System.Globalization;

namespace ClassLibrary
{
	public static class Change
	{
        private static AutoSaver autoSaver;

		/// <summary>
		/// Изменение title.
		/// </summary>
		/// <param name="books"></param>
		/// <param name="i"></param>
		/// <returns></returns>
        private static List<Book> ChangeTitle(List<Book> books, int i)
		{
			Console.WriteLine();
			Methods.ColorPrint("Title.", ConsoleColor.Yellow);
			Methods.ColorPrint($"Вы выбрали {books[i].Title}.", ConsoleColor.Yellow);
			Methods.ColorPrint($"BookId: {books[i].BookId}.", ConsoleColor.Yellow);
			Console.WriteLine("Введите новый заголовок книги:");
			string newTitle = Methods.InputStr();
			books[i].Title = newTitle;
			return books;
		}

        /// <summary>
        /// Изменение Author.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static List<Book> ChangeAuthor(List<Book> books, int i)
		{
			Console.WriteLine();
            Methods.ColorPrint("Author.", ConsoleColor.Yellow);
            Methods.ColorPrint($"Вы выбрали {books[i].Title}.", ConsoleColor.Yellow);
            Methods.ColorPrint($"BookId: {books[i].BookId}.", ConsoleColor.Yellow);
            Console.WriteLine("Введите новое имя автора:");
			string newAuthor = Methods.InputStr();
			books[i].Author = newAuthor;
			return books;
        }

        /// <summary>
        /// Изменение PublicationYear.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static List<Book> ChangePublicationYear(List<Book> books, int i)
		{
			Console.WriteLine();
            Methods.ColorPrint("Publication Year.", ConsoleColor.Yellow);
            Methods.ColorPrint($"Вы выбрали {books[i].Title}.", ConsoleColor.Yellow);
            Methods.ColorPrint($"BookId: {books[i].BookId}.", ConsoleColor.Yellow);
            Console.WriteLine("Введите год публикации книги, на который " +
				"хотите изменить:");
			int newYear = Methods.InputNum();
			books[i].PublicationYear = newYear;
			return books;
        }

        /// <summary>
        /// Изменение Genre.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static List<Book> ChangeGenre(List<Book> books, int i)
		{
			Console.WriteLine();
            Methods.ColorPrint("Genre.", ConsoleColor.Yellow);
            Methods.ColorPrint($"Вы выбрали {books[i].Title}.", ConsoleColor.Yellow);
            Methods.ColorPrint($"BookId: {books[i].BookId}.", ConsoleColor.Yellow);
            Console.WriteLine("Введите новый жанр:");
			string newGenre = Methods.InputStr();
			books[i].Genre = newGenre;
			return books;
        }

        /// <summary>
        /// Изменение ReviewerName от одного оценщика.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static List<Book> ChangeReviewerName(List<Book> books, int i, int j)
		{
			Methods.ColorPrint("ReviewerName.", ConsoleColor.Yellow);
			Console.WriteLine("Введите новое имя комментатора:");
			string newReviewerName = Methods.InputStr();
			books[i].Reviews[j].ReviewerName = newReviewerName;
			return books;
		}

        /// <summary>
        /// Изменение Rating от одного оценщика.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static List<Book> ChangeRating(List<Book> books, int i, int j)
		{
			Methods.ColorPrint("Rating.", ConsoleColor.Yellow);
			Console.WriteLine("Введите новую оценку от 1 до 10 (можно в дробях):");
			List<Book> newBooks = books;
			double newRating;
			do
			{
				newRating = Methods.InputDouble();
				if (newRating < 1 || newRating > 10)
				{
					Console.WriteLine();
					Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
						ConsoleColor.Red);
				}
			}
			while (newRating < 1 || newRating > 10);
			newBooks[i].Reviews[j].Rating = newRating;
			newBooks[i].UpdateRating();

            autoSaver.InvokeHandlerObjectUpdated(books[i], new ObjectUpdatedEventArgs());
            return newBooks;
		}

        /// <summary>
        /// Изменение Date от одного оценщика.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static List<Book> ChangeDate(List<Book> books, int i, int j)
		{
			Methods.ColorPrint("Date.", ConsoleColor.Yellow);
			Console.WriteLine("Введите новую дату в формате XXXX-XX-XX");
			string newDate;
			DateTime dateTime;

			do
			{
				newDate = Console.ReadLine();
				if (!DateTime.TryParseExact(newDate, "yyyy-MM-dd", null,
					DateTimeStyles.None, out dateTime))
				{
					Methods.ColorPrint("Введено неверное значение!\n" +
						"Формат должен быть XXXX-XX-XX", ConsoleColor.Red);
				}
			}
			while (!DateTime.TryParseExact(newDate, "yyyy-MM-dd", null,
					DateTimeStyles.None, out dateTime));

			books[i].Reviews[j].Date = newDate;
			return books;
		}

		/// <summary>
		/// Изменение списка оценщиков
		/// </summary>
		/// <param name="books"></param>
		/// <param name="i"></param>
		/// <returns></returns>
		private static List<Book> ChangeReviews(List<Book> books, int i)
		{
			List<Book> newBooks = new List<Book>();
			Console.WriteLine();
            Methods.ColorPrint("Reviews.", ConsoleColor.Yellow);
            Methods.ColorPrint($"Вы выбрали {books[i].Title}.", ConsoleColor.Yellow);
            Methods.ColorPrint($"BookId: {books[i].BookId}.", ConsoleColor.Yellow);
            Console.WriteLine("Выберите какого оценщика вы хотите изменить:");
			Console.WriteLine($"Выберите число от 1 до {books[i].Reviews.Count}:");
			for (int j = 0; j < books[i].Reviews.Count; j++)
			{
				Console.WriteLine($"{j+1}. {books[i].Reviews[j].ReviewerName}.");
			}

			int n1;
			do
			{
				n1 = Methods.InputNum();
				if (n1 < 1 || n1 > books[i].Reviews.Count)
				{
					Console.WriteLine();
					Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
						ConsoleColor.Red);
				}
			}
			while (n1 < 1 || n1 > books[i].Reviews.Count);

			Methods.ColorPrint($"Вы выбрали {books[i].Reviews[n1 - 1].ReviewerName}.",
				ConsoleColor.Yellow);
			Methods.ColorPrint($"ReviewerId: {books[i].Reviews[n1 - 1].ReviewId}.",
				ConsoleColor.Yellow);

			Console.WriteLine("Что вы хотите изменить из Reviews?");
			Console.WriteLine("Выберите цифру от 1 до 3:");
			Console.WriteLine("1. ReviewerName.");
			Console.WriteLine("2. Rating");
			Console.WriteLine("3. Date");

			int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2 && n != 3)
                {
                    Console.WriteLine();
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2 && n != 3);

			if (n == 1)
			{
				newBooks = ChangeReviewerName(books, i, n1 - 1);
			}
			if (n == 2)
			{
				newBooks = ChangeRating(books, i, n1 - 1);
            }
			if (n == 3)
			{
				newBooks = ChangeDate(books, i, n1 - 1);
			}

			return newBooks;
        }
		/// <summary>
		/// Изменение данных списка книг.
		/// </summary>
		/// <param name="books"></param>
		/// <param name="jsonPath"></param>
		/// <returns></returns>
		public static List<Book> ChangeBooks(List<Book> books, string jsonPath)
		{
			Console.Clear();
			List<Book> newBooks = books;
            autoSaver = new AutoSaver(books, jsonPath);
			// Повтор изменений.
            do
			{
				Methods.ColorPrint("Изменение данных.", ConsoleColor.Yellow);
				Console.WriteLine("Кому из списка вы хотите изменить информацию?:");
				Console.WriteLine($"Выберите число от 1 до {books.Count}:");
				for (int i = 0; i < books.Count; i++)
				{
					Console.WriteLine($"{i + 1}. {books[i].Title}.");
				}

				int n1;
				do
				{
					n1 = Methods.InputNum();
					if (n1 < 1 || n1 > books.Count)
					{
						Console.WriteLine();
						Methods.ColorPrint("Вы ввели некорректое число. Повторите ввод.",
							ConsoleColor.Red);
					}
				}
				while (n1 < 1 || n1 > books.Count);

				Console.WriteLine("Что вы хотите изменить из Books?");
				Console.WriteLine("Выберите цифру от 1 до 5:");
				Console.WriteLine("1. Title.");
				Console.WriteLine("2. Author.");
				Console.WriteLine("3. Publication Year.");
				Console.WriteLine("4. Genre.");
				Console.WriteLine("5. Reviews.");

				int n;
				do
				{
					n = Methods.InputNum();
					if (n != 1 && n != 2 && n != 3 && n != 4 && n != 5)
					{
						Console.WriteLine();
						Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
							ConsoleColor.Red);
					}
				}
				while (n != 1 && n != 2 && n != 3 && n != 4 && n != 5);
				if (n == 1)
				{
					newBooks = ChangeTitle(books, n1 - 1);
				}
				if (n == 2)
				{
					newBooks = ChangeAuthor(books, n1 - 1);
				}
				if (n == 3)
				{
					newBooks = ChangePublicationYear(books, n1 - 1);
				}
				if (n == 4)
				{
					newBooks = ChangeGenre(books, n1 - 1);
				}
				if (n == 5)
				{
					newBooks = ChangeReviews(books, n1 - 1);
				}

				Methods.ColorPrint("Данные успешно изменены!", ConsoleColor.Green);
				Methods.ColorPrint("Если вы не хотите больше ничего изменять, " +
					"нажмите Escape. Иначе другую клавишу", ConsoleColor.Yellow);
			}
			while (Console.ReadKey().Key != ConsoleKey.Escape);
			return newBooks;
        }
    }
}