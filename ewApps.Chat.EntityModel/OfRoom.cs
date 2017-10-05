using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ewApps.Chat.EntityModel {

  public class OfRoom {

    public string naturalName {
      get;
      set;
    }
    public string roomName {
      get;
      set;
    }
    public string description {
      get;
      set;
    }
    public bool logEnabled {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the maximum users.
    /// default value is 'unlimited'
    /// </summary>
    /// <value>
    /// The maximum users.
    /// </value>
    public string maxUsers {
      get;
      set;
    }

  }
}
