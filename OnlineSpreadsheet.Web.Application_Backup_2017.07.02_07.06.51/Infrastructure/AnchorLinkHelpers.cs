namespace OnlineSpreadsheet.Web.Application.Infrastructure
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Routing;

    public static class AnchorLinkHelpers
    {
        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }

        public static MvcHtmlString RawActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var anchor = new TagBuilder("a");
            anchor.InnerHtml = linkText;
            anchor.Attributes["href"] = urlHelper.Action(actionName, controllerName, routeValues);
            anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(anchor.ToString());
        }

        public static IHtmlString Button(this HtmlHelper helper, string icon, string text, string controllerName, string actionName)
        {
            string link = string.Format(
                "<a class='btn btn-blue' title='{1}' href='/{2}/{3}'><i class='fa {0}'></i>  {1}</a>",
                icon, 
                text, 
                controllerName, 
                actionName);
            return new MvcHtmlString(link);
        }

        public static IHtmlString FaActionLink(this AjaxHelper helper, string fontAwesomeClass, string text, string altText, string actionName, string controller, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes = null)
        {
            var builder = new TagBuilder("span");
            builder.AddCssClass(fontAwesomeClass);
            builder.AddCssClass("fa");
            builder.MergeAttribute("data-modal", string.Empty);
            builder.MergeAttribute("alt", altText);
            builder.InnerHtml = "<strong> " + text + "</strong>";

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            var link = helper.ActionLink("[replaceme]", actionName, controller, routeValues, ajaxOptions).ToHtmlString();
            return MvcHtmlString.Create(link.Replace("[replaceme]", builder.ToString(TagRenderMode.Normal)));
        }
    }
}