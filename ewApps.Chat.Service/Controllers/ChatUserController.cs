using ewApps.Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ewApps.Chat.OfDataService;
using ewApps.Chat.EntityModel;

namespace ewApps.Chat.Service.Controllers {
  /// <summary>
  /// This API enables CRUD operation on user.
  /// </summary>
  [RoutePrefix("ChatUser")]
  public class ChatUserController : ApiController {

    ///// <summary>
    ///// Gets the chat user list.
    ///// </summary>
    ///// <returns>Returns matched ChatTeamMember list.</returns>
    //[HttpGet]
    //[Route("ChatUser/List")]
    //public IEnumerable<ChatExternalUser> GetChatUserList()
    //{
    //    return new List<ChatExternalUser>();
    //}

    ///// <summary>
    ///// Gets the chat user by user identifier.
    ///// </summary>
    ///// <param name="chatUserId">The chat user identifier.</param>
    ///// <returns>Returns matched chat user entity.</returns>
    //[HttpGet]
    //[Route("ChatUser/{chatUserId}")]
    //public ChatExternalUser GetChatUserById(string chatUserId)
    //{
    //    return new ChatExternalUser();
    //}

    /// <summary>
    /// Adds the chat user.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="email">The email.</param>
    /// <returns>Return user JID</returns>
    [HttpPost]
    [Route("AddChatUser")]
    public string Add([FromUri] string userId, [FromUri] string email) {
      UserOfDataService ofUserDS = new UserOfDataService();
      OfUser ofUser = new OfUser();
      ofUser.name = userId;
      ofUser.email = email;
      ofUser.password = userId;
      ofUser.username = userId;
      return ofUserDS.Add(ofUser);
    }

    ///// <summary>
    ///// Updates the chat user.
    ///// </summary>
    ///// <param name="chatUser">The chat user.</param>
    ///// <returns>Returns true if operation is successful otherwise return false.</returns>
    //[HttpPut]
    //[Route("ChatUser")]
    //public bool UpdateChatUser( [FromBody]ChatExternalUser chatUser)
    //{
    //    return true;
    //}


    /// <summary>
    /// Deletes the chat user by user identifier.
    /// </summary>
    /// <param name="threadId">The chat user identifier.</param>
    /// <returns>Returns true if operation is successful otherwise return false.</returns>
    [HttpDelete]
    [Route("{chatUserId}")]
    public bool Delete(string chatUserId) {
      return true;
    }
  }
}
