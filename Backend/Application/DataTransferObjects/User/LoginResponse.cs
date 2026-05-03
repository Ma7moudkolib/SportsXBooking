namespace Application.DataTransferObjects.User
{
    public record AuthUser(int Id, string FullName, string Email, string Role);

    public record LoginResponse(bool Success, string Message, string Token, AuthUser User);
}
