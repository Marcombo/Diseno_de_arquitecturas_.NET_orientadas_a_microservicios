namespace JWT.API.Middlewares.DTOs
{
    public class TokenScopedDto
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
