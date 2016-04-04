namespace TechTalkExample.RandomNameApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    public static class WebApiConfig
    {
        #region Methods

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }

        #endregion Methods
    }
}