using Microsoft.AspNet.Identity.Owin;
using PetroTech.Main.Infa.Core;
using PetroTech.Service.Manager;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static PetroTech.Main.App_Start.IdentityConfig;

namespace PetroTech.Main.WebApi
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiControllerBase
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,
            ILogService logService) : base(logService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string passWord, bool isRememberMe)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, passWord, isRememberMe, shouldLockout: false);
            return request.CreateResponse(HttpStatusCode.OK, result);

            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //}
        }
    }
}