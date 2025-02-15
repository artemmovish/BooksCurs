using BooksCurs.models;

namespace BooksCurs.models
{
    public class Book
    {
        public int book_id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateOnly year_of_publication { get; set; }
        public string? picture { get; set; }
        public int? genre_id { get; set; }
        public int? author_id { get; set; }
        public int publication_id { get; set; }
        public int user_id { get; set; }
        public DateOnly? created_at { get; set; }
        public DateOnly? updated_at { get; set; }
        public Author? author { get; set; }
        public Genre? genre { get; set; }
        public Publication? publication { get; set; }
        public User? user { get; set; }


    }

}
