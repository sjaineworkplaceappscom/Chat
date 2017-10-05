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
    /// This API enables CRUD operation on meesages.
    /// </summary>
    public class MessageController : ApiController
    {
        /// <summary>
        /// Gets the messages by thread identifier.
        /// </summary>
        /// <param name="chatThreadId">The chat thread identifier.</param>
        /// <returns>Returns chat message list.</returns>
        [HttpGet]
        [Route("ChatMessage/Thread/{chatThreadId}")]
        public IEnumerable<ChatMessage> GetMessagesbyThread([FromUri] string chatThreadId)
        {
            return new List<ChatMessage>();
        }

        /// <summary>
        /// Finds the message for given search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Returns matched chat message entity.</returns>
        [HttpGet]
        [Route("ChatMessage/Search/{searchString}/{threadId}")]
        public IEnumerable<ChatMessage> FindMessages([FromUri]string searchString, [FromUri] string threadId)
        {
            return new List<ChatMessage>();
        }

        /// <summary>
        /// Gets the unread message count for given userId
        /// </summary>
        /// <param name="userId">The user Id.</param>        
        /// <returns>Returns unread message count.</returns>
        [HttpGet]
        [Route("ChatMessage/Unread/User/{userId}")]
        public int GetUnreadMessageCount([FromUri]string userId) {
          return 0;
        }

        /// <summary>
        /// Adds the chat message.
        /// </summary>
        /// <param name="chatMessage">The chat message.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPost]
        [Route("ChatMessage")]
        public bool AddChatMessage([FromBody] ChatMessage chatMessage)
        {
            return true;
        }

        /// <summary>
        /// Updates the chat message.
        /// </summary>
        /// <param name="chatMessage">The chat message.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPut]
        [Route("ChatMessage")]
        public bool UpdateChatMessage([FromBody]ChatMessage chatMessage)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat message.
        /// </summary>
        /// <param name="chatMessageId">The chat message identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatMessage/{chatMessageId}")]
        public bool DeleteChatMessage([FromUri] string chatMessageId)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat messages by thread identifier.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatMessage/Thread/{threadId}")]
        public bool DeleteChatMessagesByThreadId([FromUri] string threadId)
        {
            return true;
        }

    }
}
