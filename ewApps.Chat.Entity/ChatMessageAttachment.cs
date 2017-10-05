using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;

namespace ewApps.Chat.Entity {
  [TableMapper("ChatMessageAttachment")]
  public class ChatMessageAttachment : BaseEntity, IValidator<ChatMessageAttachment> {

    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatMessageAttachment";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMessageAttachment() {
    }

    #endregion

    #region Properties
    private Guid _chatMessageAttachmentId;
    /// <summary>
    /// Gets or sets the chat message attachment identifier.
    /// </summary>
    [ColumnMapper("ChatMessageAttachmentId", DbType.Guid, true, false, false)]
    public Guid ChatMessageAttachmentId {
      get {
        return _chatMessageAttachmentId;
      }
      set {
        SetPropertyField<Guid>(() => ChatMessageAttachmentId, ref _chatMessageAttachmentId, value);
      }
    }
    private Guid _chatMessageId;
    /// <summary>
    /// Gets or sets the ChatMessageId.
    /// </summary>
    [ColumnMapper("ChatMessageId", DbType.Guid)]
    public Guid ChatMessageId {
      get {

        return _chatMessageId;
      }
      set {
        SetPropertyField<Guid>(() => ChatMessageId, ref _chatMessageId, value);
      }
    }
    private Guid _chatThreadId;
    /// <summary>
    /// Gets or sets the ChatThreadId.
    /// </summary>
    [ColumnMapper("ChatThreadId", DbType.Guid)]
    public Guid ChatThreadId {
      get {

        return _chatThreadId;
      }
      set {
        SetPropertyField<Guid>(() => ChatThreadId, ref _chatThreadId, value);
      }
    }

    private string _attachmentStream;
    /// <summary>
    /// Gets or sets the Attachment Stream.
    /// </summary>
    [ColumnMapper("AttachmentStream", DbType.String)]
    public string AttachmentStream {
      get {
        return _attachmentStream;
      }
      set {
        SetPropertyField<string>(() => AttachmentStream, ref _attachmentStream, value);

      }
    }

    private string _thumbnail;
    /// <summary>
    /// Gets or sets the Thumbnail.
    /// </summary>
    [ColumnMapper("Thumbnail", DbType.String)]
    public string Thumbnail {
      get {
        return _thumbnail;
      }
      set {
        SetPropertyField<string>(() => Thumbnail, ref _thumbnail, value);

      }
    }

    private string _fileName;
    /// <summary>
    /// Gets or sets the FileName.
    /// </summary>
    [ColumnMapper("FileName", DbType.String)]
    public string FileName {
      get {
        return _fileName;
      }
      set {
        SetPropertyField<string>(() => FileName, ref _fileName, value);

      }
    }
    private string _fileExtension;
    /// <summary>
    /// Gets or sets the FileExtension.
    /// </summary>
    [ColumnMapper("FileExtension", DbType.String)]
    public string FileExtension {
      get {
        return _fileExtension;
      }
      set {
        SetPropertyField<string>(() => FileExtension, ref _fileExtension, value);

      }
    }

    public override Guid? ModifiedBy {
      get {
        return base.ModifiedBy;
      }
      set {
        base.ModifiedBy = value;
      }
    }
    #endregion Properties

    #region IValidator<ChatMessageAttachment> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public IEnumerable<EwpErrorData> BrokenRules(ChatMessageAttachment entity) {
      if (entity.ChatMessageId == Guid.Empty) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ChatMessageId",
          Message = string.Format(ServerMessages.FieldIsRequired, "ChatMessageId")
        };
      }
      if (entity.ChatThreadId == Guid.Empty) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ChatThreadId",
          Message = string.Format(ServerMessages.FieldIsRequired, "ChatThreadId")
        };
      }

      if (string.IsNullOrEmpty(entity.AttachmentStream)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "AttachmentStream",
          Message = string.Format(ServerMessages.FieldIsRequired, "AttachmentStream")
        };
      }

      if (string.IsNullOrEmpty(entity.Thumbnail)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "Thumbnail",
          Message = string.Format(ServerMessages.FieldIsRequired, "Thumbnail")
        };
      }

      if (string.IsNullOrEmpty(entity.FileName)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "FileName",
          Message = string.Format(ServerMessages.FieldIsRequired, "FileName")
        };
      }

      if (string.IsNullOrEmpty(entity.FileExtension)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "FileExtension",
          Message = string.Format(ServerMessages.FieldIsRequired, "FileExtension")
        };
      }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="brokenRules"></param>
    /// <returns></returns>

    public bool Validate(out IList<EwpErrorData> brokenRules) {
      brokenRules = BrokenRules(this).ToList<EwpErrorData>();
      return brokenRules.Count > 0;
    }

    #endregion
  }
}
