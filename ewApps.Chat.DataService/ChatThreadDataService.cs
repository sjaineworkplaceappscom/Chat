//===============================================================================
// © 2015 eWorkplace Apps.  All rights reserved.
// Original Author: Shashank Jain 
// Original Date: 19 June 15
//===============================================================================

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
  /// This class implements standard business logic and operations for ChatThread entity.
  /// </summary>
  public class ChatThreadDataService : BaseDataService<ChatThread, Guid>, IChatThreadDataService {

    // Instance of ChatThread data access interface.
    IChatThreadData _chatMuteSettingOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatThread data class.  
    /// </summary>
    public ChatThreadDataService() {
      _chatMuteSettingOps = (IChatThreadData)ChatDataFactory.GetDataObject<ChatThread>(ChatEntityType.ChatThread);
      base.EntityOps = _chatMuteSettingOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatThread data class.
    /// </summary>
    /// <param name="chatMuteSettingOps">Instance of ChatThread data access layer interface.</param>
    public ChatThreadDataService(IChatThreadData chatMuteSettingOps)
      : base(chatMuteSettingOps) {
        _chatMuteSettingOps = chatMuteSettingOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatThread data class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatThreadDataService(bool ignoreSecurity) {
      _chatMuteSettingOps = (IChatThreadData)ChatDataFactory.GetDataObject<ChatThread>(ChatEntityType.ChatThread);
      base.EntityOps = _chatMuteSettingOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
