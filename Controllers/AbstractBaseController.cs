using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace InClass3RM.Controllers
{
    public class AbstractBaseController : Controller
    {
        public string GenerateUserTrackingMessage(string pageName)
        {
            var sessionPageCount = GetAndIncrementPageVisitCountForSession(pageName);
            var totalPageCount = GetAndIncrementPageVisitCount(pageName);
            return $"You have visted this page a total of {totalPageCount} times, and {sessionPageCount} of those visit sare from this current session.";
        }

        private int GetAndIncrementPageVisitCount(string pageName)
        {

            var totalVisitKey = $"total_visit_count_{pageName}";
            var visitCountJson = Request.Cookies.ContainsKey(totalVisitKey) ? Request.Cookies[totalVisitKey] : "{}";
            var visitCounts = JsonConvert.DeserializeObject<Dictionary<string, int>>(visitCountJson);
            visitCounts.TryGetValue(pageName, out int pageCount);
            pageCount++;
            visitCounts[pageName] = pageCount;
            visitCountJson = JsonConvert.SerializeObject(visitCounts);
            Response.Cookies.Append(totalVisitKey, visitCountJson, new CookieOptions() { Expires = DateTime.Now.AddDays(30) });

            return pageCount;
        }

        private int GetAndIncrementPageVisitCountForSession(string pageName)
        {
            var sessionKey = $"session_visit_count_{pageName}";
            var pageCountForSession = (HttpContext.Session.GetInt32(sessionKey) ?? 0) + 1;
            HttpContext.Session.SetInt32(sessionKey, pageCountForSession);
            return pageCountForSession;
        }
    }
}
