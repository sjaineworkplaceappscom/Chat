using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using System.Data;


namespace ewApps.Chat.Entity {
  [TableMapper("ChatExternalUser")]

  public class ChatExternalUser : BaseEntity, IValidator<ChatExternalUser> {
    /// <summary>
    /// Entity name as a string.
    /// </summary>
    public const string EntityName = "ChatExternalUser";

    #region Constructor

    /// <summary>
    /// Default contstructor to initialize variables (if any).
    /// </summary>
    public ChatExternalUser() {
    }

    #endregion

    #region Properties
    private Guid _chatExternalUserId;
    /// <summary>
    /// Gets or sets the chat external user identifier.
    /// </summary>
    [ColumnMapper("ChatExternalUserId", DbType.Guid, true, false, false)]
    public Guid ChatExternalUserId {
      get {

        return _chatExternalUserId;
      }
      set {
        SetPropertyField<Guid>(() => ChatExternalUserId, ref _chatExternalUserId, value);
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



    private string _email;
    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    [ColumnMapper("Email", DbType.String)]
    public string Email {
      get {

        return _email;
      }
      set {
        SetPropertyField<string>(() => Email, ref _email, value);
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

    #region IValidator<ChatExternalUser> Members

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public IEnumerable<EwpErrorData> BrokenRules(ChatExternalUser entity) {

      if (string.IsNullOrEmpty(entity.Email)) {
        yield return new EwpErrorData() {
          ErrorSubType = ErroSubType.FieldRequired,
          Data = "Email",
          Message = string.Format(ServerMessages.FieldIsRequired, "Email")
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
