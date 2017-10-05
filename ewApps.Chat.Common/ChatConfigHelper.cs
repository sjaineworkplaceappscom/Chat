using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Common;

namespace ewApps.Chat.Common {
  public class ChatConfigHelper {

    /// <summary>
    /// Gets the of chat API base URL from configuration file.
    /// </summary>
    /// <returns>Returns Web API base url of chat server.</returns>
    public static string GetOfChatAPIBaseUrl() {
      return ConfigurationManager.AppSettings["OfChatAPIBaseUrl"];
    }

    public static string GetChatServerAuthenticationToken() {
      return ConfigurationManager.AppSettings["ChatServerAuthenticationToken"];
    }

  }
}
