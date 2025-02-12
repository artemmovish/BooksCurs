using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCurs.models
{
    public class AuthorPublication
    {
        public int author_publications_id { get; set; }
        public string? title { get; set; }
        public string? type_of_publication { get; set; }
        public DateOnly? publication_date { get; set; }
        public int author_id { get; set; }
        public DateOnly? created_at { get; set; }
        public DateOnly? updated_ad { get; set; }
        public Author? author { get; set; }

    }


}
