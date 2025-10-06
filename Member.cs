
namespace BookRecommendationSystem
{
    public class Member
    {
        public bool IsLoggedIn { get; set; }
        public int AccountNumber { get; init; }
        public string Name { get; set; }


        public Member(string name, int accountNumber)
        {
            Name = name;
            AccountNumber = accountNumber;
        }
    }
}
