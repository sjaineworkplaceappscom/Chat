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
  public class ChatMessageMapper : BaseMapper, IRowMapper<ChatMessage> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMessageMapper() {
    }

    #endregion

    #region IRowMapper<ChatMessage> Members

    public ChatMessage MapRow(IDataRecord row) {
      ChatMessage chatMessage = new ChatMessage();
      int columnIndex = -1;

      columnIndex = GetColumnIndex("ChatMessageId", row);
      if (columnIndex >= 0)
        chatMessage.ChatMessageId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatThreadId", row);
      if (columnIndex >= 0)
        chatMessage.ChatThreadId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("Message", row);
      if (columnIndex >= 0)
        chatMessage.Message = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("MessageType", row);
      if (columnIndex >= 0)
        chatMessage.MessageType= row.GetInt32(columnIndex);

      columnIndex = GetColumnIndex("CreatedByName", row);
      if (columnIndex >= 0)
        chatMessage.CreatedByName = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatMessage.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatMessage.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatMessage.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatMessage.TenantId = row.GetGuid(columnIndex);

      chatMessage.ClearChanges();

      return chatMessage;
    }

    #endregion
  }
}
