using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.Chat.Common;
using ewApps.Chat.EntityModel;
using ewApps.CommonRuntime.Common;

namespace ewApps.Chat.OfDataService {

  public class RoomOfDataService : BaseOfDataService, IRoomOfDataService {


    public RoomOfDataService() {
    }

    #region IRoomOfDataService Members

    /// <inheritdoc/>
    public void Add(OfRoom room) {
      List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
      headers.Add(new KeyValuePair<string, string>(ewApps.Chat.Common.Constants.ChatAuthenticationTokenKey, ChatConfigHelper.GetChatServerAuthenticationToken()));

      HttpClientHelper.ExecutePOSTRequestAndReturnAsString(_baseUrl, "chatrooms", AcceptType.JSON, headers, null, null, room);
    }

    /// <inheritdoc/>
    public void Delete(string roomName) {
      List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
      headers.Add(new KeyValuePair<string, string>(ewApps.Chat.Common.Constants.ChatAuthenticationTokenKey, ChatConfigHelper.GetChatServerAuthenticationToken()));

      List<string> pathParam = new List<string>();
      pathParam.Add(roomName);

      //List<KeyValuePair<string, string>> uriParams = new List<KeyValuePair<string, string>>();
      //uriParams.Add(new KeyValuePair<string, string>("roomName", roomName));

      HttpClientHelper.ExecutePOSTRequestAndReturnAsString(_baseUrl, "chatrooms", AcceptType.JSON, headers, pathParam, null, null);

    }

    #endregion
  }
}
