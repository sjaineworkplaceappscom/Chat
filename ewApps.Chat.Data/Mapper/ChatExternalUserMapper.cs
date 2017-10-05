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
  public class ChatExternalUserMapper : BaseMapper, IRowMapper<ChatExternalUser> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatExternalUserMapper() {
    }

    #endregion

    #region IRowMapper<ChatExternalUser> Members

    public ChatExternalUser MapRow(IDataRecord row) {
      ChatExternalUser chatExternalUser = new ChatExternalUser();
      int columnIndex = -1;


      columnIndex = GetColumnIndex("ChatExternalUserId", row);
      if (columnIndex >= 0)
        chatExternalUser.ChatExternalUserId = row.GetGuid(columnIndex);

     
      columnIndex = GetColumnIndex("Name", row);
      if (columnIndex >= 0)
        chatExternalUser.Name = row.GetString(columnIndex);


      columnIndex = GetColumnIndex("Email", row);
      if (columnIndex >= 0)
        chatExternalUser.Email = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("CreatedBy", row);
      if (columnIndex >= 0)
        chatExternalUser.CreatedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatExternalUser.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatExternalUser.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatExternalUser.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatExternalUser.TenantId = row.GetGuid(columnIndex);

      chatExternalUser.ClearChanges();

      return chatExternalUser;
    }

    #endregion
  }
}
