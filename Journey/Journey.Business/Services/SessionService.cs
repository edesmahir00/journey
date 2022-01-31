using Journey.Business.Helpers;
using Journey.Business.Model.Request;
using Journey.Business.Model.Response;

namespace Journey.Business.Services
{
    public class SessionService : ISessionService
    {
        public async Task<GetSessionResponseModel> GetSession(GetSessionRequestModel request, string apiUrl, string oauthToken)
        {
            var httpRequestHelper = new HttpRequestHelper<GetSessionRequestModel, GetSessionResponseModel>();
            var response = await httpRequestHelper.Post(apiUrl, request, oauthToken);

            return response;
        }
    }
}
