namespace JogoDaVelha
{
    public class Score
    {
        public string Player { get; private set; }
        public int Points { get; private set; }        

        public Score(string player)
        {
            this.Player = player;
        }

        public int SetPoints(int points)
        {
            this.Points += points;            

            return this.Points;
        }
    }
}
