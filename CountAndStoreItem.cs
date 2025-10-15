using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookRecommendationSystem
{
    public class CountAndStoreItem : ICountAndStoreItem
    {
        public int CountAndStoreBooks(StreamReader reader, List<Book> books)
        {
            int count = 0;
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                count++;
                string[] bookData = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                Book book = new Book(count, bookData[0], bookData[1], bookData[2]);
                books.Add(book);
            }

            return books.Count;
        }

        public int CountAndStoreMembers(StreamReader reader, List<Member> members, List<Book> books, List<Rating> ratings)
        {
            int count = 0;
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                int memberIndex = count / 2;
                count++;
                if (count % 2 == 0)
                {
                    string[] ratingData = line.Split(' ');
                    for (int i = 0; i < ratingData.Length; i++)
                    {
                        if (i >= books.Count)
                            break;
                        Rating rating = new Rating()
                        {
                            Book = books[i],
                            Member = members[memberIndex],
                            RatingNumber = int.Parse(ratingData[i])
                        };
                        ratings.Add(rating);
                    }
                }
                else
                {
                    Member member = new Member(line, memberIndex);
                    members.Add(member);
                }
            }
            return members.Count;
        }
    }
}
