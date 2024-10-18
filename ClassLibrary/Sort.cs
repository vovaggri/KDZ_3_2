using System;
namespace ClassLibrary
{
	public static class Sort
	{
		/// <summary>
		/// Общая сортировка.
		/// </summary>
		/// <param name="books"></param>
		/// <param name="i"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		private static List<Book> Sorting (List<Book> books, int i, int j)
		{
			Book temp = books[i];
			books[i] = books[j];
			books[j] = temp;
			return books;
		}

        /// <summary>
        /// Сортировка по строковым значениям.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="field"></param>
        /// <returns></returns>
		private static List<Book> SortStr(List<Book> books, int field)
		{
            // Сортировка bookId.
			if (field == 1)
			{
                Methods.ColorPrint("bookId.", ConsoleColor.Yellow);
				for (int i = 0; i < books.Count; i++)
				{
					for (int j = i+1; j < books.Count; j++)
					{
						if (string.Compare(books[i].BookId, books[j].BookId) > 0)
						{
							books = Sorting(books, i, j);
						}
					}
				}
            }
            // Сортировка title.
            if (field == 2)
			{
                Methods.ColorPrint("title.", ConsoleColor.Yellow);
				for (int i = 0; i < books.Count; i++)
				{
					for (int j = i+1; j < books.Count; j++)
					{
                        if (string.Compare(books[i].Title, books[j].Title) > 0)
                        {
                            books = Sorting(books, i, j);
                        }
                    }
				}
            }
            // Сортировка author.
            if (field == 3)
			{
                Methods.ColorPrint("author.", ConsoleColor.Yellow);
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = i + 1; j < books.Count; j++)
                    {
                        if (string.Compare(books[i].Author, books[j].Author) > 0)
                        {
                            books = Sorting(books, i, j);
                        }
                    }
                }
            }
            // Сортировка genre.
            if (field == 5)
			{
                Methods.ColorPrint("genre.", ConsoleColor.Yellow);
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = i + 1; j < books.Count; j++)
                    {
                        if (string.Compare(books[i].Genre, books[j].Genre) > 0)
                        {
                            books = Sorting(books, i, j);
                        }
                    }
                }
            }

			return books;
		}
        /// <summary>
        /// Сортировка по году или рейтингу
        /// </summary>
        /// <param name="books"></param>
        /// <param name="field"></param>
        /// <returns></returns>
		private static List<Book> SortYearOrRating(List<Book> books, int field)
		{
            // Сортировка publicationYear.
            if (field == 4)
			{
                Methods.ColorPrint("publicationYear.", ConsoleColor.Yellow);
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = i + 1; j < books.Count; j++)
                    {
                        if (books[i].PublicationYear > books[j].PublicationYear)
                        {
                            books = Sorting(books, i, j);
                        }
                    }
                }
            }
            // Сортировка rating.
            if (field == 6)
			{
                Methods.ColorPrint("rating.", ConsoleColor.Yellow);
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = i + 1; j < books.Count; j++)
                    {
                        if (books[i].Rating > books[j].Rating)
                        {
                            books = Sorting(books, i, j);
                        }
                    }
                }
            }

			return books;
        }

        /// <summary>
        /// Процесс сортировки.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static List<Book> SortProcessing(List<Book> books)
        {
            Console.Clear();
            Methods.ColorPrint("Сортировка.", ConsoleColor.Yellow);
            Methods.ColorPrint("Выберите цифру для какого поля" +
                " вы хотите сделать сортировку:", ConsoleColor.Yellow);
            Methods.ColorPrint("1. BookId.", ConsoleColor.Yellow);
            Methods.ColorPrint("2. Title.", ConsoleColor.Yellow);
            Methods.ColorPrint("3. Author.", ConsoleColor.Yellow);
            Methods.ColorPrint("4. PublicationYear.", ConsoleColor.Yellow);
            Methods.ColorPrint("5. Genre.", ConsoleColor.Yellow);
            Methods.ColorPrint("6. Кating.", ConsoleColor.Yellow);

            int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6)
                {
                    Console.WriteLine();
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6);

            Console.WriteLine();
            List<Book> sortBooks = new();
            if (n == 1 || n == 2 || n == 3 || n == 5)
            {
                sortBooks = SortStr(books, n);
            }
            if (n == 4 || n == 6)
            {
                sortBooks = SortYearOrRating(books, n);
            }

            return sortBooks;
        }
        /// <summary>
        /// В прямом или обратном порядке.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static List<Book> ReverseOrNot(List<Book> books)
        {
            Methods.ColorPrint("Как вы хотите отсортировать, в прямом порядке или " +
                "обратном (1/2)?", ConsoleColor.Yellow);
            Methods.ColorPrint("1. Прямой порядок.", ConsoleColor.Yellow);
            Methods.ColorPrint("2. Обратный порядок.", ConsoleColor.Yellow);

            int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2)
                {
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2);

            if (n == 1)
            {
                return books;
            }
            else
            {
                books.Reverse();
                return books;
            }
        }
	}
}