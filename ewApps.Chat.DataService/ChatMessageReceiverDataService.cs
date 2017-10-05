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
  /// This class implements standard business logic and operations for ChatMessageReceiver entity.
  /// </summary>
  public class ChatMessageReceiverDataService : BaseDataService<ChatMessageReceiver, Guid>, IChatMessageReceiverDataService {

    // Instance of ChatExternalUser data access interface.
    IChatMessageReceiverData _chatMessageReceiverOps = null;

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ChatMessageReceiver class.  
    /// </summary>
    public ChatMessageReceiverDataService() {
      _chatMessageReceiverOps = (IChatMessageReceiverData)ChatDataFactory.GetDataObject<ChatMessageReceiver>(ChatEntityType.ChatMessageReceiver);
      base.EntityOps = _chatMessageReceiverOps;
    }

    /// <summary>
    /// Initializes a new instance of the ChatMessageReceiver class.
    /// </summary>
    /// <param name="chatMessageReceiverOps">Instance of Employee data access layer interface.</param>
    public ChatMessageReceiverDataService(IChatMessageReceiverData chatMessageReceiverOps)
      : base(chatMessageReceiverOps) {
        _chatMessageReceiverOps = chatMessageReceiverOps;
    }


    /// <summary>
    /// Initializes a new instance of the ChatMessageReceiver class.
    /// </summary>
    /// <param name="ignoreSecurity">if set to <c>true</c> all task related security checks will be skipped.</param>
    internal ChatMessageReceiverDataService(bool ignoreSecurity) {
      _chatMessageReceiverOps = (IChatMessageReceiverData)ChatDataFactory.GetDataObject<ChatMessageReceiver>(ChatEntityType.ChatMessageReceiver);
      base.EntityOps = _chatMessageReceiverOps;
      base.IgnoreSecurity = ignoreSecurity;
    }

    #endregion Constructor
  }
}
