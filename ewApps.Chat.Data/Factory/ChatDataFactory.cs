
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ewApps.Chat.Common;
using ewApps.Chat.Data;
using ewApps.CommonRuntime.Data;
using ewApps.CommonRuntime.Entity;

namespace ewApps.Chat.Data {

  /// <summary>
  /// A factory class, creating a data handler objects for any type inherited from BaseEntity.
  /// </summary>
  public class ChatDataFactory {

    /// <summary>
    /// Gets the data object.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entityType">Type of the entity.</param>
    /// <returns></returns>
    public static BaseData GetDataObject<TEntity>(ChatEntityType entityType) where TEntity : BaseEntity, new() {
      switch (entityType) {
        case ChatEntityType.ChatMessage:
          return new ChatMessageData();
        case ChatEntityType.ChatMessageReceiver:
          return new ChatMessageReceiverData();
        case ChatEntityType.ChatExternalUser:
          return new ChatExternalUserData();
        case ChatEntityType.ChatMessageAttachment:
          return new ChatMessageAttachmentData();
        case ChatEntityType.ChatMuteSetting:
          return new ChatMuteSettingData();
        case ChatEntityType.ChatRoom:
          return new ChatRoomData();
        case ChatEntityType.ChatRoomMember:
          return new ChatRoomMemberData();
        case ChatEntityType.ChatThread:
          return new ChatThreadData();
        case ChatEntityType.ChatThreadMember:
          return new ChatThreadMemberData();
        default:
          //return DataFactory.GetDataObject<TEntity>(entityType);
          // TODO: Sanjeev
          // Throw exception   
          return null;
      }
    }

  }
}
