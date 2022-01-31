using Journey.Business.Helpers;
using Journey.Business.Model.Request;
using Journey.Business.Model.Response;

namespace Journey.Business.Services
{
    public class JourneyService : IJourneyService
    {
        public async Task<GetBusjourneysResponseModel> GetBusJourneys(GetBusjourneysRequestModel request, string apiUrl, string oauthToken)
        {
            var httpRequestHelper = new HttpRequestHelper<GetBusjourneysRequestModel, GetBusjourneysResponseModel>();
            var response = await httpRequestHelper.Post(apiUrl, request, oauthToken);

            return response;
        }
    }
}
