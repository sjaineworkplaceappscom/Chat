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
  /// Provides methods for add, update, delete and search operations on ChatThreadMember.
  /// </summary>
  public class ChatThreadMemberData : BaseData, IChatThreadMemberData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatThreadMemberData()
      : base(ChatThreadMember.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get ChatThreadMember detail information.
    private string GetSQL() {
      string sql = " SELECT [ChatThreadMemberId],[ChatThreadId],[ReceiverInternal],[ReceiverExternal], " +
                   " [ReceiverType],[TenantId],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[Version] " +
                   " FROM [ChatThreadMember] ";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<Employee,Guid> Members

    /// <inheritdoc/>
    public ChatThreadMember GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatThreadMember>() + " WHERE ChatThreadMemberId=@ChatThreadMemberId";
      object[] sqlParam = new object[] { "ChatThreadMemberId;" + id.ToString() };
      return ExecuteSql<ChatThreadMember>(sql, (int)ChatEntityType.ChatThreadMember, sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatThreadMemberId=@ChatThreadMemberId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatThreadMemberId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the chatthreadmember records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatThreadMember> GetList() {
      // This method is not supported because it will return all the chatthreadmember records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatThreadMember entity) {
      // Generate new id for department.
      entity.ChatThreadMemberId = Guid.NewGuid();
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

      DbCommand command = BuildInsertStatement<ChatThreadMember>(entity);
      ExecuteNonQuery(command, entity, entity.ChatThreadMemberId);
      return entity.ChatThreadMemberId;
    }

    /// <inheritdoc/>
    public void Update(ChatThreadMember entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Modifed by with login user id.
      if (session != null) {
        entity.ModifiedBy = session.UserId;
      }

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatThreadMember>(entity);
      command.CommandText += " WHERE ChatThreadMemberId=@ChatThreadMemberId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatThreadMemberId", entity.ChatThreadMemberId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatThreadMemberId);
    }

    /// <inheritdoc/>
    public void Delete(ChatThreadMember entity) {
      DbCommand command = BuildDeleteStatement<ChatThreadMember>();
      command.CommandText += " WHERE ChatThreadMemberId =@ChatThreadMemberId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatThreadMemberId", entity.ChatThreadMemberId);
      ExecuteNonQuery(command, entity, entity.ChatThreadMemberId);
    }

    /// <inheritdoc/>
    public ChatThreadMember GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatThreadMember>() + " WHERE ChatThreadMemberId=@ChatThreadMemberId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatThreadMemberId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatThreadMember>(sql, (int)ChatEntityType.ChatThreadMember, sqlParams, id).FirstOrDefault();
    }

    #endregion


  }
}
