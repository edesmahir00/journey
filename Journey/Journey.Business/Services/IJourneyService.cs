using Journey.Business.Model.Request;
using Journey.Business.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Business.Services
{
    public interface IJourneyService
    {
        public Task<GetBusjourneysResponseModel> GetBusJourneys(GetBusjourneysRequestModel request, string apiUrl, string oauthToken);
    }
}
