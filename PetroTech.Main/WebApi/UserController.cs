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
using Nager.AmazonProductAdvertising;
using System;
using PetroTech.Service.Models.result;

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
        public HttpResponseMessage Get(HttpRequestMessage request,
                                        string keyword,
                                        int page,
                                        int pageSize,
                                        string usernameVal,
                                        string areaVal,
                                        string departmentVal,
                                        string statusVal)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _userService.GetAllUserPaging(keyword, page, pageSize, usernameVal, areaVal, departmentVal, statusVal);

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
                var model = _userService.ValidationUserName(userName);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request, UserViewModel userViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                var modelService = new UserServiceModel();

                var result = new ResultAPI<ErrorViewModel>();

                modelService.MapDataUser(userViewModel);

                var listErrors = _userService.ValidationUser(modelService, false);

                if (listErrors.Count > 0)
                {
                    var data = Mapper.Map<List<ErrorServiceModel>, List<ErrorViewModel>>(listErrors);
                    result.ListData = data;
                    result.IsProcess = false;
                    result.Mess = (Helper.Enum.Notification.STR_ADD_USER_FAILD).GetDescription();
                }
                else
                {
                    result.IsProcess = true;
                    result.Mess = (Helper.Enum.Notification.STR_ADD_USER_SUCCESS).GetDescription();
                }

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, result);

                return response;
            });
        }

        [Route("getbyuser/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUser(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {         
                var model = _userService.GetByUser(id);

                var modelView = Mapper.Map<UserServiceModel, UserViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, modelView);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, UserViewModel userViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                var modelService = new UserServiceModel();

                var result = new ResultAPI<ErrorViewModel>();

                modelService.MapDataUser(userViewModel);

                var listErrors = _userService.ValidationUser(modelService, true);

                if (listErrors.Count > 0)
                {
                    var data = Mapper.Map<List<ErrorServiceModel>, List<ErrorViewModel>>(listErrors);
                    result.ListData = data;
                    result.IsProcess = false;
                    result.Mess = (Helper.Enum.Notification.STR_UPDATE_USER_FAILD).GetDescription();
                }
                else
                {
                    result.IsProcess = true;
                    result.Mess = (Helper.Enum.Notification.STR_UPDATE_USER_SUCCESS).GetDescription();
                }

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, result);

                return response;
            });
        }
    }
}