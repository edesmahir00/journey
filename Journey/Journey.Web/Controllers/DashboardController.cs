using Journey.Business.Model.Domain;
using Journey.Business.Model.Response;
using Journey.Business.Services;
using Journey.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Journey.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IOptions<AppSettings> _options;
        private readonly ISessionService _sessionService;
        private readonly ILocationService _locationService;

        public DashboardController(IOptions<AppSettings> options, ISessionService sessionService, ILocationService locationService) // IHttpClientFactory clientFactory
        {
            _options = options;
            _sessionService = sessionService;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var cookieJourney = IsCookieJourneyExist();

            var responseService = await _sessionService.GetSession(new Business.Model.Request.GetSessionRequestModel()
            {
                Application = new Business.Model.Request.Application()
                {
                    Version = "3.1.0.0",
                    EquipmentId = "DD2A0857-7C7D-4376-A83B-E045435E82BB"
                },
                Type = 2,
                Connection = new Business.Model.Request.Connection()
            },
            _options.Value.OBiletApiSettings.BaseUrl + "/api/client/getsession",
            _options.Value.OBiletApiSettings.Authorization);

            var locations = await GetBusLocation(null, responseService.Data.SessionId, responseService.Data.DeviceId);
            //var locationsByFilter = await GetBusLocation("ist", responseService.Data.SessionId, responseService.Data.DeviceId);

            var response = new DashboardViewModel();
            response.FromLocations = await GetLocationSelectList(locations.Data, cookieJourney?.FromId == null ? "" : cookieJourney.FromId.ToString());
            response.ToLocations = await GetLocationSelectList(locations.Data, cookieJourney?.ToId == null ? "" : cookieJourney.ToId.ToString());
            response.SessionId = responseService.Data.SessionId;
            response.DeviceId = responseService.Data.DeviceId;
            response.DepartureDate = cookieJourney?.DepartureDate == null ? DateTime.Now.AddDays(1) : cookieJourney.DepartureDate;

            response.FromId = cookieJourney?.FromId == null ? 0 : cookieJourney.FromId; 
            response.ToId = cookieJourney?.ToId == null ? 0 : cookieJourney.ToId;


            return View(response);
        }

        public async Task<GetBusLocationsResponseModel> GetBusLocation(string text, string sessionId, string deviceId)
        {
            var response = await _locationService.GetBusLocations(new Business.Model.Request.GetBusLocationsRequestModel()
            {
                Data = text,
                DeviceSession = new Business.Model.Request.DeviceSession()
                {
                    DeviceId = deviceId,
                    SessionId = sessionId
                },
                Language = "tr-TR",
                Date = DateTime.Now
            },
            _options.Value.OBiletApiSettings.BaseUrl + "/api/location/getbuslocations",
            _options.Value.OBiletApiSettings.Authorization);

            return response;
        }


        private async Task<List<SelectListItem>> GetLocationSelectList(List<Datum> locations, string value)
        {
            var selectList = locations.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .ToList();

            foreach (var item in selectList)
                if (item.Value == value)
                {
                    item.Selected = true;
                    break;
                }
            return selectList;
        }

        private JourneyCookieModel IsCookieJourneyExist()
        {
            try
            {
                if (Request.Cookies["journey"] != null)
                {
                    var cookie = Request.Cookies["journey"];
                    var response = JsonConvert.DeserializeObject<JourneyCookieModel>(cookie);
                    return response;
                }
            }
            catch
            {
            }

            return null;
        }

    }
}
