
namespace BookRecommendationSystem
{
    public class RecommendationSystem : IRecommendationSystem
    {
        public void BookRecommendations(int accountNumber, List<Member> members, List<Rating> ratings)
        {
            Member member = members[accountNumber];
            Dictionary<int, int> similarityScores = new Dictionary<int, int>();
            for (int i = 0; i < members.Count; i++)
            {
                if (i == accountNumber)
                    continue;
                int similarity = CalculateSimilarity(member, members[i], ratings);
                similarityScores[i] = similarity;
            }

            var mostSimilarUsers = similarityScores.OrderByDescending(x => x.Value).ToList();

            int mostSimilarUserId = mostSimilarUsers.First().Key;
            Console.WriteLine($"Most similar user to {member.Name}: {members[mostSimilarUserId].Name}");

            List<Book> recommendedBooks = new List<Book>();
            foreach (Rating rating in ratings.Where(r => r.Member.AccountNumber == mostSimilarUserId + 1))
            {
                if (ratings.Any(r => r.Member.AccountNumber == accountNumber + 1 && r.Book == rating.Book && r.RatingNumber == 0))
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

        public int CalculateSimilarity(Member member1, Member member2, List<Rating> ratings)
        {
            List<Rating> member1Ratings = ratings.Where(r => r.Member.Equals(member1)).ToList();
            List<Rating> member2Ratings = ratings.Where(r => r.Member.Equals(member2)).ToList();

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
    }
}
