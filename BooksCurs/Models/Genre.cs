using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCurs.models
{
    public class Genre
    {
        public int genre_id { get; set; }
        public string? style { get; set; }
        public DateOnly? created_at { get; set; }
        public DateOnly? updated_at { get; set; }
    }


}
