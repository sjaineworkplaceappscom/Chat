using System;
using System.Collections.Generic;
using ewApps.CommonRuntime.Data;
using System.Data;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;
using ewApps.Chat.Entity;

namespace ewApps.Chat.Data {

  /// <summary>
  /// Chat message attachment data interface.
  /// </summary>
  public interface IChatMessageAttachmentData : IBaseData<ChatMessageAttachment, Guid> {

  }
}
