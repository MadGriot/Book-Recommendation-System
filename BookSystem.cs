
namespace BookRecommendationSystem
{
    public static class BookSystem
    {
        public static List<Rating> Ratings = new();
        public static List<Book> Books = new();
        public static List<Member> Members = new();
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

        public static int CountAndStoreBooks(StreamReader reader)
        {
            int count = 0;
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                count++;
                string[] bookData = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                DateTime date;
                Book book = new Book()
                {
                    ISBN = count,
                    Author = bookData[0],
                    Title = bookData[1],
                    Year = bookData[2]
                };
                Books.Add(book);
            }

            return Books.Count;
        }

        public static int CountAndStoreMembers(StreamReader reader)
        {
            int count = 0;
            string? line;
            while ((line = reader.ReadLine()) != null )
            {
                count++;
                int memberIndex = 0;
                if (count % 2 == 0)
                {
                    string[] ratingData = line.Split(' ');
                    for (int i = 0; i < ratingData.Length; i++)
                    {
                        if (i >= Books.Count)
                            break;
                        Rating rating = new Rating()
                        {
                            Book = Books[i],
                            Member = Members[memberIndex],
                            RatingNumber = int.Parse(ratingData[i])
                        };
                        Ratings.Add(rating);
                    }
                    memberIndex++;
                }
                else
                {
                    Member member = new Member(line);
                    Members.Add(member);
                }
            }
            return Members.Count;
        }
    }
}
