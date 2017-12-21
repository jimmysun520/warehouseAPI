using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using WarehouseApi.BusinessEntity;

namespace WarehouseApi.Extensions
{
    public class ApiResponseWrapper
    {
        private readonly RequestDelegate next;

        public ApiResponseWrapper(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var inlineResponseBody = context.Response.Body;

            using (var responseMemoryStream = new MemoryStream())
            {
                context.Response.Body = responseMemoryStream;
                await this.next(context);
                context.Response.Body = inlineResponseBody;
                responseMemoryStream.Seek(0, SeekOrigin.Begin);

                var responseFeature = context.Features.Get<IHttpResponseFeature>();

                var readStream = new StreamReader(responseMemoryStream).ReadToEnd();

                try
                {
                    var dataResponseResult = JsonConvert.DeserializeObject(readStream);

                    context.Items.TryGetValue("ErrorMessage", out object errorMessage);
                    context.Items.TryGetValue("StatusCode", out object StatusCode);

                    if (errorMessage != null && StatusCode != null)
                    {

                        var newResponse = StandardizedApiResponse.Create((HttpStatusCode)StatusCode, DateTime.Now, (string)errorMessage, null);
                        context.Response.StatusCode = (int)StatusCode;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(newResponse));
                    }
                    else
                    {

                        var newResponse = StandardizedApiResponse.Create((HttpStatusCode)context.Response.StatusCode, DateTime.Now, responseFeature.ReasonPhrase, dataResponseResult);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(newResponse));
                    }
                }
                catch (JsonException e)
                {

                    context.Items.TryGetValue("ErrorMessage", out object errorMessage);
                    context.Items.TryGetValue("StatusCode", out object StatusCode);

                    if (errorMessage != null && StatusCode != null)
                    {
                        var newResponse = StandardizedApiResponse.Create((HttpStatusCode)StatusCode, DateTime.Now, (string)errorMessage, null);
                        context.Response.StatusCode = (int)StatusCode;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(newResponse));
                    }
                    else
                    {
#if DEBUG
                        var newResponse = StandardizedApiResponse.Create(HttpStatusCode.InternalServerError, DateTime.Now, e.Message, null);
#else
                    var newResponse = StandardizedApiResponse.Create(HttpStatusCode.InternalServerError, DateTime.Now, "API response failure detected.",null);
#endif
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(newResponse));
                    }

                }
            }
        }
    }

}
