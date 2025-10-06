
namespace BookRecommendationSystem
{
    public class Member
    {
        public bool IsLoggedIn { get; set; }
        public Guid AccountNumber { get; init; }
        public string Name { get; set; }

        public List<Book>? BookRatings { get; set; }

        public Member(string name)
        {
            Name = name;
            AccountNumber = Guid.NewGuid();
        }
    }
}
