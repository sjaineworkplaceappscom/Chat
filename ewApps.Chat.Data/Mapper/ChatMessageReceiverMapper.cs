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
  public class ChatMessageReceiverMapper : BaseMapper, IRowMapper<ChatMessageReceiver> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMessageReceiverMapper() {
    }

    #endregion

    #region IRowMapper<ChatMessageReceiver> Members

    public ChatMessageReceiver MapRow(IDataRecord row) {
      ChatMessageReceiver chatMessageReceiver = new ChatMessageReceiver();
      int columnIndex = -1;

      columnIndex = GetColumnIndex("ChatMessageReceiverId", row);
      if (columnIndex >= 0)
        chatMessageReceiver.ChatMessageReceiverId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatMessageId", row);
      if (columnIndex >= 0)
        chatMessageReceiver.ChatMessageId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatThreadId", row);
      if (columnIndex >= 0)
        chatMessageReceiver.ChatThreadId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("SenderInternal", row);
      if (columnIndex >= 0)
        chatMessageReceiver.SenderInternal = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("SenderExternal", row);
      if (columnIndex >= 0)
        chatMessageReceiver.SenderExternal = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("ReceiverInternal", row);
      if (columnIndex >= 0)
        chatMessageReceiver.ReceiverInternal = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ReceiverExternal", row);
      if (columnIndex >= 0)
        chatMessageReceiver.ReceiverExternal = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("ReadDate", row);
      if (columnIndex >= 0)
        chatMessageReceiver.ReadDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("LikeDate", row);
      if (columnIndex >= 0)
        chatMessageReceiver.LikeDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("DeliveryDate", row);
      if (columnIndex >= 0)
        chatMessageReceiver.DeliveryDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("CreatedByName", row);
      if (columnIndex >= 0)
        chatMessageReceiver.CreatedByName = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatMessageReceiver.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatMessageReceiver.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatMessageReceiver.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatMessageReceiver.TenantId = row.GetGuid(columnIndex);

      chatMessageReceiver.ClearChanges();

      return chatMessageReceiver;
    }

    #endregion
  }
}
