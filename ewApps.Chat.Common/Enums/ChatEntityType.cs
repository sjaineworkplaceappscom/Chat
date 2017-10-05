using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ewApps.Chat.Common {

  /// <summary>
  /// Programming
  /// Defines constants for entity type.
  /// Range from 1100 -1199
  /// </summary>
  public enum ChatEntityType {

    /// <summary>
    /// Undefinde entity type.
    /// </summary>
    None = 0,

    /// <summary>
    /// All entity.
    /// </summary>
    All = 1100,

    /// <summary>
    /// The chat message
    /// </summary>
    ChatMessage = 1101,

    /// <summary>
    /// The chat message attachment
    /// </summary>
    ChatMessageAttachment = 1002,

    /// <summary>
    /// The chat message receiver
    /// </summary>
    ChatMessageReceiver = 1003,

    /// <summary>
    /// The chat room
    /// </summary>
    ChatRoom = 1004,

    /// <summary>
    /// The chat room member
    /// </summary>
    ChatRoomMember = 1005,

    /// <summary>
    /// The chat team member
    /// </summary>
    ChatThreadMember = 1006,

    /// <summary>
    /// The chat thread
    /// </summary>
    ChatThread = 1007,

    /// <summary>
    /// The chat user
    /// </summary>
    ChatExternalUser = 1008,

    /// <summary>
    /// The chat mute setting
    /// </summary>
    ChatMuteSetting=1009

  }
}
