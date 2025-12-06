namespace Application.DataTransferObjects.User
{
    public record LoginResponse
    {
        public bool Suceeded { get; set; }
        public string? Messenge { get; set; }
        public string? Token { get; set; }
    }
}
