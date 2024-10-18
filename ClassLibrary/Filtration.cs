using System;
namespace ClassLibrary
{
	public static class Filtration
	{
        /// <summary>
        /// Фильтрация по полям с типом string.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static List<Book> FiltrBooks_Str(List<Book> books, string property)
        {
            List<Book> filtrBooks = new();

            do
            {
                if (property == "ID")
                {
                    Console.WriteLine("Введите значение для фильтрации поля bookId:");
                    string value = Methods.InputStr();
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].BookId.Contains(value))
                        {
                            //AddLast(ref filtrBooks, books[i]);
                            filtrBooks.Add(books[i]);
                        }
                    }
                }

                else if (property == "title")
                {
                    Console.WriteLine("Введите значение для фильтрации поля title:");
                    string value = Methods.InputStr();
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].Title.Contains(value))
                        {
                            filtrBooks.Add(books[i]);
                        }
                    }
                }

                else if (property == "author")
                {
                    Console.WriteLine("Введите значение для фильтрации поля author:");
                    string value = Methods.InputStr();
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].Author.Contains(value))
                        {
                            filtrBooks.Add(books[i]);
                        }
                    }
                }

                else if (property == "genre")
                {
                    Console.WriteLine("Введите значение для фильтрации поля genre:");
                    string value = Methods.InputStr();
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].Genre.Contains(value))
                        {
                            filtrBooks.Add(books[i]);
                        }
                    }
                }

                if (filtrBooks.Count == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrBooks.Count == 0);

            return filtrBooks;
        }

        /// <summary>
        /// Фильтрация по полю publicationYear.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        private static List<Book> FiltrBooks_PublicationYear(List<Book> books)
        {
            List<Book> filtrBooks = new();

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля publicationYear:");
                int value = Methods.InputNum();
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].PublicationYear == value)
                    {
                        filtrBooks.Add(books[i]);
                    }
                }

                if (filtrBooks.Count == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrBooks.Count == 0);

            return filtrBooks;
        }

        /// <summary>
        /// Фильтрация по полю rating.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        private static List<Book> FiltrBooks_Rating(List<Book> books)
        {
            List<Book> filtrBooks = new();

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля rating:");
                double value = Methods.InputDouble();
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].Rating == value)
                    {
                        filtrBooks.Add(books[i]);
                    }
                }

                if (filtrBooks.Count == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrBooks.Count == 0);

            return filtrBooks;
        }

        /// <summary>
        /// Фильтрация по полям с типом string во вложенных списках.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static List<Book> FiltrBook_R_Str(List<Book> books, string property)
        {
            List<Book> filtrBooks = new();

            do
            {
                if (property == "ID")
                {
                    Console.WriteLine("Введите значение для фильтрации поля reviewId:");
                    string value = Methods.InputStr();
                    for (int i = 0; i < books.Count; i++)
                    {
                        for (int j = 0; j < books[i].Reviews.Count; j++)
                        {
                            if (books[i].Reviews[j].ReviewId.Contains(value))
                            {
                                filtrBooks.Add(books[i]);
                                break;
                            }
                        }
                    }
                }

                else if (property == "reviewerName")
                {
                    Console.WriteLine("Введите значение для фильтрации поля reviewerName:");
                    string value = Methods.InputStr();
                    for (int i = 0; i < books.Count; i++)
                    {
                        for (int j = 0; j < books[i].Reviews.Count; j++)
                        {
                            if (books[i].Reviews[j].ReviewerName.Contains(value))
                            {
                                filtrBooks.Add(books[i]);
                                break;
                            }
                        }
                    }
                }

                else if (property == "date")
                {
                    Console.WriteLine("Введите значение для фильтрации поля date:");
                    string value = Methods.InputStr();
                    for (int i = 0; i < books.Count; i++)
                    {
                        for (int j = 0; j < books[i].Reviews.Count; j++)
                        {
                            if (books[i].Reviews[j].Date.Contains(value))
                            {
                                filtrBooks.Add(books[i]);
                                break;
                            }
                        }
                    }
                }

                if (filtrBooks.Count == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrBooks.Count == 0);
            return filtrBooks;
        }

        /// <summary>
        /// Фильтрация по полю rating из reviews.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        private static List<Book> FiltrBook_R_Rating(List<Book> books)
        {
            List<Book> filtrBooks = new();

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля rating:");
                double value = Methods.InputDouble();
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = 0; j < books[i].Reviews.Count; j++)
                    {
                        if (books[i].Reviews[j].Rating == value)
                        {
                            filtrBooks.Add(books[i]);
                            break;
                        }
                    }
                }

                if (filtrBooks.Count == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrBooks.Count == 0);
            return filtrBooks;
        }

        /// <summary>
        /// Фильтрация по полю reviews.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        private static List<Book> FiltrBooks_Reviews(List<Book> books)
        {
            List<Book> filtrBooks = new();

            Methods.ColorPrint("Фильтрация списков reviews.", ConsoleColor.Yellow);
            Methods.ColorPrint("Выберите цифру для какого поля из review" +
                " вы хотите сделать фильтрацию:", ConsoleColor.Yellow);
            Methods.ColorPrint("1. ReviewId.", ConsoleColor.Yellow);
            Methods.ColorPrint("2. ReviewerName.", ConsoleColor.Yellow);
            Methods.ColorPrint("3. Rating.", ConsoleColor.Yellow);
            Methods.ColorPrint("4. Date.", ConsoleColor.Yellow);

            int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2 && n != 3 && n != 4)
                {
                    Console.WriteLine();
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2 && n != 3 && n != 4);

            if (n == 1)
            {
                Methods.ColorPrint("ReviewId", ConsoleColor.Yellow);
                filtrBooks = FiltrBook_R_Str(books, "ID");
            }
            if (n == 2)
            {
                Methods.ColorPrint("ReviewerName", ConsoleColor.Yellow);
                filtrBooks = FiltrBook_R_Str(books, "reviewerName");
            }
            if (n == 3)
            {
                Methods.ColorPrint("Rating", ConsoleColor.Yellow);
                filtrBooks = FiltrBook_R_Rating(books);
            }
            if (n == 4)
            {
                Methods.ColorPrint("Date", ConsoleColor.Yellow);
                filtrBooks = FiltrBook_R_Str(books, "date");
            }
            return filtrBooks;
        }

        /// <summary>
        /// Процесс фильтрации.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static List<Book> FiltrationProcess(List<Book> books)
        {
            List<Book> filtrBooks = new();
            Console.Clear();
            Methods.ColorPrint("Фильтрация", ConsoleColor.Yellow);
            Methods.ColorPrint("Выберите цифру для какого поля" +
                " вы хотите сделать фильтрацию:", ConsoleColor.Yellow);
            Methods.ColorPrint("1. BookId.", ConsoleColor.Yellow);
            Methods.ColorPrint("2. Title.", ConsoleColor.Yellow);
            Methods.ColorPrint("3. Author.", ConsoleColor.Yellow);
            Methods.ColorPrint("4. PublicationYear.", ConsoleColor.Yellow);
            Methods.ColorPrint("5. Genre.", ConsoleColor.Yellow);
            Methods.ColorPrint("6. Rating.", ConsoleColor.Yellow);
            Methods.ColorPrint("7. Список reviews.", ConsoleColor.Yellow);

            int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6 && n != 7)
                {
                    Console.WriteLine();
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6 && n != 7);
            if (n == 1)
            {
                Methods.ColorPrint("BookId.", ConsoleColor.Yellow);
                filtrBooks = FiltrBooks_Str(books, "ID");
            }
            if (n == 2)
            {
                Methods.ColorPrint("Title.", ConsoleColor.Yellow);
                filtrBooks = FiltrBooks_Str(books, "title");
            }
            if (n == 3)
            {
                Methods.ColorPrint("Author.", ConsoleColor.Yellow);
                filtrBooks = FiltrBooks_Str(books, "author");
            }
            if (n == 4)
            {
                Methods.ColorPrint("PublicationYear.", ConsoleColor.Yellow);
                filtrBooks = FiltrBooks_PublicationYear(books);
            }
            if (n == 5)
            {
                Methods.ColorPrint("Genre.", ConsoleColor.Yellow);
                filtrBooks = FiltrBooks_Str(books, "genre");
            }
            if (n == 6)
            {
                Methods.ColorPrint("Rating.", ConsoleColor.Yellow);
                filtrBooks = FiltrBooks_Rating(books);
            }
            if (n == 7)
            {
                Methods.ColorPrint("Список reviews.", ConsoleColor.Yellow);
                filtrBooks = FiltrBooks_Reviews(books);
            }
            return filtrBooks;
        }
	}
}