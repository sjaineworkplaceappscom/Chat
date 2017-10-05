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
  /// Provides methods for add, update, delete operations on chatmutesetting entity.
  /// </summary>
  public class ChatMuteSettingData : BaseData, IChatMuteSettingData {

    #region Constructor

    /// <summary>
    /// Default constructor to initialize variables (if any).
    /// </summary>
    public ChatMuteSettingData()
      : base(ChatMuteSetting.EntityName, false, new ChatMapperFactory()) {
    }

    #endregion Constructor

    #region Private Methods

    // Returns general sql as string to get chatmutesetting detail information.
    private string GetSQL() {
      string sql = " SELECT [UserId],[ChatThreadId],[FromDate],[ToDate],[Mute],[ModifiedDate],[CreatedDate],[Version] " +
                   " FROM [ChatMuteSetting]";
      return sql;
    }

    #endregion Private Methods

    #region IBaseData<ChatMuteSetting,Guid> Members

    /// <inheritdoc/>
    public ChatMuteSetting GetEntity(Guid id) {
      string sql = BuildSelectStatement<ChatMuteSetting>() + " WHERE UserId=@UserId";
      object[] sqlParam = new object[] { "UserId;" + id.ToString() };
      return ExecuteSql<ChatMuteSetting>(sql, (int)ChatEntityType.ChatMuteSetting, sqlParam, id).FirstOrDefault();
    }

    /// <inheritdoc/>
    public DataTable GetEntityAsDT(Guid id) {
      string sql = GetSQL() + " WHERE UserId=@UserId";
      DbCommand command = CreateCommand(sql);
      AddInParameter(command, DbType.Guid, "UserId", id);
      return ExecuteDataSet(command, id).Tables[0];
    }

    /// <inheritdoc/>
    public DataTable GetListAsDT() {
      // This method is not supported because it will return all the chatmutesetting records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public List<ChatMuteSetting> GetList() {
      // This method is not supported because it will return all the chatmutesetting records without any filter.   
      Exception ex = new ewApps.CommonRuntime.Common.InvalidOperationException(ServerMessages.MethodNotSupported);
      bool rethrow = DataExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Wrap);
      if (rethrow) {
        throw ex;
      }
      return null;
    }

    /// <inheritdoc/>
    public Guid Add(ChatMuteSetting entity) {
      entity.CreatedDate = DateTime.Now.ToUniversalTime();
      entity.ModifiedDate = entity.CreatedDate;

      // Generate new id for chat messagereceiver.        
      DbCommand command = BuildInsertStatement<ChatMuteSetting>(entity);
      ExecuteNonQuery(command, entity, entity.UserId);
      return entity.UserId;
    }

    /// <inheritdoc/>
    public void Update(ChatMuteSetting entity) {
      entity.ModifiedDate = DateTime.Now.ToUniversalTime(); 

      //Execute commands.
      DbCommand command = BuildUpdateStatement<ChatMuteSetting>(entity);
      command.CommandText += " WHERE UserId=@UserId AND Version = @Version";
      AddInParameter(command, DbType.Guid, "UserId", entity.UserId);
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      ExecuteNonQuery(command, entity, entity.UserId);
    }

    /// <inheritdoc/>
    public void Delete(ChatMuteSetting entity) {
      DbCommand command = BuildDeleteStatement<ChatMuteSetting>();
      command.CommandText += " WHERE UserId =@UserId AND Version = @Version";
      AddInParameter(command, DbType.Binary, "Version", entity.Version);
      AddInParameter(command, DbType.Guid, "UserId", entity.UserId);
      ExecuteNonQuery(command, entity, entity.UserId);
    }

    /// <inheritdoc/>
    public ChatMuteSetting GetEntity(Guid id, byte[] version) {
      string sql = BuildSelectStatement<ChatMessageReceiver>() + " WHERE UserId=@UserId AND Version = @SelectVersion";
      object[] sqlParams = new object[] { "UserId;" + id.ToString(), "SelectVersion;" + Convert.ToBase64String(version) };
      return ExecuteSql<ChatMuteSetting>(sql, (int)ChatEntityType.ChatMuteSetting, sqlParams, id).FirstOrDefault();
    }

    #endregion


  }
}
