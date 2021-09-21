namespace ms.users.infrastructure.CQLRepositories
{
    public static class UserCQL
    {
        public const string GetUserByUserNameCql = "SELECT * FROM User WHERE user_username = ?";
    }
}
