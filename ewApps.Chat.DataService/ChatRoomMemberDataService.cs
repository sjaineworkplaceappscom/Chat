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
  /// This class implements standard business logic and operations for ChatRoomMember entity.
  /// </summary>
  public class ChatRoomMemberDataService : BaseDataService<ChatRoomMember, Guid>, IChatRoomMemberDataService {

    // Instance of ChatRoomMember data access interface.
    IChatRoomMemberData _chatMuteSettingOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatRoomMember data class.  
    /// </summary>
    public ChatRoomMemberDataService() {
      _chatMuteSettingOps = (IChatRoomMemberData)ChatDataFactory.GetDataObject<ChatRoomMember>(ChatEntityType.ChatRoomMember);
      base.EntityOps = _chatMuteSettingOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatRoomMember data class.
    /// </summary>
    /// <param name="chatMuteSettingOps">Instance of ChatRoomMember data access layer interface.</param>
    public ChatRoomMemberDataService(IChatRoomMemberData chatMuteSettingOps)
      : base(chatMuteSettingOps) {
        _chatMuteSettingOps = chatMuteSettingOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatRoomMember class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatRoomMemberDataService(bool ignoreSecurity) {
      _chatMuteSettingOps = (IChatRoomMemberData)ChatDataFactory.GetDataObject<ChatRoomMember>(ChatEntityType.ChatRoomMember);
      base.EntityOps = _chatMuteSettingOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
