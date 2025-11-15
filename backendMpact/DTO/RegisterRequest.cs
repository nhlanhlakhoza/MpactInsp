namespace backendMpact.DTO
{
    public class RegisterRequest
    {
     
        public string FullName {  get; set; }
        public string LastName {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // 1 = Admin, 2 = Inspector
        public int RoleSelection { get; set; } = 2; // default to Inspector
    }
}
