using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommendationSystem
{
    public class Rating
    {
        public required Book Book { get; set; }
        public required Member Member { get; set; }
        public int RatingNumber { get; set; }
    }
}
