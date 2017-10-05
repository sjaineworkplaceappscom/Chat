using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ewApps.Chat.EntityModel;

namespace ewApps.Chat.OfDataService {
  public interface IRoomOfDataService {

    /// <summary>
    /// Adds the specified room.
    /// </summary>
    /// <param name="room">The room.</param>
    void Add(OfRoom room);

    /// <summary>
    /// Deletes the specified room name.
    /// </summary>
    /// <param name="roomName">Name of the room.</param>
    void Delete(string roomName);
  }
}
