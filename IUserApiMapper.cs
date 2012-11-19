namespace APIWebAPI
{
    public interface IUserApiMapper
    {
        bool UserAuthorizedFromAccessToken(string accessToken);
    }
}