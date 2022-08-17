using LtiLibrary.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Typsy.LTI.Consumer.Sample.ViewModels.ConsumerTest;

namespace Typsy.LTI.Consumer.Sample.Controllers
{
    public class ConsumerTestController : Controller
    {
        [Route("/launch")]
        public IActionResult LaunchLtiRequest()
        {
            var viewmodel = new LaunchLtiRequestViewModel();
            viewmodel.Initialize();
            return View(viewmodel);
        }
    }
}
