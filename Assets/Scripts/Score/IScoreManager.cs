namespace Assets.Scripts.Score
{
    public interface IScoreManager
    {
       int Score { get; set; }
       void PlusValueToScore(int value);
       void MinusValueToScore(int value);
    }
}