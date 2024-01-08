using InClass3RM.Models;
using Microsoft.AspNetCore.Mvc;
using InClass3RM.Controllers;

namespace InClass3RM.Controllers
{
    public class OtherController : AbstractBaseController
    {
        public IActionResult Index()
        {
            var otherViewModel = new OtherPageViewModel()
            {
                UserTrackingMessage = GenerateUserTrackingMessage("OtherPage")
            };
            return View(otherViewModel);
        }
    }
}
