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
        public string Author { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }

        public Book(int iSBN, string author, string title, string year)
        {
            ISBN = iSBN;
            Author = author;
            Title = title;
            Year = year;
        }
    }
}
