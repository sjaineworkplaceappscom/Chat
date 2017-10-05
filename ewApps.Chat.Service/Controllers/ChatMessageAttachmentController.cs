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
    /// This API enables CRUD operation on chat message attachment.
    /// </summary>

    public class ChatMessageAttachmentController : ApiController
    {

        /// <summary>
        /// Gets the chat message attachment list by thread identifier.
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns>Returns matched chat message attachment list.</returns>
        [HttpGet]
        [Route("ChatMessageAttachment/Thread/{threadId}")]
        public IEnumerable<ChatMessageAttachment> GetAttachmentListByThreadId(string threadId)
        {
            return new List<ChatMessageAttachment>();
        }

        /// <summary>
        /// Gets the chat message attachment by attchment identifier.
        /// </summary>
        /// <param name="chatMessageAttachmentId">The chat message attachment identifier.</param>
        /// <returns>Returns matched ChatMessageAttachment entity.</returns>
        [HttpGet]
        [Route("ChatMessageAttachment/{chatMessageAttachmentId}")]
        public ChatMessageAttachment GetChatMessageAttachmentById([FromUri] string chatMessageAttachmentId)
        {
            return new ChatMessageAttachment();
        }

        /// <summary>
        /// Adds the chat message attachment.
        /// </summary>
        /// <param name="chatMessageAttachment">The chat message attachment.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPost]
        [Route("ChatMessageAttachment/{chatMessageAttachmentId}")]
        public bool AddChatMessageAttachment([FromBody]ChatMessageAttachment chatMessageAttachment)
        {
            return true;
        }

        /// <summary>
        /// Updates the chat message attachment.
        /// </summary>
        /// <param name="chatMessageAttachmentId">The chat message attachment identifier.</param>
        /// <param name="chatMessageAttachment">The chat message attachment.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPut]
        [Route("ChatMessageAttachment/{chatMessageAttachmentId}")]
        public bool UpdateChatMessageAttachment([FromUri]string chatMessageAttachmentId, [FromBody]ChatMessageAttachment chatMessageAttachment)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat message attachment.
        /// </summary>
        /// <param name="chatMessageAttachmentId">The chat message attachment identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatMessageAttachment/{chatMessageAttachmentId}")]
        public bool DeleteChatMessageAttachment(string chatMessageAttachmentId)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat message attachment by message identifier.
        /// </summary>
        /// <param name="chatMessageId">The chat message identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatMessageAttachment/ChatMessage/{chatMessageId}")]
        public bool DeleteChatMessageAttachmentByMessageId(string chatMessageId)
        {
            return true;
        }

    }
}
