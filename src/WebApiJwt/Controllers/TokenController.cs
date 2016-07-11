using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

using WebApiJwt.TokenHelpers;

namespace WebApiJwt.Controllers
{
	[Route("api/[controller]")]
	public class TokenController : Controller
	{
		public class TokenCredentials
		{
			public string Username { get; set; }
			public string Password { get; set; }
		}

		[HttpPost]
		public dynamic Post([FromBody] TokenCredentials req) {
			string token = "";

			if (req != null)
			{
				if (!string.IsNullOrWhiteSpace(req.Username) && !string.IsNullOrWhiteSpace(req.Password))
				{
					bool bValidLogin = false;
					// Verify username and password 
					// insert your user validation code here - IMPORTANT!

					// TEMP DEBUG MODE!! 
					bValidLogin = true;

					if (bValidLogin)
						token = TokenManager.CreateToken(req.Username);
				}
			}

			return new { authenticated = (token != ""), token = token };
		}
	}
}
