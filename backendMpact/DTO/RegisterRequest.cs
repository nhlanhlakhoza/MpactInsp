namespace backendMpact.DTO
{
    public class RegisterRequest
    {
     
        public string FullName {  get; set; }
        public string LastName {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
<<<<<<< HEAD

        // 1 = Admin, 2 = Inspector
        public int RoleSelection { get; set; } = 2; // default to Inspector
=======
       
>>>>>>> c574684fc32a87db64fc2c3af5d90b6f6f83ce72
    }
}
