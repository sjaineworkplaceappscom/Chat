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
  /// Provides methods for add, update, delete and search operations on chatroommember.
  /// </summary>
  public class ChatRoomMemberData : BaseData, IChatRoomMemberData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatRoomMemberData()
      : base(ChatRoomMember.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get chatroom's detail information.
    private string GetSQL() {
      string sql = " SELECT [ChatRoomMemberId],[ChatRoomId],[MemberId],[Internal],[EmailId], [Name] ,"+
                   " [TenantId],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], "+
                   " [Version] "+
                   " FROM [ChatRoomMember] ";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<Employee,Guid> Members

    /// <inheritdoc/>
    public ChatRoomMember GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatRoomMember>() + " WHERE ChatRoomMemberId=@ChatRoomMemberId";
      object[] sqlParam = new object[] { "ChatRoomMemberId;" + id.ToString() };
      return ExecuteSql<ChatRoomMember>(sql, (int)ChatEntityType.ChatRoomMember,sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatRoomMemberId=@ChatRoomMemberId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatRoomMemberId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the chatroommember records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatRoomMember> GetList() {
      // This method is not supported because it will return all the chatroommember records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatRoomMember entity) {
      // Generate new id for department.
      entity.ChatRoomMemberId = Guid.NewGuid();
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Tenant and CreatedBy
      if (session != null) {
        entity.CreatedBy = session.UserId;
        entity.TenantId=session.TenantId;
      }

      // Update created and modified datetime with current date and time.
      entity.CreatedDate = DateTime.Now.ToUniversalTime();
      entity.ModifiedBy = entity.CreatedBy;
      entity.ModifiedDate = entity.CreatedDate;

      DbCommand command = BuildInsertStatement<ChatRoomMember>(entity);
      ExecuteNonQuery(command, entity, entity.ChatRoomMemberId);
      return entity.ChatRoomMemberId;
    }

    /// <inheritdoc/>
    public void Update(ChatRoomMember entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Modifed by with login user id.
      if (session != null) {
        entity.ModifiedBy = session.UserId;
      }

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatRoomMember>(entity);
      command.CommandText += " WHERE ChatRoomMemberId=@ChatRoomMemberId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatRoomMemberId", entity.ChatRoomMemberId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatRoomMemberId);
    }

    /// <inheritdoc/>
    public void Delete(ChatRoomMember entity) {
      DbCommand command = BuildDeleteStatement<ChatRoomMember>();
      command.CommandText += " WHERE ChatRoomMemberId =@ChatRoomMemberId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatRoomMemberId", entity.ChatRoomMemberId);
      ExecuteNonQuery(command, entity, entity.ChatRoomMemberId);
    }

    /// <inheritdoc/>
    public ChatRoomMember GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatRoomMember>() + " WHERE ChatRoomMemberId=@ChatRoomMemberId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatRoomMemberId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatRoomMember>(sql, (int)ChatEntityType.ChatRoomMember, sqlParams, id).FirstOrDefault();
    }

    #endregion

    
  }
}
