using Journey.Business.Model.Request;
using Journey.Business.Model.Response;

namespace Journey.Business.Services
{
    public interface ILocationService
    {
        public Task<GetBusLocationsResponseModel> GetBusLocations(GetBusLocationsRequestModel request, string apiUrl, string oauthToken);
    }
}
