using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCurs.models
{
    public class User
    {
        public int user_id { get; set; }
        public string? name { get; set; }
        public string? lname { get; set; }
        public string? fname { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public int role_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }

}
