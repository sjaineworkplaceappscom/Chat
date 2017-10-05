using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;

namespace ewApps.Chat.Entity {
  [TableMapper("ChatRoomMember")]
  public class ChatRoomMember : BaseEntity, IValidator<ChatRoomMember> {

    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatRoomMember";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatRoomMember() {
    }

    #endregion

    #region Properties
    private Guid _chatRoomMemberId;
    /// <summary>
    /// Gets or sets the chat message chat room member identifier.
    /// </summary>
    [ColumnMapper("ChatRoomMemberId", DbType.Guid, true, false, false)]
    public Guid ChatRoomMemberId {
      get {
        return _chatRoomMemberId;
      }
      set {
        SetPropertyField<Guid>(() => ChatRoomMemberId, ref _chatRoomMemberId, value);
      }
    }
    private Guid _chatRoomId;
    /// <summary>
    /// Gets or sets the room identifier.
    /// </summary>
    [ColumnMapper("ChatRoomId", DbType.Guid)]
    public Guid ChatRoomId {
      get {

        return _chatRoomId;
      }
      set {
        SetPropertyField<Guid>(() => ChatRoomId, ref _chatRoomId, value);
      }
    }
    private Guid _memberId;
    /// <summary>
    /// Gets or sets the member identifier.
    /// </summary>
    [ColumnMapper("MemberId", DbType.Guid)]
    public Guid MemberId {
      get {

        return _memberId;
      }
      set {
        SetPropertyField<Guid>(() => MemberId, ref _memberId, value);
      }
    }

    private bool _internal;

    /// <summary>
    /// Gets or sets the internal.
    /// </summary>
    [ColumnMapper("Internal", DbType.Boolean)]
    public bool Internal {
      get {
        return _internal;
      }
      set {
        SetPropertyField<bool>(() => Internal, ref _internal, value);
      }
    }
    private string _emailId;
    /// <summary>
    /// Gets or sets the email id.
    /// </summary>
    [ColumnMapper("EmailId", DbType.String)]
    public string EmailId {
      get {
        return _emailId;
      }
      set {
        SetPropertyField<string>(() => EmailId, ref _emailId, value);

      }
    }
    private string _name;
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [ColumnMapper("Name", DbType.String)]
    public string Name {
      get {
        return _name;
      }
      set {
        SetPropertyField<string>(() => Name, ref _name, value);

      }
    }

    #endregion Properties

    #region IValidator<ChatRoomMember> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public IEnumerable<EwpErrorData> BrokenRules(ChatRoomMember entity) {


      if (entity.ChatRoomId == Guid.Empty) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ChatRoomId",
          Message = string.Format(ServerMessages.FieldIsRequired, "ChatRoomId")
        };
      }

      if (entity.MemberId == Guid.Empty) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "MemberId",
          Message = string.Format(ServerMessages.FieldIsRequired, "MemberId")
        };
      }


      if (string.IsNullOrEmpty(entity.Name)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "Name",
          Message = string.Format(ServerMessages.FieldIsRequired, "Name")
        };
      }
    }

    /// <summary>
    /// /
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
