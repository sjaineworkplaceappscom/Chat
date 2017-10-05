using System;
using ewApps.Chat.EntityModel;

namespace ewApps.Chat.OfDataService {

  public interface IRoomMemberOfDataService {

    /// <summary>
    /// Adds the specified room member.
    /// </summary>
    /// <param name="roomMember">The room member to be add.</param>
    void Add(OfRoomMember roomMember);

    /// <summary>
    /// Deletes the specified room member.
    /// </summary>
    /// <param name="roomMember">The room member to be delete.</param>
    void Delete(OfRoomMember roomMember);
  }

}
