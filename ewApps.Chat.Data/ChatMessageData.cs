//===============================================================================
// © 2015 eWorkplace Apps.  All rights reserved.
// Original Author: Shashank Jain 
// Original Date: 19 June 15
//===============================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using ewApps.Chat.Entity;
using ewApps.CommonRuntime.Data;
using ewApps.CommonRuntime.Common;
using ewApps.CommonRuntime.Entity;
using ewApps.Chat.Data;
using ewApps.Chat.Common;

namespace ewApps.Chat.Data {

  /// <summary>
  /// Provides methods for add, update, delete and search operations on ChatMessage entity. 
  /// </summary>
  public class ChatMessageData : BaseData, IChatMessageData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatMessageData()
      : base(ChatMessage.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get chatmessage entity detail information.
    private string GetSQL() {
      string sql = " SELECT [ChatMessageId],[ChatThreadId],[MessageType],[Message],[TenantId], " +
                   " [CreatedBy],[CreatedDate],[ModifiedDate],[Version] " +
                   " FROM [ChatMessage] ";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<Employee,Guid> Members

    /// <inheritdoc/>
    public ChatMessage GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatMessage>() + " WHERE ChatMessageId=@ChatMessageId";
      object[] sqlParam = new object[] { "ChatMessageId;" + id.ToString() };
      return ExecuteSql<ChatMessage>(sql, (int)ChatEntityType.ChatMessage, sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatMessageId=@ChatMessageId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatMessageId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the ChatMessage records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatMessage> GetList() {
      // This method is not supported because it will return all the ChatMessage records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatMessage entity) {
      // Generate new id for ChatMessageId.
      entity.ChatMessageId = Guid.NewGuid();
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Tenant and CreatedBy      
      if (session != null) {
        entity.CreatedByName = session.UserId.ToString();
        entity.TenantId = session.TenantId;
      }

      // Update created and modified datetime with current date and time.
      entity.CreatedDate = DateTime.Now.ToUniversalTime();      
      entity.ModifiedDate = entity.CreatedDate;

      DbCommand command = BuildInsertStatement<ChatMessage>(entity);
      ExecuteNonQuery(command, entity, entity.ChatMessageId);
      return entity.ChatMessageId;
    }

    /// <inheritdoc/>
    public void Update(ChatMessage entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      //// Set Modifed by with login user id.
      //if (session != null) {
      //  entity.ModifiedBy = session.UserId;
      //}

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatMessage>(entity);
      command.CommandText += " WHERE ChatMessageId=@ChatMessageId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatMessageId", entity.ChatMessageId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatMessageId);
    }

    /// <inheritdoc/>
    public void Delete(ChatMessage entity) {
      DbCommand command = BuildDeleteStatement<ChatMessage>();
      command.CommandText += " WHERE ChatMessageId =@ChatMessageId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatMessageId", entity.ChatMessageId);
      ExecuteNonQuery(command, entity, entity.ChatMessageId);
    }

    /// <inheritdoc/>
    public ChatMessage GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatMessage>() + " WHERE ChatMessageId=@ChatMessageId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatMessageId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatMessage>(sql, (int)ChatEntityType.ChatMessage, sqlParams, id).FirstOrDefault();
    }

    #endregion


  }
}
