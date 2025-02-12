using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCurs.models
{
    public class Publication
    {
        public int publication_id { get; set; }
        public string? title { get; set; }
        public string? address { get; set; }
        public DateOnly? updated_at { get; set; }
        public DateOnly? created_at { get; set; }

    }


}
