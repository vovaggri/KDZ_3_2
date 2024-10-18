// Григорьев Владимир, БПИ-237, 10 вариант.
namespace KDZ_3_2;
using ClassLibrary;
class Program
{
    static void Main(string[] args)
    {
        //Повтор решения.
        do
        {
            Console.Clear();
            Methods.ColorPrint("Здравствуйте!", ConsoleColor.Yellow);
            Methods.ColorPrint("Вас приветствует программа обработки данных " +
                "json-файла.",
                ConsoleColor.Yellow);
            try
            {
                // Получение данных из файла.
                List<Book> books = JsonParser.ReadJson(out string jsonPath);
                //Обработка данных.
                books = Menu.Choice(books, jsonPath);
                // Запись файла.
                JsonParser.WriteJson(books);
                Methods.ColorPrint("Программа успешно завершила свою работу!",
                    ConsoleColor.Green);
            }
            // Обработка общих исключений.
            catch (Exception ex)
            {
                Methods.ColorPrint($"Критическая ошибка: {ex.Message}",
                        ConsoleColor.Red);
            }
            finally
            {
                Methods.ColorPrint("Если вы хотите завершить, нажмите Enter.\n" +
                    "Иначе другую клавишу.", ConsoleColor.Yellow);
            }
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }
}