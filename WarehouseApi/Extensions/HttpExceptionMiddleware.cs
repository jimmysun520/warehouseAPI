using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
// using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WarehouseApi;
using WarehouseApi.BusinessEntity;

namespace WarehouseApi.Extensions
{
    internal class HttpExceptionMiddleware
    {
        private readonly RequestDelegate next;
        // private readonly Logger _Nlog = LogManager.GetCurrentClassLogger();
        public HttpExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (HttpException httpException)
            {
                // _Nlog.Log(LogLevel.Warn, httpException, "ErrorNo:{0}, Details: {1}", "HttpExceptionMiddleware.Invoke 1", httpException.Message);

                context.Response.StatusCode = httpException.StatusCode;
                var responseFeature = context.Features.Get<IHttpResponseFeature>();
                responseFeature.ReasonPhrase = httpException.Message;
            }
            catch (Exception otherException)
            {
                // _Nlog.Log(LogLevel.Error, otherException, "ErrorNo:{0}, Details: {1}", "HttpExceptionMiddleware.Invoke 2", otherException.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var responseFeature = context.Features.Get<IHttpResponseFeature>();
#if DEBUG
                responseFeature.ReasonPhrase = otherException.Message;
#else
                responseFeature.ReasonPhrase = "A server error has occurred, please contact the resource owner if you think this is a problem";
#endif
            }
        }
    }
}
