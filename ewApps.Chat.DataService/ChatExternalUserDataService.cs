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
  /// This class implements standard business logic and operations for ChatExternalUser entity.
  /// </summary>
  public class ChatExternalUserDataService : BaseDataService<ChatExternalUser, Guid>, IChatExternalUserDataService {

    // Instance of ChatExternalUser data access interface.
    IChatExternalUserData _chatExternalUserOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatExternalUserData class.  
    /// </summary>
    public ChatExternalUserDataService() {
      _chatExternalUserOps = (IChatExternalUserData)ChatDataFactory.GetDataObject<ChatExternalUser>(ChatEntityType.ChatExternalUser);
      base.EntityOps = _chatExternalUserOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatExternalUserData class.
    /// </summary>
    /// <param name="chatExternalUserOps">Instance of ChatExternalUser data access layer interface.</param>
    public ChatExternalUserDataService(IChatExternalUserData chatExternalUserOps)
      : base(chatExternalUserOps) {
      _chatExternalUserOps = chatExternalUserOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatExternalUserData class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatExternalUserDataService(bool ignoreSecurity) {
      _chatExternalUserOps = (IChatExternalUserData)ChatDataFactory.GetDataObject<ChatExternalUser>(ChatEntityType.ChatExternalUser);
      base.EntityOps = _chatExternalUserOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
