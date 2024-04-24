namespace Authentication.Model
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
    }
}
