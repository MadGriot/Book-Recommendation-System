
namespace BookRecommendationSystem
{
    public static class BookSystem
    {
        public static List<Rating> Ratings = new();
        public static List<Book> Books = new();
        public static List<Member> Members = new();

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
                Book book = new Book(count, bookData[0], bookData[1], bookData[2]);
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

        public static int CalculateSimilarity(Member member1, Member member2)
        {
            List<Rating> member1Ratings = Ratings.Where(r => r.Member.Equals(member1)).ToList();
            List<Rating> member2Ratings = Ratings.Where(r => r.Member.Equals(member2)).ToList();

            int similarity = 0;

            for (int i = 0; i < member1Ratings.Count; i++)
            {
                if (member1Ratings[i].RatingNumber != 0 && member2Ratings[i].RatingNumber != 0)
                {
                    similarity += member1Ratings[i].RatingNumber * member2Ratings[i].RatingNumber;
                }
            }
            return similarity;
        }

        // Get similar users and recommend books based on their ratings
        public static void BookRecommendations(int accountNumber)
        {
            Member member = Members[accountNumber];
            Dictionary<int, int> similarityScores = new Dictionary<int, int>();
            for (int i = 0; i < Members.Count; i++)
            {
                if (i == accountNumber)
                    continue;
                int similarity = CalculateSimilarity(member, Members[i]);
                similarityScores[i] = similarity;
            }

            var mostSimilarUsers = similarityScores.OrderByDescending(x => x.Value).ToList();

            int mostSimilarUserId = mostSimilarUsers.First().Key;
            Console.WriteLine($"Most similar user to {member.Name}: {Members[mostSimilarUserId].Name}");

            List<Book> recommendedBooks = new List<Book>();
            foreach (Rating rating in Ratings.Where(r => r.Member.AccountNumber == mostSimilarUserId + 1))
            {
                if (Ratings.Any(r => r.Member.AccountNumber == accountNumber + 1 && r.Book == rating.Book && r.RatingNumber == 0))
                {
                    recommendedBooks.Add(rating.Book);
                }
            }

            Console.WriteLine($"{member.Name}'s Recommended Books:");
            foreach (Book book in recommendedBooks.Take(4))
            {
                Console.WriteLine($"{book.ISBN}, {book.Title} ({book.Year}) by {book.Author}");
            }

            if (recommendedBooks.Count == 0)
            {
                Console.WriteLine("No new recommendations. You have rated all available books.");
            }

            Console.WriteLine();
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
