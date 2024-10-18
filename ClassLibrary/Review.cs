using System;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    public class Review
    {
        /// <summary>
        /// Событие, отвечающее за изменение объекта Review.
        /// </summary>
        public event EventHandler<EventArgs> Updated;

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="reviewId"></param>
        /// <param name="reviewerName"></param>
        /// <param name="rating"></param>
        /// <param name="date"></param>
        [JsonConstructor]
        public Review(string reviewId, string reviewerName, double rating, string date)
        {
            this.reviewId = reviewId;
            this.reviewerName = reviewerName;
            this.rating = rating;
            this.date = date;
        }

        private string reviewId;
        [JsonPropertyName("reviewId")]
        public string ReviewId { get { return reviewId; } private set { reviewId = value; } }

        private string reviewerName;
        [JsonPropertyName("reviewerName")]
        public string ReviewerName
        {
            get { return reviewerName; }
            set { reviewerName = value; }
        }

        private double rating;
        [JsonPropertyName("rating")]
        public double Rating
        {
            get { return rating; }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    OnUpdated();
                }
            }
        }

        private string date;
        [JsonPropertyName("date")]
        public string Date { get { return date; } set { date = value; } }

        /// <summary>
        /// Вызов события.
        /// </summary>
        private void OnUpdated()
        {
            Console.WriteLine($"Оценка обновлена на {Rating}.");
            Updated?.Invoke(this, EventArgs.Empty);
        }


    }
}

