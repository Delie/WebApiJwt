using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

using WebApiJwt.TokenHelpers;

namespace WebApiJwt.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		[HttpGet]
		public IEnumerable<string> Get() {
			//int? mofo = HttpContext.Session.GetInt32("mofo");
			//if (mofo == null) mofo = 0;
			//mofo = mofo + 1;
			//HttpContext.Session.SetInt32("mofo", (int)mofo);
			//return new string[] { "mofo", mofo.ToString() };

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