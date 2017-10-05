using System;
using System.Collections.Generic;
using System.Data;
using ewApps.Chat.Entity;
using ewApps.CommonRuntime.EntityModel;
using ewApps.CommonRuntime.DataService;

namespace ewApps.Chat.DataService {

  /// <summary>
  /// Defines a methods to query ChatThread entity based on different parameters.
  /// </summary>
  public interface IChatThreadDataService : IBaseDataService<ChatThread, Guid> {
   
  }
}
