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
    public class ThreadController : ApiController
    {
        /// <summary>
        /// Get chat threads for chat centerfor given user identifier.
        /// </summary>
        /// <param name="userId">The user identifier</param>
        /// <returns>Returns thread list</returns>
        [HttpGet]        
        public IEnumerable<ChatThread> GetChtaThreads(string userId)
        {
            return null;
        }

        /// <summary>
        /// Finds the threads for given search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>Returns thread list</returns>
        [HttpGet]
        public IEnumerable<ChatThread> FindChatThreads(string searchString)
        {
            return null;
        }

        /// <summary>
        /// Adds the chat thread.
        /// </summary>
        /// <param name="receiver">The thread.</param>
        /// <returns>Returns true if operation is sucessful otherwise return false.</returns>
        [HttpPost]
        public bool PostChatThread(ChatThread chatThread)
        {
            return true;
        }


        [HttpPut]
        public bool PutChatThread(ChatThread chatThread)
        {
            return true;

        }

        /// <summary>
        /// Deletes the chat thread.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Returns true if operation is sucessful otherwise return false.</returns>
        [HttpDelete]
        public bool DeleteChatThread(string threadId)
        {
            return true;

        }


        //// GET: api/Thread
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Thread/5
        //[HttpGet]
        //[Route("/Thread/{UserId}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Thread
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Thread/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Thread/5
        //public void Delete(int id)
        //{
        //}
    }
}
