using System.Web.Mvc;

namespace SearchClientWebApp.Areas.SME
{
    public class SMEAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SME";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SME_default",
                "SME/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}