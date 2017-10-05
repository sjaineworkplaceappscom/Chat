using ewApps.CommonRuntime.EntityModel;
using ewApps.CommonRuntime.Common;
using ewApps.CommonRuntime.DataService;
using ewApps.CommonRuntime.Entity;
using ewApps.Chat.Common;
using ewApps.Chat.Data;
using ewApps.Chat.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ewApps.CommonRuntime.EntityModel;

namespace ewApps.Chat.DataService {

  /// <summary>
  /// This class implements standard business logic and operations for ChatThreadMember entity.
  /// </summary>
  public class ChatThreadMemberDataService : BaseDataService<ChatThreadMember, Guid>, IChatThreadMemberDataService {

    // Instance of ChatThreadMember data access interface.
    IChatThreadMemberData _chatMuteSettingOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatThreadMember data class.  
    /// </summary>
    public ChatThreadMemberDataService() {
      _chatMuteSettingOps = (IChatThreadMemberData)ChatDataFactory.GetDataObject<ChatThreadMember>(ChatEntityType.ChatThreadMember);
      base.EntityOps = _chatMuteSettingOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatThreadMember data class.
    /// </summary>
    /// <param name="chatMuteSettingOps">Instance of ChatThreadMember data access layer interface.</param>
    public ChatThreadMemberDataService(IChatThreadMemberData chatMuteSettingOps)
      : base(chatMuteSettingOps) {
        _chatMuteSettingOps = chatMuteSettingOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatThreadMember data class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatThreadMemberDataService(bool ignoreSecurity) {
      _chatMuteSettingOps = (IChatThreadMemberData)ChatDataFactory.GetDataObject<ChatThreadMember>(ChatEntityType.ChatThreadMember);
      base.EntityOps = _chatMuteSettingOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
