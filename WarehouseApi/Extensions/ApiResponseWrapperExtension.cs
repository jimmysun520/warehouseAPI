using Microsoft.AspNetCore.Builder;

namespace WarehouseApi.Extensions
{
    public static class ApiResponseWrapperExtensions
    {
        public static IApplicationBuilder UseApiResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiResponseWrapper>();
        }
    }
}
