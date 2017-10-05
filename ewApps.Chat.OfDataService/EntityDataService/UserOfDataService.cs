using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.Chat.Common;
using ewApps.Chat.EntityModel;
using ewApps.CommonRuntime.Common;

namespace ewApps.Chat.OfDataService {

  public class UserOfDataService : BaseOfDataService, IUserOfDataService {

    public UserOfDataService() {
    }


    #region IUserOfDataService Members

    /// <inheritdoc/>
    public string Add(OfUser user) {
      try {
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>(ewApps.Chat.Common.Constants.ChatAuthenticationTokenKey, ChatConfigHelper.GetChatServerAuthenticationToken()));
        return HttpClientHelper.ExecutePOSTRequestAndReturnAsString(_baseUrl, "users", AcceptType.JSON, headers, null, null, user);
      }
      catch (Exception) {
        throw;
      }
    }

    /// <inheritdoc/>
    public void Delete(string userName) {
      try {
        List<string> pathParam = new List<string>();
        pathParam.Add(userName);

        //List<KeyValuePair<string, string>> uriParam = new List<KeyValuePair<string, string>>();
        //uriParam.Add(new KeyValuePair<string, string>("username", userName));

        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>(ewApps.Chat.Common.Constants.ChatAuthenticationTokenKey, ChatConfigHelper.GetChatServerAuthenticationToken()));

        HttpClientHelper.ExecuteDELETERequest(_baseUrl, "users", AcceptType.JSON, headers, pathParam, null, null);
      }
      catch (Exception) {
        throw;
      }
    }

    #endregion
  }
}
