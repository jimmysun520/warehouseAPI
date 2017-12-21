using System;
using System.Net;

namespace WarehouseApi.BusinessEntity
{
    public class StandardizedApiResponse
    {
        public static StandardizedApiResponse Create(HttpStatusCode statusCode, DateTime transmitted, string errorMessage, object result = null)
        {
            return new StandardizedApiResponse(statusCode, transmitted, errorMessage, result);
        }

        public int StatusCode { get; set; }

        public DateTime Transmitted { get; set; }

        public string ErrorMessage { get; set; }

        public object Result { get; set; }

        protected StandardizedApiResponse(HttpStatusCode statusCode, DateTime transmitted, string errorMessage, object result = null)
        {
            StatusCode = (int)statusCode;
            Result = result;
            ErrorMessage = errorMessage;
            Transmitted = transmitted;
        }
    }
}
