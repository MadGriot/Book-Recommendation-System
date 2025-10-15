using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommendationSystem
{
    public interface IRecommendationSystem
    {
        int CalculateSimilarity(Member member1, Member member2, List<Rating> ratings);

        void BookRecommendations(int accountNumber, List<Member> members, List<Rating> ratings);
    }
}
