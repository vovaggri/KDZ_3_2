using System;
using System.Text.Json;
namespace ClassLibrary
{
    public class AutoSaver
    {
        private readonly List<Book> books;
        private readonly string jsonPath;
        private int changesCount = 0;
        private DateTime lastChangeTime;

        public AutoSaver(List<Book> books, string jsonPath)
        {
            this.books = books;
            this.jsonPath = jsonPath;

            foreach (var book in books)
            {
                book.Updated += HandlerObjectUpdated;
            }
        }

        private void HandlerObjectUpdated(object sender, ObjectUpdatedEventArgs e)
        {
            // Проверяем, произошло ли изменение рейтинга.
            if (DateTime.Now - lastChangeTime <= TimeSpan.FromSeconds(15))
            {
                // Увеличиваем счетчик изменений.
                changesCount++;

                // Если два изменения за 15 секунд, сохраняем.
                if (changesCount >= 2)
                {
                    SaveToJsonAuto();
                    // Сбрасываем счетчик и время последнего изменения.
                    changesCount = 0;
                    lastChangeTime = DateTime.Now;
                }
            }
            else
            {
                // Сбрасываем счетчик и обновляем время последнего изменения.
                changesCount = 1;
                lastChangeTime = DateTime.Now;
            }
        }

        public void InvokeHandlerObjectUpdated(object sender, ObjectUpdatedEventArgs e)
        {
            HandlerObjectUpdated(sender, e);
        }

        // Сохранение в json файл, где к оригинальному названию добавляем tmp.
        private void SaveToJsonAuto()
        {
            string newJsonPath = $"{Path.GetDirectoryName(jsonPath)}" +
                                 $"{Path.DirectorySeparatorChar}" +
                                 $"{Path.GetFileNameWithoutExtension(jsonPath)}_tmp.json";

            string json = JsonSerializer.Serialize(books,
                new JsonSerializerOptions { WriteIndented = true });

            try
            {
                File.WriteAllText(newJsonPath, json);
                Methods.ColorPrint("Файл автоматически сохранен, так как за 15 секунд " +
                                   "произошли два изменения рейтинга!\n" +
                                   $"Файл находится на пути: {newJsonPath}", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Methods.ColorPrint($"Ошибка сохранения файла: {ex.Message}", ConsoleColor.Red);
            }
        }
    }

}

