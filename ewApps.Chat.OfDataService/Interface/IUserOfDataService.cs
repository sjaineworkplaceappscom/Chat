using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.Chat.EntityModel;

namespace ewApps.Chat.OfDataService {
  public interface IUserOfDataService {

    /// <summary>
    /// Adds the of user in Openfire server.
    /// </summary>
    /// <param name="user">The openfire user to be add.</param>
    string Add(OfUser user);

    /// <summary>
    /// Deletes the specified user name.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    void Delete(string userName);
  }
}
