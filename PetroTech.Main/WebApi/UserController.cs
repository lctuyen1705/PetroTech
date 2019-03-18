using AutoMapper;
using PetroTech.Main.Infa.Core;
using PetroTech.Main.Models;
using PetroTech.Main.Models.map;
using PetroTech.Model.Models;
using PetroTech.Service.Infa;
using PetroTech.Service.Manager;
using PetroTech.Service.Manager.inter;
using PetroTech.Service.Models;
using PetroTech.Service.Models.map;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PetroTech.Main.Infa.Extensions;
using PetroTech.Common.Resource;

namespace PetroTech.Main.WebApi
{
    [RoutePrefix("api/user")]
    public class UserController : ApiControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IInternalService _internalService;

        public UserController(ILogService logService,
                              IUserService userService,
                              IInternalService internalService,
                              IRoleService roleService) :
            base(logService)
        {
            this._internalService = internalService;
            this._roleService = roleService;
            this._userService = userService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _userService.GetAllUserPaging(keyword, page, pageSize);

                var query = Mapper.Map<IEnumerable<UserServiceModel>, IEnumerable<UserViewModel>>(model.Items);

                var responseData = new PaginationSet<UserViewModel>
                {
                    Items = query,
                    Page = model.Page,
                    TotalCount = model.TotalCount,
                    TotalPage = model.TotalPage,
                    Mess = model.Mess
                };

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallinfo")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _internalService.GetFuncRole();

                var query = Mapper.Map<FuncRoleServiceModel, FuncRoleViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, query);

                return response;
            });
        }

        [Route("checkuser")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string userName)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _userService.ValidationUser(userName);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, UserViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                var modelService = new UserServiceModel();

                var model = new ApplicationUser();

                var nofi = string.Empty;

                modelService.UpdateUser(user);

                model.MappingServiceToDataModelOfUser(modelService);

                if (!_userService.AddNewUser(model, modelService))
                    nofi = (Helper.Enum.Notification.STR_ADD_USER_SUCCESS).GetDescription();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, new { mess = nofi });

                return response;
            });
        }

        [Route("update")]
        [HttpGet]
        public HttpResponseMessage Put(HttpRequestMessage request, UserViewModel userViewModel)
        {
            HttpResponseMessage response = null;

            return response;
        }
    }
}