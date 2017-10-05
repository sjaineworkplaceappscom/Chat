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
  /// This class implements standard business logic and operations for ChatMuteSetting entity.
  /// </summary>
  public class ChatMuteSettingDataService : BaseDataService<ChatMuteSetting, Guid>, IChatMuteSettingDataService {

    // Instance of ChatMuteSetting data access interface.
    IChatMuteSettingData _chatMuteSettingOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatMuteSetting data class.  
    /// </summary>
    public ChatMuteSettingDataService() {
      _chatMuteSettingOps = (IChatMuteSettingData)ChatDataFactory.GetDataObject<ChatMuteSetting>(ChatEntityType.ChatMuteSetting);
      base.EntityOps = _chatMuteSettingOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatMuteSetting class.
    /// </summary>
    /// <param name="chatMuteSettingOps">Instance of ChatMuteSetting data access layer interface.</param>
    public ChatMuteSettingDataService(IChatMuteSettingData chatMuteSettingOps)
      : base(chatMuteSettingOps) {
        _chatMuteSettingOps = chatMuteSettingOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatMuteSetting data class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatMuteSettingDataService(bool ignoreSecurity) {
      _chatMuteSettingOps = (IChatMuteSettingData)ChatDataFactory.GetDataObject<ChatMuteSetting>(ChatEntityType.ChatMuteSetting);
      base.EntityOps = _chatMuteSettingOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
