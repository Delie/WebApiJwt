using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

/// <summary>
/// Written by Andrew Delicata
/// https://github.com/Delie
/// </summary>
namespace WebApiJwt.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		[HttpGet]
		public IEnumerable<string> Get() {
			return new string[] { "This is the default GUEST root", "hooray!" };
		}

		[HttpGet]
		[Route("testguestroute")] //  api/values/testguestroute
		public IEnumerable<string> TestGuestRoute() {
			return new string[] { "This is a GUEST route", "hooray!" };
		}

		[Authorize]
		[HttpGet]
		[Route("testauthroute")] // api/values/testauthroute
		public IEnumerable<string> TestAuthRoute() {
			return new string[] { "This is an AUTHORIZED route", "hooray!" };
		}
	}
}