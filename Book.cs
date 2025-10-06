using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommendationSystem
{
    public class Book
    {
        public int ISBN { get; set; }
        public required string Author { get; set; }
        public required string Title { get; set; }
        public required string Year { get; set; }

    }
}
