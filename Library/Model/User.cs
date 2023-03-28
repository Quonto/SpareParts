namespace Library.Model
{
    public class User
    {
		public int Id { get; set; }

		public string Firstname { get; set; }

		public string Lastname { get; set; }

		public string Email { get; set; }

        public string Password { get; set; }

		public string ConfirmPassword { get; set; }

		public string Code { get; set; }

		public string Active { get; set; }
    }
}