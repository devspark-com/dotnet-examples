namespace TechTalkExample.RandomNameApi
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        #region Methods

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        #endregion Methods
    }
}