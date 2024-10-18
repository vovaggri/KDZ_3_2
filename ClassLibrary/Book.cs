namespace ClassLibrary;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Book
{
    /// <summary>
    /// Событие, отвечающее за изменение объекта Book.
    /// </summary>
    public event EventHandler<ObjectUpdatedEventArgs> Updated;

    /// <summary>
    /// Конструктор с параметрами.
    /// </summary>
    /// <param name="bookId"></param>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="publicationYear"></param>
    /// <param name="genre"></param>
    /// <param name="rating"></param>
    /// <param name="reviews"></param>
    [JsonConstructor]
    public Book(string bookId, string title, string author,
        int publicationYear, string genre, double rating,
        List<Review> reviews)
    {
        this.bookId = bookId;
        this.title = title;
        this.author = author;
        this.publicationYear = publicationYear;
        this.genre = genre;
        this.rating = rating;
        this.reviews = reviews;
    }

    private string bookId;
    [JsonPropertyName("bookId")]
    public string BookId
    {
        get { return bookId; } private set { bookId = value; }
    }

    private string title;
    [JsonPropertyName("title")]
    public string Title
    {
        get { return title; } set { title = value; }
    }

    private string author;
    [JsonPropertyName("author")]
    public string Author
    {
        get { return author; } set { author = value; }
    }

    private int publicationYear;
    [JsonPropertyName("publicationYear")]
    public int PublicationYear
    {
        get { return publicationYear; } set { publicationYear = value; }
    }

    private string genre;
    [JsonPropertyName("genre")]
    public string Genre
    {
        get { return genre; } set { genre = value; }
    }

    private double rating;
    [JsonPropertyName("rating")]
    public double Rating
    {
        get { return rating; } private set { rating = value; }
    }

    private List<Review> reviews;
    [JsonPropertyName("reviews")]
    public List<Review> Reviews
    {
        get { return reviews; }
        set
        {
            if (reviews != value)
            {
                reviews = value;
                UpdateRating();
                OnUpdated();
            }
        }
    }

    /// <summary>
    /// Метод, изменяющий рейтинг книги.
    /// </summary>
    public void UpdateRating()
    {
        double totalRaiting = 0;
        int reviewCount = 0;

        if (reviews != null)
        {
            foreach (var review in Reviews)
            {
                totalRaiting += review.Rating;
                reviewCount++;
            }
        }

        Rating = reviewCount > 0 ? totalRaiting / reviewCount : 0;
        Console.WriteLine($"Рейтинг книги изменился на {Rating:f2}.");
    }

    /// <summary>
    /// Вызов события OObjectUpdatedEventArgs().
    /// </summary>
    private void OnUpdated()
    {
        Updated?.Invoke(this, new ObjectUpdatedEventArgs());
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}