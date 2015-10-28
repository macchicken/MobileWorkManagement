using Int.MobileUI.Extensions;
using System.Web;
using System.Web.Mvc;

namespace Int.MobileUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleExceptionAttribute());
            filters.Add(new ValidateModelStateAttribute());
            filters.Add(new JsonHandlerAttribute());
        }
    }
}
