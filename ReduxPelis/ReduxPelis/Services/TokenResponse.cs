namespace ReduxPelis.Services
{
    public class TokenResponse
    {
        public bool IsTokenError { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}