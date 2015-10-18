namespace Rex.Skill.Tdd.Authentication
{
    public class ProfileDao : IProfile
    {
        public string GetPassword(string account)
        {
            var result = Context.GetPassword(account);
            return result;
        }
    }
}