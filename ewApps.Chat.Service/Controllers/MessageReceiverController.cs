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
    /// This API enables CRUD operation on chat message receiver.
    /// </summary>
    public class MessageReceiverController : ApiController
    {

        /// <summary>
        /// Gets the message receivers by thread identifier.
        /// </summary>
        /// <param name="threadId">The chat thread identifier</param>
        /// <returns>Returns chat receivers list.</returns>
        [HttpGet]
        [Route("Receiver/Thread/{threadId}")]
        public IEnumerable<ChatMessageReceiver> GetReceiverListByThreadId(string threadId)
        {
            return new List<ChatMessageReceiver>();
        }

        /// <summary>
        /// Gets the message receivers by message identifier.
        /// </summary>
        /// <param name="messageId">The chat message identifier</param>
        /// <returns>Returns chat receivers list.</returns>
        [HttpGet]
        [Route("Receiver/Message/{messageId}")]
        public IEnumerable<ChatMessageReceiver> GetReceiverListByMessageId(string messageId)
        {
            return new List<ChatMessageReceiver>();
        }


        /// <summary>
        /// Adds the message receiver.
        /// </summary>
        /// <param name="receiver">The receiver.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPost]
        [Route("Receiver")]
        public bool AddMessageReceiver([FromBody] ChatMessageReceiver receiver)
        {
            return true;
        }

        /// <summary>
        /// Deletes the receiver.
        /// </summary>
        /// <param name="receiverId">The receiver identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("Receiver/{receiverId}")]
        public bool DeleteReceiver([FromUri]string receiverId)
        {
            return true;
        }

        /// <summary>
        /// Deletes the receivers by message identifier.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>    
        [HttpDelete]
        [Route("Receiver/Message/{messageId}")]
        public bool DeleteReceiversByMessageId([FromUri]string messageId)
        {
            return true;
        }

        /// <summary>
        /// Deletes the receivers by thread identifier.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>  
        [HttpDelete]
        [Route("Receiver/Thread/{threadId}")]
        public bool DeleteReceiversByThreadId([FromUri] string threadId)
        {
            return true;
        }

        /// <summary>
        /// Updates the message receiver.
        /// </summary>
        /// <param name="chatThread">The message receiver.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPut]
        [Route("Receiver")]
        public bool UpdateMessageReceiver([FromBody] ChatMessageReceiver receiver) {
          return true;

        }

    }
}
