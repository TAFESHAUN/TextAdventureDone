namespace TextAdventureDone
{
    class ScoreEntry
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public ScoreEntry(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}