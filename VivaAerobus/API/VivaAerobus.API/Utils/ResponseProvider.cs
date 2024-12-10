using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VivaAerobus.Domain.CQRS.Models;

namespace VivaAerobus.API.Utils
{
    public static class ResponseProvider
    {
        public static string GetUnauthorizedMessage()
        {
            var response = new BaseResponse<object>
            {
                Error = new Error(new UnauthorizedAccessException()),
                Result = new ResponseObject<object>(false, new object())
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
