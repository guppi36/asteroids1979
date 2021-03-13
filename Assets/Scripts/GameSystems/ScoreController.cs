namespace GameSystems
{
    public static class ScoreController
    {
        private static int _score = 0;
        public static int Score => _score;

        public static void ChangeScore(int change)
        {
            _score += change;
        }

        public static void ResetScore()
        {
            _score = 0;
        }
    }
}