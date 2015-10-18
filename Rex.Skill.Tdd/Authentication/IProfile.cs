namespace Rex.Skill.Tdd.Authentication
{
    public interface IProfile
    {
        string GetPassword(string account);
    }
}