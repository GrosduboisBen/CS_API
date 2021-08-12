using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace win1_api.Controllers
{
	[ApiController]
	[Route("/home/hello")]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		public object Get()
		{
			var responseObject = new
			{
				etna = "Hello world!"
			};
			return responseObject;
		}
	}
}
