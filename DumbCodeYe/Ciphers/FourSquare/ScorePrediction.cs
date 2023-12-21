using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.FourSquare
{
    public class ScorePrediction
    {
        public List<CharacterScore> Scores;
        public int Index;

        public int PredictedCharacter { get { return Scores[Index].Character; } }
        public decimal ScoreJump { get {
                if (Index + 1 == Scores.Count)
                    return decimal.MaxValue;
                return Scores[Index + 1].Score - Scores[Index].Score;
            } }

        public ScorePrediction(List<CharacterScore> scores)
        {
            Scores = scores;
            Index = 0;
        }
    }
}
