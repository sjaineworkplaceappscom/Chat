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
  public class ChatThreadMemberMapper : BaseMapper, IRowMapper<ChatThreadMember> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatThreadMemberMapper() {
    }

    #endregion

    #region IRowMapper<ChatThreadMember> Members

    public ChatThreadMember MapRow(IDataRecord row) {
      ChatThreadMember chatThreadMember = new ChatThreadMember();
      int columnIndex = -1;


      columnIndex = GetColumnIndex("ChatThreadMemberId", row);
      if (columnIndex >= 0)
        chatThreadMember.ChatThreadMemberId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatThreadId", row);
      if (columnIndex >= 0)
        chatThreadMember.ChatThreadId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ReceiverInternal", row);
      if (columnIndex >= 0)
        chatThreadMember.ReceiverInternal = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ReceiverExternal", row);
      if (columnIndex >= 0)
        chatThreadMember.ReceiverExternal = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("ReceiverType", row);
      if (columnIndex >= 0)
        chatThreadMember.ReceiverType = row.GetInt32(columnIndex);

      columnIndex = GetColumnIndex("CreatedBy", row);
      if (columnIndex >= 0)
        chatThreadMember.CreatedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatThreadMember.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedBy", row);
      if (columnIndex >= 0)
        chatThreadMember.ModifiedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatThreadMember.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatThreadMember.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatThreadMember.TenantId = row.GetGuid(columnIndex);

      chatThreadMember.ClearChanges();

      return chatThreadMember;
    }

    #endregion
  }
}
