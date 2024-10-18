using System;
namespace ClassLibrary
{
	public static class Menu
	{
		public static List<Book> Choice(List<Book> books, string jsonPath)
		{
			Console.Clear();
            Methods.ColorPrint("Данные успешно записаны.", ConsoleColor.Green);
			Console.WriteLine("Выберите операцию над данными (1/2/3):");
			Console.WriteLine("1. Фильтрация.");
			Console.WriteLine("2. Сортировка.");
			Console.WriteLine("3. Изменение данных.");

			List<Book> resultBooks = new();

            int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2 && n!=3)
                {
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2 && n!= 3);

            if (n == 1)
            {
                resultBooks = Filtration.FiltrationProcess(books);
            }

            if (n == 2)
            {
                List<Book> pre_result = Sort.SortProcessing(books);
                resultBooks = Sort.ReverseOrNot(pre_result);
                return resultBooks;
            }

            if (n == 3)
            {
                resultBooks = Change.ChangeBooks(books, jsonPath);
            }

            return resultBooks;
        }
	}
}

