namespace Application.DataTransferObjects.User
{
    public record LoginResponse(bool Success, string Message, string? Token = "", GetUserDto? user = null);
}
