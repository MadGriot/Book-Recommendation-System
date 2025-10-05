using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommendationSystem
{
    public class Member
    {
        public bool IsLoggedIn { get; set; }
        public int AccounterNumber { get; init; }
        public required string Name { get; set; }

        public List<Book>? BookRatings { get; set; }
    }
}
