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
  /// Provides methods for add, update, delete and search operations on ChatExternalUser entity.
  /// </summary>
  public class ChatExternalUserData : BaseData, IChatExternalUserData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatExternalUserData()
      : base(ChatExternalUser.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get ExternalUserData detail information.
    private string GetSQL() {
      string sql = " SELECT [ChatExternalUserId],[Name],[Email],[TenantId],[CreatedDate],  "+
                   " [CreatedBy],[ModifiedDate],[version] "+
                   " FROM [ChatExternalUser] ";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<Employee,Guid> Members

    /// <inheritdoc/>
    public ChatExternalUser GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatExternalUser>() + " WHERE ChatExternalUserId=@ChatExternalUserId";
      object[] sqlParam = new object[] { "ChatExternalUserId;" + id.ToString() };
      return ExecuteSql<ChatExternalUser>(sql, (int)ChatEntityType.ChatExternalUser,sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatExternalUserId=@ChatExternalUserId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatExternalUserId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the chatexternaluser records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatExternalUser> GetList() {
      // This method is not supported because it will return all the chatexternaluser records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatExternalUser entity) {
      // Generate new id for ChatExternalUserId.
      entity.ChatExternalUserId = Guid.NewGuid();
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Tenant and CreatedBy .    
      if (session != null) {
        entity.CreatedBy = session.UserId;
        entity.TenantId=session.TenantId;        
      }
      
      // Update created and modified datetime with current date and time.
      entity.CreatedDate = DateTime.Now.ToUniversalTime();
      entity.ModifiedDate=entity.CreatedDate;

      // Execute query for add entity.
      DbCommand command = BuildInsertStatement<ChatExternalUser>(entity);
      ExecuteNonQuery(command, entity, entity.ChatExternalUserId);
      return entity.ChatExternalUserId;
    }

    /// <inheritdoc/>
    public void Update(ChatExternalUser entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Modifed by with login user id.
      if (session != null) {
        entity.ModifiedBy = session.UserId;
      }

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatExternalUser>(entity);
      command.CommandText += " WHERE ChatExternalUserId=@ChatExternalUserId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatExternalUserId", entity.ChatExternalUserId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatExternalUserId);
    }

    /// <inheritdoc/>
    public void Delete(ChatExternalUser entity) {
      DbCommand command = BuildDeleteStatement<ChatExternalUser>();
      command.CommandText += " WHERE ChatExternalUserId =@ChatExternalUserId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatExternalUserId", entity.ChatExternalUserId);
      ExecuteNonQuery(command, entity, entity.ChatExternalUserId);
    }

    /// <inheritdoc/>
    public ChatExternalUser GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatExternalUser>() + " WHERE ChatExternalUserId=@ChatExternalUserId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatExternalUserId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatExternalUser>(sql, (int)ChatEntityType.ChatExternalUser, sqlParams, id).FirstOrDefault();
    }

    #endregion

    
  }
}
