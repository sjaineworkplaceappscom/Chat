using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ewApps.CommonRuntime;
using ewApps.CommonRuntime.DataService;
using ewApps.CommonRuntime.DataServiceTest;
using ewApps.CommonRuntime.Entity;
using ewApps.Chat.Common;
using ewApps.Chat.DataService;
using ewApps.Chat.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Transactions;
using ewApps.Chat.DataServiceTest;
using ewApps.CommonRuntime.Common;


namespace ewApps.Chat.DataService.Test {


  [TestClass]
  public class ChatRoomDataServiceTest : ChatBaseDataServiceTest {

    private static IChatRoomDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatRoomDataService)ChatDataServiceFactory.GetDataService<ChatRoom>(ChatEntityType.ChatRoom);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatRoom expectedChatRoom = GetTestEntity();
      expectedChatRoom.Name = "New ChatRoom 1";
      // Add
      Guid actualChatRoomId = _dataServiceProvider.Add(expectedChatRoom);
      // Now get this inserted record.
      ChatRoom actualChatRoom = _dataServiceProvider.GetEntity(actualChatRoomId);

      Assert.IsNotNull(actualChatRoom);
      Assert.AreEqual(actualChatRoom.ChatRoomId, expectedChatRoom.ChatRoomId);
      Assert.AreEqual(actualChatRoom.Name, expectedChatRoom.Name);
      Assert.AreEqual(actualChatRoom.Topic, expectedChatRoom.Topic);
      Assert.AreEqual(actualChatRoom.TenantId, expectedChatRoom.TenantId);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatRoom expectedChatRoom = GetTestEntity();
      // Add
      Guid newChatRoomId = _dataServiceProvider.Add(expectedChatRoom);
      // Now get this inserted record.
      DataTable actualChatRoomDT = _dataServiceProvider.GetEntityAsDT(newChatRoomId);

      Assert.IsNotNull(actualChatRoomDT);
      //Datatable should have only one row for expected Chat Room.
      Assert.IsTrue(actualChatRoomDT.Rows.Count>0);

      //Datarow  of expected Chat Room
      DataRow actualChatRoomDataRow = actualChatRoomDT.Rows[0];

      Assert.AreEqual(actualChatRoomDataRow["ChatRoomId"], expectedChatRoom.ChatRoomId);
      Assert.AreEqual(actualChatRoomDataRow["Name"].ToString(), expectedChatRoom.Name.ToString());
      Assert.AreEqual(actualChatRoomDataRow["Topic"].ToString(), expectedChatRoom.Topic.ToString());
      Assert.AreEqual(actualChatRoomDataRow["TenantId"].ToString(), expectedChatRoom.TenantId.ToString());
    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatRoom expectedChatRoom = GetTestEntity();
      // Add
      Guid actualChatRoomId = _dataServiceProvider.Add(expectedChatRoom);
      // Now get this inserted record.
      ChatRoom actualChatRoom = _dataServiceProvider.GetEntity(actualChatRoomId);

      Assert.IsNotNull(actualChatRoom);
      Assert.AreEqual(actualChatRoom.ChatRoomId, expectedChatRoom.ChatRoomId);
      Assert.AreEqual(actualChatRoom.Name, expectedChatRoom.Name);
      Assert.AreEqual(actualChatRoom.TenantId, expectedChatRoom.TenantId);
      Assert.AreEqual(actualChatRoom.Topic, expectedChatRoom.Topic);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatRoom expectedChatRoom = GetTestEntity();

        Guid newChatRoomId = _dataServiceProvider.Add(expectedChatRoom);
        // Get this newly generated chat Room.
        ChatRoom newChatRoom = _dataServiceProvider.GetEntity(newChatRoomId);
        // update some records.
        newChatRoom.Name = "Updated department 5";

        _dataServiceProvider.Update(newChatRoom);

        ChatRoom actualChatRoom = _dataServiceProvider.GetEntity(newChatRoomId);

        Assert.IsNotNull(actualChatRoom);
        Assert.AreEqual(actualChatRoom.Name,newChatRoom.Name);
        Assert.AreEqual(actualChatRoom.ChatRoomId, newChatRoom.ChatRoomId);
        Assert.AreEqual(actualChatRoom.Topic, newChatRoom.Topic);
        Assert.AreEqual(actualChatRoom.TenantId, newChatRoom.TenantId);
      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatRoom chatRoom = GetTestEntity();

      Guid newChatRoomId = _dataServiceProvider.Add(chatRoom);
      // Now get this record.
      ChatRoom expectedChatRoom = _dataServiceProvider.GetEntity(newChatRoomId);

      Assert.IsNotNull(expectedChatRoom);
      Assert.AreEqual(expectedChatRoom.ChatRoomId, newChatRoomId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatRoom);
      // Now try to get this deleted chat Room record, it should be null.
      ChatRoom notExpectedChatRoom = _dataServiceProvider.GetEntity(newChatRoomId);

      //Assert actual chat Room should be null as it is deleted.
      Assert.IsNull(notExpectedChatRoom);
    }

    #endregion

    #region Private Methods

    private static ChatRoom GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatRoom chatRoom = new ChatRoom();
      chatRoom.Name = "TestChatThread";
      chatRoom.Topic = "Topic ChatThread";
      chatRoom.TenantId = session.TenantId;

      return chatRoom;
    }

    #endregion Private Methods

  }
}
