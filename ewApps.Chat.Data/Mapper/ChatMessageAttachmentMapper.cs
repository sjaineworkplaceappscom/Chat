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
  public class ChatMessageAttachmentMapper : BaseMapper, IRowMapper<ChatMessageAttachment> {

    #region Constructor


    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMessageAttachmentMapper() {
    }

    #endregion

    #region IRowMapper<ChatMessageAttachment> Members

    public ChatMessageAttachment MapRow(IDataRecord row) {
      ChatMessageAttachment chatMessageAttachment = new ChatMessageAttachment();
      int columnIndex = -1;

      columnIndex = GetColumnIndex("ChatMessageAttachmentId", row);
      if (columnIndex >= 0)
        chatMessageAttachment.ChatMessageAttachmentId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatThreadId", row);
      if (columnIndex >= 0)
        chatMessageAttachment.ChatThreadId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("ChatMessageId", row);
      if (columnIndex >= 0)
        chatMessageAttachment.ChatMessageId = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("AttachmentStream", row);
      if (columnIndex >= 0)
        chatMessageAttachment.AttachmentStream= row.GetString(columnIndex);

      columnIndex = GetColumnIndex("Thumbnail", row);
      if (columnIndex >= 0)
        chatMessageAttachment.Thumbnail = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("FileName", row);
      if (columnIndex >= 0)
        chatMessageAttachment.FileName = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("FileExtension", row);
      if (columnIndex >= 0)
        chatMessageAttachment.FileExtension = row.GetString(columnIndex);

      columnIndex = GetColumnIndex("CreatedBy", row);
      if (columnIndex >= 0)
        chatMessageAttachment.CreatedBy = row.GetGuid(columnIndex);

      columnIndex = GetColumnIndex("CreatedDate", row);
      if (columnIndex >= 0)
        chatMessageAttachment.CreatedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("ModifiedDate", row);
      if (columnIndex >= 0)
        chatMessageAttachment.ModifiedDate = row.GetDateTime(columnIndex);

      columnIndex = GetColumnIndex("Version", row);
      if (columnIndex >= 0)
        chatMessageAttachment.Version = (byte[])row["Version"];

      columnIndex = GetColumnIndex("TenantId", row);
      if (columnIndex >= 0)
        chatMessageAttachment.TenantId = row.GetGuid(columnIndex);

      chatMessageAttachment.ClearChanges();

      return chatMessageAttachment;
    }

    #endregion
  }
}
