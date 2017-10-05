using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;

namespace ewApps.Chat.Entity {
  [TableMapper("ChatMessage")]
  public class ChatMessage : BaseEntity, IValidator<ChatMessage> {

    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatMessage";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMessage() {
    }

    #endregion

    #region Properties

    private Guid _chatMessageId;
    /// <summary>
    /// Gets or sets the chat message identifier.
    /// </summary>
    [ColumnMapper("ChatMessageId", DbType.Guid, true, false, false)]
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
    /// Gets or sets the chat thread identifier.
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

    private int _messageType;
    /// <summary>
    /// Gets or sets the message type.
    /// </summary>
    [ColumnMapper("MessageType", DbType.Int32)]
    public int MessageType {
      get {

        return _messageType;
      }
      set {
        SetPropertyField<Int32>(() => MessageType, ref _messageType, value);
      }
    }
    private string _message;
    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    [ColumnMapper("Message", DbType.String)]
    public string Message {
      get {
        return _message;
      }
      set {
        SetPropertyField<string>(() => Message, ref _message, value);

      }
    }
    private string _createdByName;
    [ColumnMapper("CreatedBy", DbType.String)]
    public string CreatedByName {
      get {
        return _createdByName;
      }
      set {
        SetPropertyField<string>(() => CreatedByName, ref _createdByName, value);

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

    
    public override Guid? CreatedBy {
      get {
        return base.CreatedBy;
      }
      set {
        base.CreatedBy = value;
      }
    }


    #endregion Properties

    #region IValidator<ChatMessage> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public IEnumerable<EwpErrorData> BrokenRules(ChatMessage entity) {

      if (entity.ChatThreadId == Guid.Empty) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ChatThreadId",
          Message = string.Format(ServerMessages.FieldIsRequired, "ChatThreadId")
        };
      }
      if (entity.MessageType <= 0) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "MessageType",
          Message = string.Format(ServerMessages.FieldIsRequired, "MessageType")
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
