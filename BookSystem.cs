using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommendationSystem
{
    public static class BookSystem
    {
        public static List<Rating> Library = new();
        public static void LoginMember(Member member) => member.IsLoggedIn = true;
        public static void LogoutMember(Member member) => member.IsLoggedIn = false;

        public static Rating RateBook(Member member, Book book, int ratingNumber)
        {
            Rating? rating = null;
            if (member.IsLoggedIn)
            {
                rating = new Rating
                {
                    Book = book,
                    RatingNumber = ratingNumber,
                    Member = member
                };
                return rating;
            }
            else
            {
                Console.WriteLine("User is not logged In!");
                return rating;
            }
        }
    }
}
