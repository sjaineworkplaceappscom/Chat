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
    /// This API enables CRUD operation on team member.
    /// </summary>
    public class ChatTeamMemberController : ApiController
    {
        /// <summary>
        /// Gets the chat team members by team identifier.
        /// </summary>
        /// <param name="chatTeamId">The chat team identifier.</param>
        /// <returns>Returns matched chat team member list.</returns>
        [HttpGet]
        [Route("ChatTeamMember/ChatTeam/{chatTeamId}")]
        public IEnumerable<ChatThreadMember> GetChatTeamMembersByTeamId(string chatTeamId)
        {
            return new List<ChatThreadMember>();
        }


        /// <summary>
        /// Gets the chat team member by team member identifier.
        /// </summary>
        /// <param name="chatTeamMemberId">The chat team member identifier.</param>
        /// <returns>Returns matched chat team member entity.</returns>
        [HttpGet]
        [Route("ChatTeamMember/{chatTeamMemberId}")]
        public ChatThreadMember GetChatTeamMemberById(string chatTeamMemberId)
        {
            return new ChatThreadMember();
        }

        /// <summary>
        /// Adds the chat team member.
        /// </summary>
        /// <param name="chatTeamMember">The chat team member.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPost]
        [Route("ChatTeamMember")]
        public bool AddChatTeamMember([FromBody]ChatThreadMember chatTeamMember)
        {
            return true;
        }

        /// <summary>
        /// Updates the chat team member.
        /// </summary>
        /// <param name="chatTeamMember">The chat member.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpPut]
        [Route("ChatTeamMember")]
        public bool UpdateChatTeamMember( [FromBody]ChatThreadMember chatTeamMember)
        {
            return true;
        }

        /// <summary>
        /// Deletes the chat team member by team member identifier.
        /// </summary>
        /// <param name="chatTeamMemberId">The Chat team member identifier.</param>
        /// <returns>Returns true if operation is successful otherwise return false.</returns>
        [HttpDelete]
        [Route("ChatTeamMember/{chatTeamMemberId}")]
        public bool DeleteChatTeamMember([FromUri]string chatTeamMemberId)
        {
            return true;
        }
    }
}
