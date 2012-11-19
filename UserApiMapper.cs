namespace APIWebAPI
{
    public class UserApiMapper : IUserApiMapper
    {
        public bool UserAuthorizedFromAccessToken(string accessToken)
        {
            return accessToken == "fred";
        }
    }
}