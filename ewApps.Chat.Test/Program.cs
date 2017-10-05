using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.Chat.OfDataService;

namespace ewApps.Chat.Test {
  class Program {
    static void Main(string[] args) {
      new UserOfDataService().Add(new EntityModel.OfUser() {
        email = "njain@eworkplaceapps.com",
        name = "nitin jain",
        password = "Password@123",
        username = "NitinJain"
      });

 // + 
// external user psuedo chat user jabber user


      new RoomOfDataService().Add(new EntityModel.OfRoom() {
        roomName = "DSTestRoom",
        naturalName = "DSTestRoom",
        maxUsers = "unlimited",
        logEnabled = true,
        description = "DSTestRoom"
      });

    
      new RoomMemberOfDataService().Add(new EntityModel.OfRoomMember() {
        MemberName = "njain@eworkplaceapps.com",
        RoomName = "DSTestRoom"
      });
    }
  }
}
