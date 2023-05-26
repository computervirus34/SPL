namespace SPL.Models
{
    public class UserAuth
    {
        public Guid Id { get; set; }
        public string? UserGuid { get; set; }
        public bool Disable { get; set; }
    }
}
