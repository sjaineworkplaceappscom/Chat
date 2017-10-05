using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;

namespace ewApps.Chat.Entity {
  [TableMapper("ChatMessageReceiver")]
  public class ChatMessageReceiver : BaseEntity, IValidator<ChatMessageReceiver> {
    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatMessageReceiver";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMessageReceiver() {
    }

    #endregion

    #region Properties

    private Guid _chatMessageReceiverId;
    /// <summary>
    /// Gets or sets the chat message identifier.
    /// </summary>
    [ColumnMapper("ChatMessageReceiverId", DbType.Guid, true, false, false)]
    public Guid ChatMessageReceiverId {
      get {
        return _chatMessageReceiverId;
      }
      set {
        SetPropertyField<Guid>(() => ChatMessageReceiverId, ref _chatMessageReceiverId, value);
      }
    }

    private Guid _chatMessageId;
    /// <summary>
    /// Gets or sets the chatmessageId.
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
    /// Gets or sets the chatThreadId.
    /// </summary>
    [ColumnMapper("ChatThreadId", DbType.Guid)]
    public Guid ChatThreadId {
      get {

        return _chatThreadId;
      }
      set {
        SetPropertyField<Guid>(() => ChatThreadId, ref _chatThreadId, value);
      }
    }    /// <summary>
    private Guid _senderInternal;
    /// <summary>
    /// Gets or sets the SenderInternal.
    /// </summary>
    [ColumnMapper("SenderInternal", DbType.Guid)]
    public Guid SenderInternal {
      get {

        return _senderInternal;
      }
      set {
        SetPropertyField<Guid>(() => SenderInternal, ref _senderInternal, value);
      }
    }
    private string _senderExternal;
    /// <summary>
    /// Gets or sets the SenderExternal.
    /// </summary>
    [ColumnMapper("SenderExternal", DbType.String)]
    public string SenderExternal {
      get {

        return _senderExternal;
      }
      set {
        SetPropertyField<string>(() => SenderExternal, ref _senderExternal, value);
      }
    }
    private Guid _receiverInternal;
    /// <summary>
    /// Gets or sets the receiverInternal.
    /// </summary>
    [ColumnMapper("ReceiverInternal", DbType.Guid)]
    public Guid ReceiverInternal {
      get {

        return _receiverInternal;
      }
      set {
        SetPropertyField<Guid>(() => ReceiverInternal, ref _receiverInternal, value);
      }
    }
    private string _receiverExternal;
    /// <summary>
    /// Gets or sets the ReceiverExternal.
    /// </summary>
    [ColumnMapper("ReceiverExternal", DbType.String)]
    public string ReceiverExternal {
      get {

        return _receiverExternal;
      }
      set {
        SetPropertyField<string>(() => ReceiverExternal, ref _receiverExternal, value);
      }
    }


    private DateTime _readDate;
    /// <summary>
    /// Gets or sets the read date.
    /// </summary>
    [ColumnMapper("ReadDate", DbType.DateTime2)]
    public DateTime ReadDate {
      get {
        return _readDate;
      }
      set {
        SetPropertyField<DateTime>(() => ReadDate, ref _readDate, value);
      }
    }


    private DateTime _deliveryDate;
    /// <summary>
    /// Gets or sets the Delivery date.
    /// </summary>
    [ColumnMapper("DeliveryDate", DbType.DateTime2)]
    public DateTime DeliveryDate {
      get {
        return _deliveryDate;
      }
      set {
        SetPropertyField<DateTime>(() => DeliveryDate, ref _deliveryDate, value);
      }
    }

    private DateTime _likeDate;

    /// <summary>
    /// Gets or sets the LikeDate
    /// </summary>
    [ColumnMapper("LikeDate", DbType.DateTime2)]
    public DateTime LikeDate {
      get {
        return _likeDate;
      }
      set {
        SetPropertyField<DateTime>(() => LikeDate, ref _likeDate, value);
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
    #endregion Properties

    #region IValidator<ChatMessageReceiver> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public IEnumerable<EwpErrorData> BrokenRules(ChatMessageReceiver entity) {

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
