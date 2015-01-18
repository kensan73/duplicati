namespace Duplicati.Library.Backend.MediaFire
{
    public class GetSessionTokenResponse
    {
        public string action { get; set; }
        public string session_token { get; set; }
        public string SecretKey { get; set; }
        public string time { get; set; }
        public string result { get; set; }
        public string current_api_version { get; set; }
    }
}