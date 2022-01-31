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
    public class JourneyController : Controller
    {

        private readonly IOptions<AppSettings> _options;
        private readonly IJourneyService _journeyService;

        public JourneyController(IOptions<AppSettings> options, IJourneyService journeyService) 
        {
            _options = options;
            _journeyService = journeyService;
        }


        public async Task<IActionResult> SearchJourney(SearchJourneyRequestModel request)
        {
            if(ModelState.IsValid)
            {
                SetCookie(new JourneyCookieModel()
                {
                    DepartureDate=request.DepartureDate,
                    FromId=request.FromId,
                    ToId=request.ToId
                });
            }

            var responseService = await _journeyService.GetBusJourneys(new Business.Model.Request.GetBusjourneysRequestModel()
            {
                DeviceSession = new Business.Model.Request.DeviceSession()
                {
                    SessionId = request.SessionId,
                    DeviceId = request.DeviceId
                },
                Date = DateTime.Now,
                Language = "tr-TR",
                Data = new Business.Model.Request.Data()
                {
                    DepartureDate = request.DepartureDate.ToString("yyyy-MM-dd"),
                    DestinationId = request.ToId,
                    OriginId = request.FromId
                }
            },
            _options.Value.OBiletApiSettings.BaseUrl + "/api/journey/getbusjourneys",
            _options.Value.OBiletApiSettings.Authorization);

            var response = new AvaiableJourneysViewModel()
            {
                FromLocationText = responseService.Data.First().OriginLocation,
                ToLocationText = responseService.Data.First().DestinationLocation,
                DepartureDate = request.DepartureDate,
                FromId = request.FromId,
                ToId = request.ToId,
                SessionId = request.SessionId,
                DeviceId = request.DeviceId,
                AvaiableJourneysList = responseService.Data.OrderBy(x => x.Journey.Departure?.ToShortTimeString()).Select(y => new AvaiableJourneyViewModel()
                {
                    FromName = y.Journey.Origin,
                    ToName = y.Journey.Destination,
                    ArrivalTime=y.Journey.Arrival ?? DateTime.Now,
                    DepartureTime = y.Journey.Departure ?? DateTime.Now,
                    Price = y.Journey.OriginalPrice
                }).ToList()
            };

            return View("SearchJourney", response);
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

        private void SetCookie(JourneyCookieModel model)
        {

            var json = JsonConvert.SerializeObject(model);

            if (IsCookieJourneyExist() == null)
            {
                CookieOptions cookie = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(_options.Value.JourneyCookieDurationInMinutes)
                };
                Response.Cookies.Append("journey", json, cookie);
            }
            else
            {
                Response.Cookies.Delete("journey");
                CookieOptions cookie = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(_options.Value.JourneyCookieDurationInMinutes)
                };
                Response.Cookies.Append("journey", json, cookie);
            }
        }




    }
}
