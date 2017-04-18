using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Whiteduck.Swagger.AADExtension
{
    public static class SwaggerGenOptionsAADExtension
    {
        /// <summary>
        /// Sets specific SwaggerGenOptions for authenticating against Azure Active Directory.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="apiClientId">The client id of your API</param>
        /// <param name="tenantId">The tenant id (e. g. wdswagger.onmicrosoft.com).</param>
        /// <param name="activeDirectoryAuthority">Active Directory Authority (e.g. login.microsoftonline.com).</param>
        public static void ConfigureAAD(this SwaggerGenOptions option, string apiClientId, string tenantId, string activeDirectoryAuthority)
        {
            var resourceDictionary = new Dictionary<string, string>
            {
                { "resource", apiClientId }
            };

            option.AddSecurityDefinition("oauth2", new OAuth2Scheme
            {
                Type = "oauth2",
                Flow = "implicit",
                AuthorizationUrl = string.Format("https://{0}/{1}/oauth2/authorize", activeDirectoryAuthority, tenantId),
                Scopes = resourceDictionary
            });

            option.OperationFilter<SecurityRequirementsOperationFilter>();
        }

        /// <summary>
        /// Sets specific SwaggerGenOptions for authenticating against Azure Active Directory.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="apiClientId">The client id of your API.</param>
        /// <param name="tenantId">The tenant id (e. g. wdswagger.onmicrosoft.com),</param>
        public static void ConfigureAAD(this SwaggerGenOptions option, string apiClientId, string tenantId)
        {
           option.ConfigureAAD(apiClientId, tenantId, "login.microsoftonline.com");
        }
    }
}
