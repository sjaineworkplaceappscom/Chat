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
  /// This class implements standard business logic and operations for ChatMessage entity.
  /// </summary>
  public class ChatMessageDataService : BaseDataService<ChatMessage, Guid>, IChatMessageDataService {

    // Instance of ChatMessage data access interface.
    IChatMessageData _chatMessageOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatMessage data class.  
    /// </summary>
    public ChatMessageDataService() {
      _chatMessageOps = (IChatMessageData)ChatDataFactory.GetDataObject<ChatMessage>(ChatEntityType.ChatMessage);
      base.EntityOps = _chatMessageOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatMessage data class.
    /// </summary>
    /// <param name="chatMessageOps">Instance of ChatMessage data access layer interface.</param>
    public ChatMessageDataService(IChatMessageData chatMessageOps)
      : base(chatMessageOps) {
        _chatMessageOps = chatMessageOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatMessage data class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatMessageDataService(bool ignoreSecurity) {
      _chatMessageOps = (IChatMessageData)ChatDataFactory.GetDataObject<ChatMessage>(ChatEntityType.ChatMessage);
      base.EntityOps = _chatMessageOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
