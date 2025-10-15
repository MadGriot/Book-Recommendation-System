using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommendationSystem
{
    internal interface ICountAndStoreItem
    {
        int CountAndStoreBooks(StreamReader reader, List<Book> books);

        int CountAndStoreMembers(StreamReader reader, List<Member> members, List<Book> books, List<Rating> ratings);
    }
}
