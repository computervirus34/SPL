namespace SPL.Models
{
    public class ApiSettings
    {
        public string ExternalSystem { get; set; }
        public ApiSetting apiSetting { get; set; }
    }
    public class ApiSetting
    {
        public string BaseURL { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string ApiKey { get; set; } 
        public string ApiSecret { get; set; }
        public DateTime? ExpiresTime { get; set; }
        public int? Timeout { get; set; }
    }
}
