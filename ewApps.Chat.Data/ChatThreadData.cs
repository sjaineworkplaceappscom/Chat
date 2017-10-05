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
  /// Provides methods for add, update, delete and search operations on ChatThread entity.
  /// </summary>
  public class ChatThreadData : BaseData, IChatThreadData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatThreadData()
      : base(ChatThreadMember.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get chatthread entity detail information.
    private string GetSQL() {
      string sql = " SELECT [ChatThreadId],[ThreadName],[ThreadType],[Archived],[TenantId], " +
                   " [CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[Version] " +
                   " FROM [ChatThread] ";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<Employee,Guid> Members

    /// <inheritdoc/>
    public ChatThread GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatThread>() + " WHERE ChatThreadId=@ChatThreadId";
      object[] sqlParam = new object[] { "ChatThreadId;" + id.ToString() };
      return ExecuteSql<ChatThread>(sql, (int)ChatEntityType.ChatThread, sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatThreadId=@ChatThreadId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatThreadId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the chatthread records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatThread> GetList() {
      // This method is not supported because it will return all the chatthread records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatThread entity) {
      // Generate new id for department.
      entity.ChatThreadId = Guid.NewGuid();
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

      DbCommand command = BuildInsertStatement<ChatThread>(entity);
      ExecuteNonQuery(command, entity, entity.ChatThreadId);
      return entity.ChatThreadId;
    }

    /// <inheritdoc/>
    public void Update(ChatThread entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Modifed by with login user id.
      if (session != null) {
        entity.ModifiedBy = session.UserId;
      }

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatThread>(entity);
      command.CommandText += " WHERE ChatThreadId=@ChatThreadId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatThreadId", entity.ChatThreadId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatThreadId);
    }

    /// <inheritdoc/>
    public void Delete(ChatThread entity) {
      DbCommand command = BuildDeleteStatement<ChatThread>();
      command.CommandText += " WHERE ChatThreadId =@ChatThreadId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatThreadId", entity.ChatThreadId);
      ExecuteNonQuery(command, entity, entity.ChatThreadId);
    }

    /// <inheritdoc/>
    public ChatThread GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatThread>() + " WHERE ChatThreadId=@ChatThreadId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatThreadId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatThread>(sql, (int)ChatEntityType.ChatThread, sqlParams, id).FirstOrDefault();
    }

    #endregion


  }
}
