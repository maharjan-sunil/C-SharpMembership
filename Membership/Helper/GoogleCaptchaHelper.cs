using Membership.Constant;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Membership.Helper
{

    public static class GoogleCaptchaHelper
    {
        public static IHtmlString CaptchaHelper(this HtmlHelper helper)
        {
            const string _googleSiteKey = SystemConstant.GoogleReCaptchaSiteId;
            const string _googleCaptchaUri = "<script src='" +
                SystemConstant.GoogleCaptchaScriptUri + "'></script>";

            var mvcHelpString = new TagBuilder("div")
            {
                Attributes =
                {
                    new KeyValuePair<string, string>("class", "g-recaptcha"),
                    new KeyValuePair<string, string>("data-sitekey", _googleSiteKey),
                }
            };
            var renderedCaptcha = mvcHelpString.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create($"{_googleCaptchaUri}{renderedCaptcha}");
        }
    }

    public static class InvalidGoogleCaptchaHelper
    {
        public static IHtmlString InvalidGoogleCaptchMessage(this HtmlHelper helper,
            string errorMessage)
        {
            var invalidCaptchaValidation = helper.ViewContext.Controller
                .TempData["InvalidCaptcha"];

            var invalidCaptcha = invalidCaptchaValidation?.ToString();
            if (string.IsNullOrWhiteSpace(invalidCaptcha))
                return MvcHtmlString.Create("");

            var buttonTag = new TagBuilder("span")
            {
                Attributes =
            {
                new KeyValuePair<string, string>("class", "text text-danger")
            },
                InnerHtml = errorMessage ?? invalidCaptcha
            };

            return MvcHtmlString.Create(buttonTag.ToString(TagRenderMode.Normal));
        }
    }

    public class ValidateGoogleCaptchaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var captchaResponse = filterContext.HttpContext.Request.Form["g-recaptcha-response"];

            if (string.IsNullOrWhiteSpace(captchaResponse))
                AddErrorAndRedirectToGetAction(filterContext);

            var validateResult = ValidateFromGoogle(SystemConstant.GoogleCaptchaValidationUri,
                SystemConstant.GoogleReCaptchaSecretKey, captchaResponse);
            if (!validateResult.Success) AddErrorAndRedirectToGetAction(filterContext);


            base.OnActionExecuting(filterContext);
        }

        private static void AddErrorAndRedirectToGetAction(ActionExecutingContext filterContext)
        {
            filterContext.Controller.TempData["InvalidCaptcha"] = "Invalid Captcha !";
            filterContext.Result = new RedirectToRouteResult(filterContext.RouteData.Values);
        }

        private static ReCaptchaResponse ValidateFromGoogle(string urlToPost,
            string secretKey, string captchaResponse)
        {
            var postData = "secret=" + secretKey + "&response=" + captchaResponse;

            var request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                streamWriter.Write(postData);

            string result;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                    result = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<ReCaptchaResponse>(result);
        }
    }

    internal class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public string ValidatedDateTime { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}