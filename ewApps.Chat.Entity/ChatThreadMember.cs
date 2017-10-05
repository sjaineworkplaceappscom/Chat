using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;

namespace ewApps.Chat.Entity {
  [TableMapper("ChatThreadMember")]
  public class ChatThreadMember : BaseEntity, IValidator<ChatThreadMember> {
    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatThreadMember";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatThreadMember() {
    }

    #endregion

    #region Properties
    private Guid _chatThreadMemberId;
    /// <summary>
    /// Gets or sets the chat thread member identifier.
    /// </summary>
    [ColumnMapper("ChatThreadMemberId", DbType.Guid, true, false, false)]
    public Guid ChatThreadMemberId {
      get {
        return _chatThreadMemberId;
      }
      set {
        SetPropertyField<Guid>(() => ChatThreadMemberId, ref _chatThreadMemberId, value);
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
    private Guid _receiverInternal;
    /// <summary>
    /// Gets or sets the receiver internal.
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
    /// Gets or sets the receiver external.
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
    private int _receiverType;
    /// <summary>
    /// Gets or sets the receiver type.
    /// </summary>
    [ColumnMapper("ReceiverType", DbType.Int32)]
    public int ReceiverType {
      get {

        return _receiverType;
      }
      set {
        SetPropertyField<Int32>(() => ReceiverType, ref _receiverType, value);
      }
    }

    #endregion Properties



    #region IValidator<ChatThreadMember> Members
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>

    public IEnumerable<EwpErrorData> BrokenRules(ChatThreadMember entity) {


      if (entity.ChatThreadId == Guid.Empty) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ChatThreadId",
          Message = string.Format(ServerMessages.FieldIsRequired, "ChatThreadId")
        };
      }

      if (entity.ReceiverType <= 0) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ReceiverType",
          Message = string.Format(ServerMessages.FieldIsRequired, "ReceiverType")
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
