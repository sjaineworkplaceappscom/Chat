//===============================================================================
// Copyright © eWorkplace Apps.  All rights reserved.
// eWorkplace Apps Common Tools
// Main Author: Shashank Jain
// Original Date: June. 20, 2015
//===============================================================================

using ewApps.Chat.Common;
using ewApps.Chat.Entity;
using ewApps.Chat.DataService;
using ewApps.CommonRuntime.Entity;
using System;

namespace ewApps.Chat.DataService {

  /// <summary>
  /// A task management factory class, creating a data service handler objects for any type inherited from BaseEntity.
  /// </summary>
  public class ChatDataServiceFactory {

    /// <summary>
    /// Provides a data service handler to perform related operation for TEntity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    /// <param name="entityType">A EntityType enum value corresponding to given entity type.</param>
    /// <returns>
    /// Returns a data handler object for TEntity type.
    /// </returns>
    /// <remarks>
    /// If mapping for data handler is not found for TEntity, null reference is returned.
    /// </remarks>
    public static object GetDataService<TEntity>(ChatEntityType entityType) where TEntity : BaseEntity, new() {
      return GetDataService<TEntity>(entityType, false);
    }

    /// <summary>
    /// Provides a data service handler to perform related operation for TEntity type and ignore security(accroding to parameter value).
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    /// <param name="entityType">EntityType enum value corresponding to given entity type.</param>
    /// <param name="ignoreSecuriy">if set to <c>true</c> [ignore securiy].</param>
    /// <returns>
    /// Returns a data handler instance for TEntity type.
    /// </returns>
    /// <exception cref="System.Exception">Unknown EDEntity Type</exception>
    /// <remarks>
    /// If mapping for data handler is not found for TEntity, null reference is returned.
    /// </remarks>
    internal static object GetDataService<TEntity>(ChatEntityType entityType, bool ignoreSecuriy) where TEntity : BaseEntity, new() {
      object serviceObject = null;
      switch (entityType) {
        case ChatEntityType.ChatMessage:
          serviceObject = new ChatMessageDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatExternalUser:
          serviceObject = new ChatExternalUserDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatMessageAttachment:
          serviceObject = new ChatMessageAttachmentDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatMessageReceiver:
          serviceObject = new ChatMessageReceiverDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatMuteSetting:
          serviceObject = new ChatMuteSettingDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatRoom:
          serviceObject = new ChatRoomDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatRoomMember:
          serviceObject = new ChatRoomMemberDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatThread:
          serviceObject = new ChatThreadDataService(ignoreSecuriy);
          break;
        case ChatEntityType.ChatThreadMember:
          serviceObject = new ChatThreadMemberDataService(ignoreSecuriy);
          break;
       
       
       
        default:
          throw new Exception("Unknown EDEntity Type");
      }

      return serviceObject;
    }

    /// <summary>
    /// Provides a data service handler to perform related operation for TEntity type.
    /// </summary>
    /// <param name="entityType">A EntityType value.</param>
    /// <returns>
    /// Returns a data handler object for TEntity type.
    /// </returns>
    /// <exception cref="System.Exception">Unknown EDEntity Type</exception>
    /// <remarks>
    /// If mapping for data handler is not found for TEntity, null reference is returned.
    /// </remarks>
    //public static object GetDataService(string entityType) {
    //  object serviceObjct = null;
    //  switch (entityType) {
    //    case "ImportService":
    //      serviceObjct = new ImportEmployeeDataService();
    //      break;
    //    default:
    //      throw new Exception("Unknown EDEntity Type");
    //  }
    //  return serviceObjct;
    //}
  }
}
