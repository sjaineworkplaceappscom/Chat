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
  /// This class implements standard business logic and operations for ChatRoom entity.
  /// </summary>
  public class ChatRoomDataService : BaseDataService<ChatRoom, Guid>, IChatRoomDataService {

    // Instance of ChatRoom data access interface.
    IChatRoomData _chatMuteSettingOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatRoom data class.  
    /// </summary>
    public ChatRoomDataService() {
      _chatMuteSettingOps = (IChatRoomData)ChatDataFactory.GetDataObject<ChatRoom>(ChatEntityType.ChatRoom);
      base.EntityOps = _chatMuteSettingOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatRoom data class.
    /// </summary>
    /// <param name="chatMuteSettingOps">Instance of ChatRoom data access layer interface.</param>
    public ChatRoomDataService(IChatRoomData chatMuteSettingOps)
      : base(chatMuteSettingOps) {
        _chatMuteSettingOps = chatMuteSettingOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatRoom data class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatRoomDataService(bool ignoreSecurity) {
      _chatMuteSettingOps = (IChatRoomData)ChatDataFactory.GetDataObject<ChatRoom>(ChatEntityType.ChatRoom);
      base.EntityOps = _chatMuteSettingOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
