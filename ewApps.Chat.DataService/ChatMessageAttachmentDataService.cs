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
  /// This class implements standard business logic and operations for ChatMessageAttatchment entity.
  /// </summary>
  public class ChatMessageAttachmentDataService : BaseDataService<ChatMessageAttachment, Guid>, IChatMessageAttachmentDataService {

    // Instance of ChatMessageAttatchment data access interface.
    IChatMessageAttachmentData _chatMessageAttachmentOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatMessageAttachment class.  
    /// </summary>
    public ChatMessageAttachmentDataService() {
      _chatMessageAttachmentOps = (IChatMessageAttachmentData)ChatDataFactory.GetDataObject<ChatMessageAttachment>(ChatEntityType.ChatMessageAttachment);
      base.EntityOps = _chatMessageAttachmentOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatMessageAttachment class.
    /// </summary>
    /// <param name="chatMessageAttachmentOps">Instance of ChatMessageAttatchment data access layer interface.</param>
    public ChatMessageAttachmentDataService(IChatMessageAttachmentData chatMessageAttachmentOps)
      : base(chatMessageAttachmentOps) {
        _chatMessageAttachmentOps = chatMessageAttachmentOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatMessageAttachment data class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatMessageAttachmentDataService(bool ignoreSecurity) {
      _chatMessageAttachmentOps = (IChatMessageAttachmentData)ChatDataFactory.GetDataObject<ChatMessageAttachment>(ChatEntityType.ChatMessageAttachment);
      base.EntityOps = _chatMessageAttachmentOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
