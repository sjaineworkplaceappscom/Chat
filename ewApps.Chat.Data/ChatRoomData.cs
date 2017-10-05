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
  /// Provides methods for add, update, delete and search operations on ChatRoom entity.
  /// </summary>
  public class ChatRoomData : BaseData, IChatRoomData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatRoomData()
      : base(ChatRoom.EntityName,false,new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get chatroom entity detail information.
    private string GetSQL() {
      string sql = " SELECT [ChatRoomId],[Name],[Private],[Archived],[Topic],[GreetingMessage], "+
                   " [OwnerId],[TenantId],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[Version] "+
                   " FROM [ChatRoom] ";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<Employee,Guid> Members

    /// <inheritdoc/>
    public ChatRoom GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatRoom>() + " WHERE ChatRoomId=@ChatRoomId";
      object[] sqlParam = new object[] { "ChatRoomId;" + id.ToString() };
      return ExecuteSql<ChatRoom>(sql, (int)ChatEntityType.ChatRoom,sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE ChatRoomId=@ChatRoomId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "ChatRoomId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the chatroom records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatRoom> GetList() {
      // This method is not supported because it will return all the chatroom records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatRoom entity) {
      // Generate new id for chatroomid.
      entity.ChatRoomId = Guid.NewGuid();
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Tenant and CreatedBy      
      if (session != null) {
        entity.CreatedBy = session.UserId;
      }

      // Update created and modified datetime with current date and time.
      entity.CreatedDate = DateTime.Now.ToUniversalTime();
      entity.ModifiedBy = entity.CreatedBy;
      entity.ModifiedDate = entity.CreatedDate;

      DbCommand command = BuildInsertStatement<ChatRoom>(entity);
      ExecuteNonQuery(command, entity, entity.ChatRoomId);
      return entity.ChatRoomId;
    }

    /// <inheritdoc/>
    public void Update(ChatRoom entity) {
      EwAppSession session = EwAppSessionManager.GetSession();

      // Set Modifed by with login user id.
      if (session != null) {
        entity.ModifiedBy = session.UserId;
      }

      //set modified Date time eith current date and time.
      entity.ModifiedDate = DateTime.Now.ToUniversalTime();

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatRoom>(entity);
      command.CommandText += " WHERE ChatRoomId=@ChatRoomId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "ChatRoomId", entity.ChatRoomId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.ChatRoomId);
    }

    /// <inheritdoc/>
    public void Delete(ChatRoom entity) {
      DbCommand command = BuildDeleteStatement<ChatRoom>();
      command.CommandText += " WHERE ChatRoomId =@ChatRoomId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "ChatRoomId", entity.ChatRoomId);
      ExecuteNonQuery(command, entity, entity.ChatRoomId);
    }

    /// <inheritdoc/>
    public ChatRoom GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatRoom>() + " WHERE ChatRoomId=@ChatRoomId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "ChatRoomId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatRoom>(sql, (int)ChatEntityType.ChatRoom, sqlParams, id).FirstOrDefault();
    }

    #endregion

    
  }
}
