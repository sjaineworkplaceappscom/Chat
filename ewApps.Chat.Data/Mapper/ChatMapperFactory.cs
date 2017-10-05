using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ewApps.CommonRuntime.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ewApps.Chat.Common;
using ewApps.CommonRuntime.Data;

namespace ewApps.Chat.Data {

  public class ChatMapperFactory : BaseMapperFactory {

    /// <summary>
    /// This factory method returns row mapper class instance for entity.
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    /// <param name="entityType">Entity Type</param>
    /// <returns>Row Mapper object for input entity type</returns>
    public override IRowMapper<TEntity> GetEntityMapper<TEntity>(int entityType) {
      switch ((ChatEntityType)entityType) {


        case ChatEntityType.ChatRoom:
          return (IRowMapper<TEntity>)(new ChatRoomMapper());

        case ChatEntityType.ChatExternalUser:
          return (IRowMapper<TEntity>)(new ChatExternalUserMapper());

        case ChatEntityType.ChatMessageAttachment:
          return (IRowMapper<TEntity>)(new ChatMessageAttachmentMapper());
        case ChatEntityType.ChatMessage:
          return (IRowMapper<TEntity>)(new ChatMessageMapper());
        case ChatEntityType.ChatMessageReceiver:
          return (IRowMapper<TEntity>)(new ChatMessageReceiverMapper());
        case ChatEntityType.ChatMuteSetting:
          return (IRowMapper<TEntity>)(new ChatMuteSettingMapper());
        case ChatEntityType.ChatRoomMember:
          return (IRowMapper<TEntity>)(new ChatRoomMemberMapper());
        case ChatEntityType.ChatThread:
          return (IRowMapper<TEntity>)(new ChatThreadMapper());
        case ChatEntityType.ChatThreadMember:
          return (IRowMapper<TEntity>)(new ChatThreadMemberMapper());

        default:
          throw new Exception("Unknown Mapper Type");
      }
    }

    /// <summary>
    /// This factory method returns parameter mapper class for entity based on input type.
    /// </summary>
    /// <param name="entityType">Entity Type</param>
    /// <returns>Parameter object for input entity type</returns>
    public override IParameterMapper GetParamMapper(int entityType) {
      switch ((ChatEntityType)entityType) {
        case ChatEntityType.ChatExternalUser:
          return (IParameterMapper)(new ChatExternalUserMapper());
        case ChatEntityType.ChatRoom:
          return (IParameterMapper)(new ChatRoomMapper());
        case ChatEntityType.ChatMessageAttachment:
          return (IParameterMapper)(new ChatMessageAttachmentMapper());
        case ChatEntityType.ChatMessage:
          return (IParameterMapper)(new ChatMessageMapper());
        case ChatEntityType.ChatMessageReceiver:
          return (IParameterMapper)(new ChatMessageReceiverMapper());

        case ChatEntityType.ChatMuteSetting:
          return (IParameterMapper)(new ChatMuteSettingMapper());
        case ChatEntityType.ChatRoomMember:
          return (IParameterMapper)(new ChatRoomMemberMapper());
        case ChatEntityType.ChatThread:
          return (IParameterMapper)(new ChatThreadMapper());
        case ChatEntityType.ChatThreadMember:
          return (IParameterMapper)(new ChatThreadMemberMapper());

        default:
          throw new Exception("Unknown IParameterMapper Type");
      }
    }

  }
}
