using System.Reflection;
using System.Web.Mvc;

namespace Community.Foundation.Mvc.Extension
{        
        /// <summary>
        /// Mechanism to handle multiple sitecore form renderings on a page
        /// When one is posted, all receive the post verb
        /// Mark all with this attribute and it will revert to the Get method when its form is not the real one being called.
        /// Example:
        /// 
        /// [HttpGet]
        /// Action1() {}
        /// [HttpPost]
        /// [MultiformPostProtection]
        /// Action1(model) {}
        /// 
        /// [HttpGet]
        /// Action2() {}
        /// [HttpPost]
        /// [MultiformPostProtection]
        /// Action2(model) {}
        /// 
        /// When the form from action 1 is submitted the Action2(mode) action will invoke the Action2() method in its place because of the MultiformPostProtection attribute.
        /// Note: This requires that the form rendered in Action1() calls the helper method: @Html.MultiformPostProtection() inside the form
        /// </summary>
        public class MultiformPostProtectionAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Only continue if we are a post
                if (filterContext.HttpContext.Request.HttpMethod != System.Net.WebRequestMethods.Http.Post)
                    return;

                // Verify form token for this action
                var formToken = filterContext.HttpContext?.Request?.Params[HtmlHelperExtension.FormTokenField] ?? string.Empty;
                var actionName = (string)filterContext.RouteData.Values["action"];

                if (formToken.Equals(MakeToken(actionName)))
                    return; // All good you are in the right place

                // When they don't match, invoke the same action name with no parameters (the HttpGet method)
                var controllerType = filterContext.Controller.GetType();
                filterContext.Result = (ActionResult)controllerType.InvokeMember(actionName, BindingFlags.InvokeMethod, null, (dynamic)filterContext.Controller, null);
            }

            // Obfuscate value... just because
            public static string MakeToken(string input)
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                return System.Convert.ToBase64String(bytes);
            }

        }

        public static class HtmlHelperExtension
        {
            public const string FormTokenField = "__FormKey";

            public static MvcHtmlString MultiformPostProtection(this HtmlHelper helper)
            {
                var key = MultiformPostProtectionAttribute.MakeToken((string)helper.ViewContext.RouteData.Values["action"]);
                return MvcHtmlString.Create($"<input type=\"hidden\" name=\"{FormTokenField}\" value=\"{key}\" />");
            }
        }
    }