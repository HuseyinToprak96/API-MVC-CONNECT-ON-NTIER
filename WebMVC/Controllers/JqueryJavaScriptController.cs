using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class JqueryJavaScriptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
