using ewApps.Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ewApps.Chat.Service.Controllers
{
    /// <summary>
    /// This API enables CRUD operation on chat thread.
    /// </summary>
    public class ChatThreadController : ApiController
    {
        /// <summary>
        /// Gets the chat threads by user identifier for chat center.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns matched chat thread list.</returns>
        [HttpGet]
        [Route("ChatThread/User/{userId}")]
        public IEnumerable<ChatThread> GetChatThreadsByUserId([FromUri]string userId)
        {
            return new List<ChatThread>();
        }

        /// <summary>
        /// Finds the chat threads for given searach string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>Returns matched chat thread list.</returns>
        [HttpGet]
        [Route("ChatThread/Search/{searchString}")]
        public IEnumerable<ChatThread> FindChatThreads([FromUri]string searchString)
        {
            return new List<ChatThread>();
        }


        /// <summary>
        /// Gets the chat thread by thread name.
        /// </summary>
        /// <param name="threadName">The thread name.</param>
        /// <returns>Returns matched thread.</returns>
        [HttpGet]
        [Route("ChatThread/{threadName}")]
        public ChatThread GetChatThreadsByName([FromUri]string threadName) {
          return new ChatThread();
        }


        /// <summary>
        /// Adds the chat thred.
        /// </summary>
        /// <param name="chatThread">The chat thread.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPost]
        [Route("ChatThread")]
        public bool AddChatThred(ChatThread chatThread)
        {
            return true;
        }

        /// <summary>
        /// Updates the chat thread.
        /// </summary>
        /// <param name="chatThread">The chat thread.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPut]
        [Route("ChatThread")]
        public bool UpdateChatThread(ChatThread chatThread)
        {
            return true;

        }

        /// <summary>
        /// Deletes the chat thread by thread identifier.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatThread/{threadId}")]
        public bool DeleteChatThreadByThreadId(string threadId)
        {
            return true;

        }
    }
}
