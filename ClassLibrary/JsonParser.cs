using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
	public static class JsonParser
	{
        private static string jsonP;
        /// <summary>
        /// Чтение файла.
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
		public static List<Book> ReadJson(out string jsonPath)
		{
            jsonPath = "";
			List<Book> books = new();
			bool check = false;
            // Цикл для корректности ввода json-файла.
            do
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Введите АБСОЛЮТНЫЙ путь json-файла:");
                        jsonPath = Console.ReadLine();

                        if (jsonPath.Contains(".json"))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Methods.ColorPrint("Вы ввели файл с другим расширением." +
                                "\nПовторите ввод.", ConsoleColor.Red);
                            continue;
                        }
                    }

                    jsonP = jsonPath;
                    Console.WriteLine();
                    using StreamReader streamReader = new StreamReader(@jsonPath);
                    // Меняется поток чтения через файл.
                    Console.SetIn(streamReader);
                    StringBuilder stringBuilder = new StringBuilder();
                    string? data = Console.ReadLine()!;
                    // Чтение данных из файла.
                    while (!string.IsNullOrEmpty(data))
                    {
                        stringBuilder.Append(data);
                        data = Console.ReadLine();
                        stringBuilder.Append("\n");
                    }

                    string pre_content = stringBuilder.ToString();
                    string content = pre_content[..^1];

                    // Проверка на пустой файл.
                    if (string.IsNullOrEmpty(content))
                    {
                        throw new ArgumentNullException("Файл пустой!");
                    }

                    // Проверка на json формат.
                    if (content[0] != '[' || content[^1] != ']')
                    {
                        throw new ArgumentNullException("Данные не удовлетворяют условиям " +
                            "json-файла!");
                    }

                    books = JsonSerializer.Deserialize<List<Book>>(content);

                    if (books[0].BookId == null || books[0].Title == null)
                    {
                        throw new ArgumentNullException("Данные не совпадают.");
                    }

                    // Перенаправление потока обратно через консоль.
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                    check = true;
                }
                // Обработка исключений.
                catch (ArgumentNullException ex)
                {
                    Methods.ColorPrint("Oшибка! Возможно, вы ввели не тот файл." +
                        "\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                }
                catch (FileNotFoundException ex)
                {
                    Methods.ColorPrint("Ошибка! Файл не найден." +
                        "\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                }
                catch (DirectoryNotFoundException ex)
                {
                    Methods.ColorPrint("Ошибка! Часть файла не найдена или " +
                        "его директория.\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                }
                catch (IOException ex)
                {
                    Methods.ColorPrint("Ошибка при открытии файла и чтении структуры!" +
                        "\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                }
                catch (Exception ex)
                {
                    Methods.ColorPrint($"Критическая ошибка: {ex.Message} " +
                        $"\nПовторите ввод.", ConsoleColor.Red);
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                }
            } while (!check);

            return books;
		}

        /// <summary>
        /// Запись файла.
        /// </summary>
        /// <param name="books"></param>
        public static void WriteJson(List<Book> books)
        {
            Console.WriteLine();
            Methods.ColorPrint("Хотите сохранить ВЕСЬ результат в " +
                "json-файл (Да/Нет)?",
                ConsoleColor.Yellow);
            string choice = Methods.Choice();
            Console.WriteLine();
            if (choice.ToLower() == "да")
            {
                Methods.ColorPrint("Хотите перезаписать данные в исходном файле (Да) " +
                    "или записать на новый файл (Нет)?", ConsoleColor.Yellow);
                string choice1 = Methods.Choice();
                // Перезапись в исходный файл.

                if (choice1.ToLower() == "да")
                {
                    TextWriter old = Console.Out;
                    using (StreamWriter streamWriter = new StreamWriter(@jsonP, false))
                    {
                        Console.SetOut(streamWriter);
                        string json = JsonSerializer.Serialize(books,
                            new JsonSerializerOptions { WriteIndented = true });
                        streamWriter.Write(json);
                    }
                    Console.SetOut(old);
                    Methods.ColorPrint("Данные успешно записаны в файл!",
                        ConsoleColor.Green);
                }
                else
                {
                    TextWriter old = Console.Out;
                    Methods.ColorPrint("Создание или перезапись другого файла." +
                        "\nЕсли файла не существует, он создастся автоматически." +
                        "\nЕсли же введеный вами файл существует, то информация в нем " +
                        "поменяется!" +
                        "\nФайл должен иметь расширение .json", ConsoleColor.Yellow);
                    Console.WriteLine();
                    string newJsonPath;
                    bool check = false;
                    // Цикл для корректности ввода данных в json-файл.
                    do
                    {
                        try
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите АБСОЛЮТНЫЙ путь json-файла:");
                                newJsonPath = Console.ReadLine();

                                if (newJsonPath.Contains(".json"))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Methods.ColorPrint("Вы ввели файл с другим " +
                                        "расширением." +
                                        "\nПовторите ввод.", ConsoleColor.Red);
                                    continue;
                                }
                            }
                            // Перенаправление потока вывода через файл.
                            using (StreamWriter streamWriter = new StreamWriter(newJsonPath,
                                false))
                            {
                                Console.SetOut(streamWriter);
                                string json = JsonSerializer.Serialize(books,
                                    new JsonSerializerOptions { WriteIndented = true });
                                streamWriter.Write(json);
                            }
                            // Перенаправление потока вывода обратно через файл.
                            Console.SetOut(old);
                            Methods.ColorPrint("Данные успешно записаны в файл!",
                                ConsoleColor.Green);
                            check = true;
                        }
                        // Обработка исключений.
                        catch (ArgumentException ex)
                        {
                            Methods.ColorPrint("Введено неккоректное название файла, " +
                                "повторите попытку." +
                                $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                            check = false;
                            Console.SetOut(old);
                        }
                        catch (IOException ex)
                        {
                            Methods.ColorPrint("Возникла ошибка при открытии файла и " +
                                "записи структуры, повторите попытку." +
                                $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                            check = false;
                            Console.SetOut(old);
                        }
                        catch (Exception ex)
                        {
                            Methods.ColorPrint($"Критическая ошибка: {ex.Message} " +
                                $"\nПовторите ввод.", ConsoleColor.Red);
                            check = false;
                            Console.SetOut(old);
                        }
                    }
                    while (!check);
                }
            }
        }
    }
}