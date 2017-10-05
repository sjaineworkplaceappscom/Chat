using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;


namespace ewApps.Chat.Entity {

  [TableMapper("ChatMuteSetting")]
  public class ChatMuteSetting : BaseEntity, IValidator<ChatMuteSetting> {
    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatMuteSetting";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatMuteSetting() {
    }

    #endregion

    #region Properties
    private Guid _userId;
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    [ColumnMapper("UserId", DbType.Guid, true, false, false)]
    public Guid UserId {
      get {

        return _userId;
      }
      set {
        SetPropertyField<Guid>(() => UserId, ref _userId, value);
      }
    }
    private Guid _chatThreadId;
    /// <summary>
    /// Gets or sets the thread identifier.
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

    private DateTime _fromDate;
    /// <summary>
    /// Gets or sets the from date.
    /// </summary>
    [ColumnMapper("FromDate", DbType.DateTime2)]
    public DateTime FromDate {
      get {
        return _fromDate;
      }
      set {
        SetPropertyField<DateTime>(() => FromDate, ref _fromDate, value);
      }
    }
    private DateTime _toDate;
    /// <summary>
    /// Gets or sets the to date.
    /// </summary>
    [ColumnMapper("ToDate", DbType.DateTime2)]
    public DateTime ToDate {
      get {
        return _toDate;
      }
      set {
        SetPropertyField<DateTime>(() => ToDate, ref _toDate, value);
      }
    }

    private bool _mute;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ChatRoom"/> is private.
    /// </summary>
    [ColumnMapper("Mute", DbType.Boolean)]
    public bool Mute {
      get {
        return _mute;
      }
      set {
        SetPropertyField<bool>(() => Mute, ref _mute, value);
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
    public override Guid? TenantId {
      get;
      set ;
    }
  
    #endregion Properties



    #region IValidator<ChatMuteSetting> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public IEnumerable<EwpErrorData> BrokenRules(ChatMuteSetting entity) {

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
