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
  /// Provides methods for add, update, delete and search operations on Chat Message attachment.
  /// </summary>
  public class ChatMessageAttachmentData : BaseData, IChatMessageAttachmentData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatMessageAttachmentData()
      : base(ChatMessageAttachment.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get chatmessageAttachment detail information.
    private string GetSQL() {
      string sql = " SELECT  [ChatMessageAttachmentId],[ChatMessageId],[ChatThreadId], " +
                   " [AttachmentStream], [Thumbnail],[FileName],[FileExtension],[TenantId], " +
                   " [CreatedBy],[CreatedDate],[ModifiedDate] ,[Version] " +
                   " From [ChatMessageAttachment] ";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<ChatMessageAttachment,Guid> Members

    /// <inheritdoc/>
    public ChatMessageAttachment GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatMessageAttachment>() + " WHERE ChatMessageAttachmentId=@ChatMessageAttachmentId";
      object[] sqlParam = new object[] { "ChatMessageAttachmentId;" + id.ToString() };
      return ExecuteSql<ChatMessageAttachment>(sql, (int)ChatEntityType.ChatMessageAttachment, sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatMessageAttachmentId=@ChatMessageAttachmentId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatMessageAttachmentId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the ChatMessageAttachment records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatMessageAttachment> GetList() {
      // This method is not supported because it will return all the ChatMessageAttachment records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatMessageAttachment entity) {
      // Generate new id for ChatMessageAttachmentId.
      entity.ChatMessageAttachmentId = Guid.NewGuid();
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Tenant and CreatedBy.      
      if (session != null) {
        entity.CreatedBy = session.UserId;
        entity.TenantId = session.TenantId;
      }

      // Update created and modified datetime with current date and time.
      entity.CreatedDate = DateTime.Now.ToUniversalTime();
      entity.ModifiedBy = entity.CreatedBy;
      entity.ModifiedDate = entity.CreatedDate;

      DbCommand command = BuildInsertStatement<ChatMessageAttachment>(entity);
      ExecuteNonQuery(command, entity, entity.ChatMessageAttachmentId);
      return entity.ChatMessageAttachmentId;
    }

    /// <inheritdoc/>
    public void Update(ChatMessageAttachment entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Modifed by with login user id.
      if (session != null) {
        entity.ModifiedBy = session.UserId;
      }

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatMessageAttachment>(entity);
      command.CommandText += " WHERE ChatMessageAttachmentId=@ChatMessageAttachmentId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatMessageAttachmentId", entity.ChatMessageAttachmentId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatMessageAttachmentId);
    }

    /// <inheritdoc/>
    public void Delete(ChatMessageAttachment entity) {
      DbCommand command = BuildDeleteStatement<ChatMessageAttachment>();
      command.CommandText += " WHERE ChatMessageAttachmentId =@ChatMessageAttachmentId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatMessageAttachmentId", entity.ChatMessageAttachmentId);
      ExecuteNonQuery(command, entity, entity.ChatMessageAttachmentId);
    }

    /// <inheritdoc/>
    public ChatMessageAttachment GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatMessageAttachment>() + " WHERE ChatMessageAttachmentId=@ChatMessageAttachmentId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatMessageAttachmentId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatMessageAttachment>(sql, (int)ChatEntityType.ChatMessageAttachment, sqlParams, id).FirstOrDefault();
    }

    #endregion


  }
}
