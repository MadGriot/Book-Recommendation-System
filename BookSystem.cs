
namespace BookRecommendationSystem
{
    public static class BookSystem
    {
        public static List<Rating> Ratings = new();
        public static List<Book> Books = new();
        public static List<Member> Members = new();

        //
        private static readonly ICountAndStoreItem countAndStoreItem = new CountAndStoreItem();
        private static readonly IRecommendationSystem recommendationSystem = new RecommendationSystem();
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

        public static int CountAndStoreBooks(StreamReader reader) =>
            countAndStoreItem.CountAndStoreBooks(reader, Books);

        public static int CountAndStoreMembers(StreamReader reader) =>
            countAndStoreItem.CountAndStoreMembers(reader, Members, Books, Ratings);

        // Get similar users and recommend books based on their ratings
        public static void BookRecommendations(int accountNumber) =>
            recommendationSystem.BookRecommendations(accountNumber, Members, Ratings);


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

        public static void AddNewBook(Book book)
        {
            Books.Add(book);
            foreach (Member member in Members)
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
    }
}
