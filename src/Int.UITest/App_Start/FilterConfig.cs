using System.Web.Mvc;
using Int.UITest.Extensions;

namespace Int.UITest
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