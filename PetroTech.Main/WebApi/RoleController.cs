using AutoMapper;
using PetroTech.Main.Infa.Core;
using PetroTech.Main.Models;
using PetroTech.Service.Infa;
using PetroTech.Main.Infa.Extensions;
using PetroTech.Service.Manager;
using PetroTech.Service.Manager.inter;
using PetroTech.Service.Models;
using PetroTech.Service.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PetroTech.Common.Resource;

namespace PetroTech.Main.WebApi
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IInternalService _internalService;

        public RoleController(ILogService logService,
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
        public HttpResponseMessage Get(HttpRequestMessage request,
                                       string keyword,
                                       int page,
                                       int pageSize,
                                       string rolenameVal)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roleService.GetAllRolePaging(keyword, page, pageSize, rolenameVal);

                var query = Mapper.Map<IEnumerable<RoleServiceModel>, IEnumerable<RoleViewModel>>(model.Items);

                var responseData = new PaginationSet<RoleViewModel>
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

        [Route("del")]
        [HttpDelete]
        public HttpResponseMessage Del(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = _roleService.DeleteRole(id);

                    response = request.CreateResponse(HttpStatusCode.OK, model);
                }

                return response;
            });
        }

        [Route("checkrole")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string roleCode)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roleService.ValidationRoleCode(roleCode);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request, RoleViewModel roleViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                var modelService = new RoleServiceModel();

                var result = new ResultAPI<ErrorViewModel>();

                modelService.MappingDataRole(roleViewModel);

                var listErrors = _roleService.AddNewRole(modelService, false);

                if (listErrors.Count > 0)
                {
                    var data = Mapper.Map<List<ErrorServiceModel>, List<ErrorViewModel>>(listErrors);
                    result.ListData = data;
                    result.IsProcess = false;
                    result.Mess = (Helper.Enum.Notification.STR_ADD_ROLE_FAILD).GetDescription();
                }
                else
                {
                    result.IsProcess = true;
                    result.Mess = (Helper.Enum.Notification.STR_ADD_ROLE_SUCCESS).GetDescription();
                }

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, result);

                return response;
            });
        }
    }
}
