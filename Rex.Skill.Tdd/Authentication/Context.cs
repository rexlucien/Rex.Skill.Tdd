using System.Collections.Generic;

namespace Rex.Skill.Tdd.Authentication
{
    internal static class Context
    {
        internal static Dictionary<string, string> Profiles;

        static Context()
        {
            Profiles = new Dictionary<string, string> { { "joey", "91" }, { "mei", "99" } };
        }

        internal static string GetPassword(string key) => Profiles[key];
    }
}