using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.Chat.Common;

namespace ewApps.Chat.OfDataService {

  public abstract class BaseOfDataService {

    protected string _baseUrl;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseOfDataService"/> class and its member variables.
    /// </summary>
    public BaseOfDataService() {
      _baseUrl = ChatConfigHelper.GetOfChatAPIBaseUrl();
    }


  }
}
