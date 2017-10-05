using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;
namespace ewApps.Chat.Entity {
  [TableMapper("ChatThread")]
  public class ChatThread : BaseEntity, IValidator<ChatThread> {
    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatThread";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatThread() {
    }

    #endregion

    #region Properties
    private Guid _chatThreadId;
    /// <summary>
    /// Gets or sets the ChatThreadId
    /// </summary>
    [ColumnMapper("ChatThreadId", DbType.Guid, true, false, false)]
    public Guid ChatThreadId {
      get {

        return _chatThreadId;
      }
      set {
        SetPropertyField<Guid>(() => ChatThreadId, ref _chatThreadId, value);
      }
    }


    private string _threadName;
    /// <summary>
    /// Gets or sets the ThreadName
    /// </summary>
    [ColumnMapper("ThreadName", DbType.String)]
    public string ThreadName {
      get {
        return _threadName;
      }
      set {
        SetPropertyField<string>(() => ThreadName, ref _threadName, value);

      }
    }

    private int _threadType;
    /// <summary>
    /// Gets or sets the ThreadType.
    /// </summary>
    [ColumnMapper("ThreadType", DbType.Int32)]
    public int ThreadType {
      get {

        return _threadType;
      }
      set {
        SetPropertyField<Int32>(() => ThreadType, ref _threadType, value);
      }
    }
    private bool _archived;

    /// <summary>
    /// Gets or sets the Archived.
    /// </summary>
    [ColumnMapper("Archived", DbType.Boolean)]
    public bool Archived {
      get {
        return _archived;
      }
      set {
        SetPropertyField<bool>(() => Archived, ref _archived, value);
      }
    }
    #endregion Properties

    #region IValidator<ChatThread> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="brokenRules"></param>
    /// <returns></returns>
    public bool Validate(out IList<EwpErrorData> brokenRules) {
      brokenRules = BrokenRules(this).ToList<EwpErrorData>();
      return brokenRules.Count > 0;
    }
    /// <summary>
    /// /
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>

    public IEnumerable<EwpErrorData> BrokenRules(ChatThread entity) {



      if (string.IsNullOrEmpty(entity.ThreadName)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ThreadName",
          Message = string.Format(ServerMessages.FieldIsRequired, "ThreadName")
        };
      }

      if (entity.ThreadType <= 0) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "ThreadType",
          Message = string.Format(ServerMessages.FieldIsRequired, "ThreadType")
        };
      }
    }

    #endregion

  }
}
