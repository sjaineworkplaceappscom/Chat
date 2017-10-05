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
  public class ChatRoomMemberMapper : BaseMapper, IRowMapper<ChatRoomMember> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatRoomMemberMapper() {
    }

    #endregion

    #region IRowMapper<ChatRoomMember> Members

    public ChatRoomMember MapRow(IDataRecord row) {
      ChatRoomMember chatRoomMember = new ChatRoomMember();
      int columnIndex = -1;

      columnIndex = GetColumnIndex("ChatRoomMemberId", row);
      if (columnIndex >= 0)
        chatRoomMember.ChatRoomMemberId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatRoomId", row);
      if (columnIndex >= 0)
        chatRoomMember.ChatRoomId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("MemberId", row);
      if (columnIndex >= 0)
        chatRoomMember.MemberId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("Internal", row);
      if (columnIndex >= 0)
        chatRoomMember.Internal = row.GetBoolean(columnIndex);

      columnIndex = GetColumnIndex("EmailId", row);
      if (columnIndex >= 0)
        chatRoomMember.EmailId = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("Name", row);
      if (columnIndex >= 0)
        chatRoomMember.Name = row.GetString(columnIndex);



      columnIndex = GetColumnIndex("CreatedBy", row);
      if (columnIndex >= 0)
        chatRoomMember.CreatedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatRoomMember.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedBy", row);
      if (columnIndex >= 0)
        chatRoomMember.ModifiedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatRoomMember.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatRoomMember.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatRoomMember.TenantId = row.GetGuid(columnIndex);

      chatRoomMember.ClearChanges();

      return chatRoomMember;
    }

    #endregion
  }
}
