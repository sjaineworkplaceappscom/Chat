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
  /// Provides methods for add, update, delete and search operations on ChatMessageReceiver entity.
  /// </summary>
  public class ChatMessageReceiverData : BaseData, IChatMessageReceiverData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatMessageReceiverData()
      : base(ChatMessageReceiver.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get chatmessagereceiver entity detail information.
    private string GetSQL() {
      string sql = " SELECT [ChatMessageReceiverId],[ChatMessageId],[ChatThreadId],[SenderInternal], " +
                   " [SenderExternal],[ReceiverInternal],[ReceiverExternal],[ReadDate],[LikeDate], " +
                   " [DeliveryDate],[TenantId],[CreatedBy],[CreatedDate],[ModifiedDate],[Version] " +
                   " From [ChatMessageReceiver] ";

      return sql;
    }

    #endregion Private Methods

    #region IBaseData<ChatMessageReceiver,Guid> Members

    /// <inheritdoc/>
    public ChatMessageReceiver GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatMessageReceiver>() + " WHERE ChatMessageReceiverId=@ChatMessageReceiverId";
      object[] sqlParam = new object[] { "ChatMessageReceiverId;" + id.ToString() };
      return ExecuteSql<ChatMessageReceiver>(sql, (int)ChatEntityType.ChatMessageReceiver, sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatMessageReceiverId=@ChatMessageReceiverId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatMessageReceiverId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the ChatMessageReceiver records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatMessageReceiver> GetList() {
      // This method is not supported because it will return all the ChatMessageReceiver records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatMessageReceiver entity) {
      // Generate new id for chat messagereceiver.
      entity.ChatMessageReceiverId = Guid.NewGuid();
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Tenant and CreatedBy

      if (session != null) {
        entity.CreatedBy = session.UserId;
        entity.TenantId = session.TenantId;
      }

      // Update created and modified datetime with current date and time.
      entity.CreatedDate = DateTime.Now.ToUniversalTime();
      entity.ModifiedBy = entity.CreatedBy;
      entity.ModifiedDate = entity.CreatedDate;

      DbCommand command = BuildInsertStatement<ChatMessageReceiver>(entity);
      ExecuteNonQuery(command, entity, entity.ChatMessageReceiverId);
      return entity.ChatMessageReceiverId;
    }

    /// <inheritdoc/>
    public void Update(ChatMessageReceiver entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Modifed by with login user id.
      if (session != null) {
        entity.ModifiedBy = session.UserId;
      }

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatMessageReceiver>(entity);
      command.CommandText += " WHERE ChatMessageReceiverId=@ChatMessageReceiverId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatMessageReceiverId", entity.ChatMessageId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatMessageReceiverId);
    }

    /// <inheritdoc/>
    public void Delete(ChatMessageReceiver entity) {
      DbCommand command = BuildDeleteStatement<ChatMessageReceiver>();
      command.CommandText += " WHERE ChatMessageReceiverId =@ChatMessageReceiverId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatMessageReceiverId", entity.ChatMessageReceiverId);
      ExecuteNonQuery(command, entity, entity.ChatMessageReceiverId);
    }

    /// <inheritdoc/>
    public ChatMessageReceiver GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatMessageReceiver>() + " WHERE ChatMessageReceiverId=@ChatMessageReceiverId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatMessageReceiverId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatMessageReceiver>(sql, (int)ChatEntityType.ChatMessageReceiver, sqlParams, id).FirstOrDefault();
    }

    #endregion


  }
}
