using System;
using System.Collections.Generic;
using System.Data;
using ewApps.Chat.Entity;
using ewApps.CommonRuntime.EntityModel;
using ewApps.CommonRuntime.DataService;

namespace ewApps.Chat.DataService {

  /// <summary>
  /// Defines a methods to query ChatThreadMember entity based on different parameters.
  /// </summary>
  public interface IChatThreadMemberDataService : IBaseDataService<ChatThreadMember, Guid> {
   
  }
}
