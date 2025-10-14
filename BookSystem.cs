
namespace BookRecommendationSystem
{
    public static class BookSystem
    {
        public static List<Rating> Ratings = new();
        public static List<Book> Books = new();
        public static List<Member> Members = new();
        //public static void LoginMember(Member member) => member.IsLoggedIn = true;
        //public static void LogoutMember(Member member) => member.IsLoggedIn = false;

        public static void ViewRatings(int accountNumber)
        {
            Member member = Members[accountNumber];
            List<Rating> memberRatings = Ratings.Where(m => m.Member.AccountNumber == accountNumber).ToList();
            int indexNumber = 1;
            Console.WriteLine($"{member.Name} ratings...");
            foreach (Rating rating in memberRatings)
            {
                Console.WriteLine($"{indexNumber}) {rating.Book.Title}, {rating.Book.Year} => rating: {rating.RatingNumber}");
                indexNumber++;
            }
            Console.WriteLine();
        }

        public static void RateBook(int ISBN, int accountNumber, int ratingNumber)
        {
            Book book = Books.First(i => i.ISBN == ISBN);
            List<Rating> ratings = Ratings.Where(a => a.Member.AccountNumber == accountNumber).ToList();
            Rating rating = ratings.First(b => b.Book == book);
            rating.RatingNumber = ratingNumber;
            Console.WriteLine($"Your new rating for {book.Title}, {book.Year} => rating: {rating.RatingNumber}");
        }
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
                int memberIndex = count / 2;
                count++;
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
                }
                else
                {
                    Member member = new Member(line, memberIndex);
                    Members.Add(member);
                }
            }
            return Members.Count;
        }

        public static void BookRecommendations()
        {
            Dictionary<Book, int> books = new();

            foreach (Rating rating in Ratings)
            {

            }
        }

        public static void AddNewMember(Member member)
        {
            Members.Add(member);
            foreach (Book book in Books)
            {
                Rating rating = new Rating()
                {
                    Book = book,
                    Member = member,
                    RatingNumber = 0,
                };
                Ratings.Add(rating);
            }

        }
        public static int Dot(int a, int b) => a * b;
    }
}
