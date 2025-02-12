using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCurs.models
{
    public class AuthResponse
    {
        public string? message { get; set; }
        public User? user { get; set; }
        public string? access_token { get; set; }
        public string? token_type { get; set; }
    }
}
