namespace LethalBingoAPI.Challenges
{
    public class BingoSpace(string id, Challenge challenge)
    {
        public string challengeId = id;
        public bool isComplete = false;
        public Challenge challenge = challenge;
        public string Description => challenge.description;
    }
}
