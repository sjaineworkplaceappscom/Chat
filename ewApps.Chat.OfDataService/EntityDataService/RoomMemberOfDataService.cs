using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.Chat.Common;
using ewApps.Chat.EntityModel;
using ewApps.CommonRuntime.Common;

namespace ewApps.Chat.OfDataService {

  public class RoomMemberOfDataService : BaseOfDataService, IRoomMemberOfDataService {

    /// <inheritdoc/>
    public void Add(OfRoomMember roomMember) {
      try {
        List<string> pathParam = new List<string>();
        pathParam.Add(roomMember.RoomName);
        pathParam.Add("members");
        pathParam.Add(roomMember.MemberName);
        //List<KeyValuePair<string, string>> uriParam = new List<KeyValuePair<string, string>>();
        //uriParam.Add(new KeyValuePair<string, string>("roomName", roomMember.RoomName));
        //uriParam.Add(new KeyValuePair<string, string>("roles", "        pathParam.Add(userName);"));
        //uriParam.Add(new KeyValuePair<string, string>("name", roomMember.MemberName));

        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>(ewApps.Chat.Common.Constants.ChatAuthenticationTokenKey, ChatConfigHelper.GetChatServerAuthenticationToken()));

        HttpClientHelper.ExecutePOSTRequest(_baseUrl, "chatrooms", AcceptType.JSON, headers, pathParam, null, null);
      }
      catch (Exception) {
        throw;
      }
    }

    /// <inheritdoc/>
    public void Delete(OfRoomMember roomMember) {
      try {
        List<string> pathParam = new List<string>();
        pathParam.Add(roomMember.RoomName);
        pathParam.Add("members");
        pathParam.Add(roomMember.MemberName);
        //List<KeyValuePair<string, string>> uriParam = new List<KeyValuePair<string, string>>();
        //uriParam.Add(new KeyValuePair<string, string>("roomName", roomMember.RoomName));
        //uriParam.Add(new KeyValuePair<string, string>("roles", "members"));
        //uriParam.Add(new KeyValuePair<string, string>("name", roomMember.MemberName));

        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>(ewApps.Chat.Common.Constants.ChatAuthenticationTokenKey, ChatConfigHelper.GetChatServerAuthenticationToken()));

        HttpClientHelper.ExecuteDELETERequest(_baseUrl, "chatrooms", AcceptType.JSON, headers, pathParam, null, null);
      }
      catch (Exception) {
        throw;
      }
    }

  }
}
