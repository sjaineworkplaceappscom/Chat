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
  public class ChatMuteSettingMapper : BaseMapper, IRowMapper<ChatMuteSetting> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMuteSettingMapper() {
    }

    #endregion

    #region IRowMapper<ChatMuteSetting> Members

    public ChatMuteSetting MapRow(IDataRecord row) {
      ChatMuteSetting chatMuteSetting = new ChatMuteSetting();
      int columnIndex = -1;


      columnIndex = GetColumnIndex("UserId", row);
      if (columnIndex >= 0)
        chatMuteSetting.UserId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatThreadId", row);
      if (columnIndex >= 0)
        chatMuteSetting.ChatThreadId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("FromDate", row);
      if (columnIndex >= 0)
        chatMuteSetting.FromDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ToDate", row);
      if (columnIndex >= 0)
        chatMuteSetting.ToDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Mute", row);
      if (columnIndex >= 0)
        chatMuteSetting.Mute = row.GetBoolean(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatMuteSetting.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatMuteSetting.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatMuteSetting.ModifiedDate = row.GetDateTime(columnIndex);


      chatMuteSetting.ClearChanges();

      return chatMuteSetting;
    }

    #endregion
  }
}
