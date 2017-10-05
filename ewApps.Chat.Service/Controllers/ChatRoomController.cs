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
    /// This API enables CRUD operation on room.
    /// </summary>
    public class ChatRoomController : ApiController
    {

        /// <summary>
        /// Gets the chat room list.
        /// </summary>
        /// <returns>Returns ChatRoom list</returns>
        [HttpGet]
        [Route("ChatRoom/List")]
        public IEnumerable<ChatRoom> GetChatRoomList()
        {
            return new List<ChatRoom>();
        }

        /// <summary>
        /// Gets the chat room by room identifier.
        /// </summary>
        /// <param name="chatRoomId">The chat room identifier.</param>
        /// <returns>Returns matched chat room entity.</returns>
        [HttpGet]
        [Route("ChatRoom/{chatRoomId}")]
        public ChatRoom GetChatRoomById(string chatRoomId)
        {
            return new ChatRoom();
        }

        /// <summary>
        /// Adds the chat room.
        /// </summary>
        /// <param name="chartRoom">The chart room.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPost]
        [Route("ChatRoom")]
        public Guid AddChatRoom([FromBody]ChatRoom chartRoom)
        {
            return Guid.Empty;
        }

        /// <summary>
        /// Updates the chat room.
        /// </summary>
        /// <param name="chatRoomId">The chat room identifier.</param>
        /// <param name="chatRoom">The chat room.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPut]
        [Route("ChatRoom/{chatRoomId}")]
        public bool UpdateChatRoom([FromUri] string chatRoomId, [FromBody]ChatRoom chatRoom)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat room.
        /// </summary>
        /// <param name="chatRoomId">The chat room identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatRoom/{chatRoomId}")]
        public bool DeleteChatRoom(string chatRoomId)
        {
            return true;
        }
    }
}
