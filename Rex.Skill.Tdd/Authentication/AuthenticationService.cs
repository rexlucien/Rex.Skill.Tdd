using System.Runtime.CompilerServices;




namespace Rex.Skill.Tdd.Authentication
{
    internal class AuthenticationService
    {
        private readonly IProfile _profile;
        private readonly IToken _token;
        private readonly ILog _log;

        public AuthenticationService(IProfile profile, IToken token)
        {
            _profile = profile;
            _token = token;
        }

        public AuthenticationService(IProfile profile, IToken token, ILog log)
        {
            _profile = profile;
            _token = token;
            _log = log;
        }

        public bool IsValid(string account, string password)
        {
            // 根據 account 取得自訂密碼
            //var profileDao = new ProfileDao();
            var passwordFromDao = _profile.GetPassword(account);

            // 根據 account 取得 RSA token 目前的亂數
            //IToken rsaToken = new RsaTokenDao();
            var randomCode = _token.GetRandom(account);

            // 驗證傳入的 password 是否等於自訂密碼 + RSA token亂數
            var validPassword = passwordFromDao + randomCode;
            var isValid = password == validPassword;

            if (isValid) return true;

             var content = $"account:{account} try to login failed";

            _log?.Save(content);

            return false;
        }
    }
}