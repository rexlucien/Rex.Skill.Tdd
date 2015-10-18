namespace Rex.Skill.Tdd.Authentication
{
    public interface IToken
    {
        string GetRandom(string account);
    }
}