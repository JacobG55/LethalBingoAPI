using LethalBingoAPI.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LethalBingoAPI.Board
{
    public class BingoBoard
    {
        private static readonly Dictionary<string, Challenge> Challenges = new();
        private static BingoSpace[] BingoSpaces = new BingoSpace[25];

        public static bool RegisterChallenge(string id, Challenge challenge)
        {
            return Challenges.TryAdd(id.MakeValidId(), challenge);
        }

        public static void GenerateBoard()
        {
            List<KeyValuePair<string, Challenge>> challengeSelection = Challenges.ToList();
            for (int i = 0; i < 25; i++)
            {
                var pair = challengeSelection[UnityEngine.Random.Range(0, challengeSelection.Count)];
                challengeSelection.Remove(pair);
                BingoSpaces[i] = new BingoSpace(pair.Key, pair.Value);
                pair.Value.Reset();
            }
        }

        public static void CheckSpaces(string triggerKey, Func<Challenge, bool> validation)
        {
            // Probably only check this on the host and send some rpc to clients on challenge successes
            foreach (var space in BingoSpaces)
            {
                if (!space.isComplete && space.challenge.triggerKey.Equals(triggerKey) && validation(space.challenge))
                {
                    space.isComplete = space.challenge.Success();
                }
            }
        }
    }
}
