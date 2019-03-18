using PetroTech.Model.Models;
using PetroTech.Service.Manager;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetroTech.Main.Infa.Core
{
    public class ApiControllerBase : ApiController
    {
        private ILogService _logService;

        public ApiControllerBase(ILogService logService)
        {
            this._logService = logService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        //public IHttpActionResult Get(string lang)
        //{
        //    var resourceObject = new JObject();

        //    var resourceSet = Resources.Resources.ResourceManager.GetResourceSet(new CultureInfo(lang), true, true);
        //    IDictionaryEnumerator enumerator = resourceSet.GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        resourceObject.Add(enumerator.Key.ToString(), enumerator.Value.ToString());
        //    }

        //    return Ok(resourceObject);
        //}

        private void LogError(Exception ex)
        {
            Log error = new Log();
            error.ErrorId = Guid.NewGuid();
            error.CreatedDateTime = DateTime.Now;
            error.MessageError = ex.Message;
            error.StackTrance = ex.StackTrace;

            _logService.Create(error);
            _logService.Save();
        }
    }
}