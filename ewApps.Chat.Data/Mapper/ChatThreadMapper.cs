using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ewApps.CommonRuntime.Data;
using ewApps.Chat.Entity;
using System.Data;

namespace ewApps.Chat.Data {

  /// <summary>
  /// Maps data table field values to Department entity properties.
  /// It maps entity parameter collection to sql parameters and also maps data reader to entity object.  
  /// </summary>
  public class ChatThreadMapper : BaseMapper, IRowMapper<ChatThread> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatThreadMapper() {
    }

    #endregion

    #region IRowMapper<ChatThread> Members

    public ChatThread MapRow(IDataRecord row) {
      ChatThread chatThread = new ChatThread();
      int columnIndex = -1;

    
      columnIndex = GetColumnIndex("ChatThreadId", row);
      if (columnIndex >= 0)
        chatThread.ChatThreadId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ThreadName", row);
      if (columnIndex >= 0)
        chatThread.ThreadName = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("ThreadType", row);
      if (columnIndex >= 0)
        chatThread.ThreadType = row.GetInt32(columnIndex);

      columnIndex = GetColumnIndex("Archived", row);
      if (columnIndex >= 0)
        chatThread.Archived = row.GetBoolean(columnIndex);

      columnIndex = GetColumnIndex("CreatedBy", row);
      if (columnIndex >= 0)
        chatThread.CreatedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatThread.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedBy", row);
      if (columnIndex >= 0)
        chatThread.ModifiedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatThread.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatThread.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatThread.TenantId = row.GetGuid(columnIndex);

      chatThread.ClearChanges();

      return chatThread;
    }

    #endregion
  }
}
