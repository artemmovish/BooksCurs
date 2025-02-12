
namespace BooksCurs.models
{
    public class Author
    {
        public int author_id { get; set; }
        public string? name { get; set; }
        public string? lname { get; set; }
        public string? fname { get; set; }
        public string? biography { get; set; }
        public string? picture { get; set; }
        public DateOnly? created_at { get; set; }
        public DateOnly? updated_at { get; set; }

    }


}
