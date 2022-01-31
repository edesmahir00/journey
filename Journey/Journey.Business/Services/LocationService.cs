using Journey.Business.Helpers;
using Journey.Business.Model.Request;
using Journey.Business.Model.Response;

namespace Journey.Business.Services
{
    public class LocationService : ILocationService
    {
        public async Task<GetBusLocationsResponseModel> GetBusLocations(GetBusLocationsRequestModel request, string apiUrl, string oauthToken)
        {
            var httpRequestHelper = new HttpRequestHelper<GetBusLocationsRequestModel, GetBusLocationsResponseModel>();
            var response = await httpRequestHelper.Post(apiUrl, request, oauthToken);

            return response;
        }
    }
}
