using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;

namespace Whiteduck.Swagger.AADExtension
{
    public static class SwaggerUIOptionsAADExtension
    {
        /// <summary>
        /// Sets specific SwaggerUIOptions for authenticating against Azure Active Directory.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="swaggerClientId">The client id of your swagger client.</param>
        /// <param name="apiClientId">The client id of your API.</param>
        public static void ConfigureAAD(this SwaggerUIOptions option, string swaggerClientId, string apiClientId)
        {
            var resourceDictionary = new Dictionary<string, string>
            {
                { "resource", apiClientId }
            };

            option.ConfigureOAuth2(swaggerClientId, null, null, swaggerClientId, string.Empty, resourceDictionary);
        }
        
    }
}
