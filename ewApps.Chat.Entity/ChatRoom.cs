using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;

namespace ewApps.Chat.Entity {

  [TableMapper("ChatRoom")]
  public class ChatRoom : BaseEntity, IValidator<ChatRoom> {

    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatRoom";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatRoom() {
    }

    #endregion

    #region Properties

    private Guid _chatRoomId;

    /// <summary>
    /// ChatRoomId to uniqueally identifies the record.
    /// </summary>
    [ColumnMapper("ChatRoomId", DbType.Guid, true, false, false)]
    public Guid ChatRoomId {
      get {
        return _chatRoomId;
      }
      set {
        SetPropertyField<Guid>(() => ChatRoomId, ref _chatRoomId, value);
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

    private bool _private;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ChatRoom"/> is private.
    /// </summary>
    [ColumnMapper("Private", DbType.Boolean)]
    public bool Private {
      get {
        return _private;
      }
      set {
        SetPropertyField<bool>(() => Private, ref _private, value);
      }
    }

    private bool _archived;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ChatRoom"/> is Archived.
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

    private string _topic;
    /// <summary>
    /// Gets or sets the topic.
    /// </summary>


    [ColumnMapper("Topic", DbType.String)]
    public string Topic {
      get {
        return _topic;

      }
      set {

        SetPropertyField<string>(() => Topic, ref _topic, value);
      }
    }
    private string _greetingMessage;
    /// <summary>
    /// Gets or sets the greeting message.
    /// </summary>
    [ColumnMapper("GreetingMessage", DbType.String)]
    public string GreetingMessage {
      get {
        return _greetingMessage;
      }
      set {
        SetPropertyField<string>(() => GreetingMessage, ref _greetingMessage, value);

      }
    }
    private Guid _ownerId;
    /// <summary>
    /// Gets or sets the owner identifier.
    /// </summary>
    [ColumnMapper("OwnerId", DbType.Guid)]
    public Guid OwnerId {
      get {

        return _ownerId;
      }
      set {
        SetPropertyField<Guid>(() => OwnerId, ref _ownerId, value);
      }
    }


    #endregion Properties


    #region IValidator<ChatRoom> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public IEnumerable<EwpErrorData> BrokenRules(ChatRoom entity) {


      if (string.IsNullOrEmpty(entity.Name)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "Name",
          Message = string.Format(ServerMessages.FieldIsRequired, "Name")
        };
      }
      if (string.IsNullOrEmpty(entity.Topic)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "Topic",
          Message = string.Format(ServerMessages.FieldIsRequired, "Topic")
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
