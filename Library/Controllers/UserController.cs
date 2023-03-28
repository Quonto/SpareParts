using Library.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Library.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public  class UserController : ControllerBase
	{

		private string constr = "Data Source=COMP\\SQL2022;Initial Catalog=Library;Integrated Security=True";


		[HttpPost]
		public  ActionResult<int> Register([FromBody] User user )
		{
			if(user.Password != user.ConfirmPassword)
			{
				return BadRequest("Bad Password");
			}

			string code = "abcd";

			using (SqlConnection con = new SqlConnection(constr))
			{
				string query = "insert into [User] values (@Firstname, @Lastname, @Email, @Password, @ConfirmPassword )";
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Connection = con;
					cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
					cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
					cmd.Parameters.AddWithValue("@Email", user.Email);
					cmd.Parameters.AddWithValue("@Password", user.Password);
					cmd.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);
					cmd.Parameters.AddWithValue("@Active", 0);
					cmd.Parameters.AddWithValue("@Code", code);

					con.Open();
					int i = cmd.ExecuteNonQuery();
					if (i > 0)
					{
						return Ok(i);
					}
					con.Close();
				}
			}
			return BadRequest();
		}
	}
}