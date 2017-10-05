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
  public class ChatRoomMapper : BaseMapper, IRowMapper<ChatRoom> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatRoomMapper() {
    }

    #endregion

    #region IRowMapper<ChatRoom> Members

    public ChatRoom MapRow(IDataRecord row) {
      ChatRoom chatRoom= new ChatRoom();
      int columnIndex = -1;

      columnIndex = GetColumnIndex("ChatRoomId", row);
      if (columnIndex >= 0)
        chatRoom.ChatRoomId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("Name", row);
      if (columnIndex >= 0)
        chatRoom.Name = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("Private", row);
      if (columnIndex >= 0)
        chatRoom.Private= row.GetBoolean(columnIndex);

      columnIndex = GetColumnIndex("Archived", row);
      if (columnIndex >= 0)
        chatRoom.Archived = row.GetBoolean(columnIndex);

      columnIndex = GetColumnIndex("Topic", row);
      if (columnIndex >= 0)
        chatRoom.Topic = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("GreetingMessage", row);
      if (columnIndex >= 0)
        chatRoom.GreetingMessage = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("OwnerId", row);
      if (columnIndex >= 0)
        chatRoom.OwnerId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("CreatedBy", row);
      if (columnIndex >= 0)
        chatRoom.CreatedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatRoom.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedBy", row);
      if (columnIndex >= 0)
        chatRoom.ModifiedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatRoom.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatRoom.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatRoom.TenantId = row.GetGuid(columnIndex);

        chatRoom.ClearChanges();

      return chatRoom;
    }

    #endregion
  }
}
