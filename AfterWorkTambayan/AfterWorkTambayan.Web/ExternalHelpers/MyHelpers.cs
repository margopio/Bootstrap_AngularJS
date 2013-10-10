using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AfterWorkTambayan.Web.ExternalHelpers
{
    public static class MyHelpers
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            var builder = new TagBuilder("li");

            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (controllerName == currentController && actionName == currentAction)
            {
                builder.AddCssClass("active");
            }

            builder.InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString();

            return new MvcHtmlString(builder.ToString());
        }
    }
}