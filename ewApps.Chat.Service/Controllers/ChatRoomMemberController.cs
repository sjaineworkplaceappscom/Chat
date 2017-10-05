using ewApps.Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ewApps.Chat.Service.Controllers
{
    /// <summary>
    /// This API enables CRUD operation on room members.
    /// </summary>
    public class ChatRoomMemberController : ApiController
    {

        /// <summary>
        /// Gets the chat room members by room identifier.
        /// </summary>
        /// <param name="chatRoomId">The chat room identifier.</param>
        /// <returns>Returns matched ChatRoomMember list.</returns>
        [HttpGet]
        [Route("ChatRoomMember/ChatRoom/{chatRoomId}")]
        public IEnumerable<ChatRoomMember> GetChatRoomMembersByRoomId([FromUri] string chatRoomId)
        {
            return new List<ChatRoomMember>();
        }

        /// <summary>
        /// Gets the chat room member by room member identifier.
        /// </summary>
        /// <param name="chatRoomMemberId">The chat room member identifier.</param>
        /// <returns>Returns matched ChatRoomMember entity.</returns>
        [HttpGet]
        [Route("ChatRoomMember/{chatRoomMemberId}")]
        public ChatRoomMember GetChatRoomMemberById(string chatRoomMemberId)
        {
            return new ChatRoomMember();
        }

        /// <summary>
        /// Adds the chat room member.
        /// </summary>
        /// <param name="chatRoomMember">The chat room member.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPost]
        [Route("ChatRoomMember")]
        public Guid AddChatRoomMember([FromBody]ChatRoomMember chatRoomMember)
        {
            return Guid.Empty;
        }

        /// <summary>
        /// Updates the chat room member.
        /// </summary>
        /// <param name="chatRoomMemberId">The chat room member identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPut]
        [Route("ChatRoomMember/{chatRoomMemberId}")]
        public bool UpdateChatRoomMember([FromUri]string chatRoomMemberId, [FromBody]string value)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat room member by identifier.
        /// </summary>
        /// <param name="chatRoomMemberId">The chat room member identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatRoomMember/{chatRoomMemberId}")]
        public bool DeleteChatRoomMemberById([FromUri]string chatRoomMemberId)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat room member by room identifier.
        /// </summary>
        /// <param name="chatRoomId">The chat room identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatRoomMember/Room/{chatRoomId}")]
        public bool DeleteChatRoomMemberByRoomId([FromUri]string chatRoomId)
        {
            return true;
        }
    }
}
