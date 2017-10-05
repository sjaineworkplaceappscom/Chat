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
  public class ChatRoomMemberDataServiceTest : ChatBaseDataServiceTest {

    private static IChatRoomMemberDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatRoomMemberDataService)ChatDataServiceFactory.GetDataService<ChatRoomMember>(ChatEntityType.ChatRoomMember);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatRoomMember expectedChatRoomMember = GetTestEntity();
      expectedChatRoomMember.Name = "New ChatRoomMember 1";
      // Add
      Guid actualChatRoomMemberId = _dataServiceProvider.Add(expectedChatRoomMember);
      // Now get this inserted record.
      ChatRoomMember actualChatRoomMember = _dataServiceProvider.GetEntity(actualChatRoomMemberId);

      Assert.IsNotNull(actualChatRoomMember);
      Assert.AreEqual(actualChatRoomMember.ChatRoomMemberId, expectedChatRoomMember.ChatRoomMemberId);
      Assert.AreEqual(actualChatRoomMember.Name, expectedChatRoomMember.Name);
      Assert.AreEqual(actualChatRoomMember.ChatRoomId, expectedChatRoomMember.ChatRoomId);
      Assert.AreEqual(actualChatRoomMember.MemberId, expectedChatRoomMember.MemberId);
      Assert.AreEqual(actualChatRoomMember.TenantId, expectedChatRoomMember.TenantId);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatRoomMember expectedChatRoomMember = GetTestEntity();
      // Add
      Guid newChatRoomMemberId = _dataServiceProvider.Add(expectedChatRoomMember);
      // Now get this inserted record.
      DataTable actualChatRoomMemberDT = _dataServiceProvider.GetEntityAsDT(newChatRoomMemberId);

      Assert.IsNotNull(actualChatRoomMemberDT);
      //Datatable should have only one row for expected Chat Room.
      Assert.IsTrue(actualChatRoomMemberDT.Rows.Count > 0);

      //Datarow  of expected Chat Room
      DataRow actualChatRoomMemberDataRow = actualChatRoomMemberDT.Rows[0];

      Assert.AreEqual(actualChatRoomMemberDataRow["ChatRoomMemberId"], expectedChatRoomMember.ChatRoomMemberId);
      Assert.AreEqual(actualChatRoomMemberDataRow["ChatRoomId"].ToString(), expectedChatRoomMember.ChatRoomId.ToString());
      Assert.AreEqual(actualChatRoomMemberDataRow["MemberId"].ToString(), expectedChatRoomMember.MemberId.ToString());
      Assert.AreEqual(actualChatRoomMemberDataRow["TenantId"].ToString(), expectedChatRoomMember.TenantId.ToString());
      Assert.AreEqual(actualChatRoomMemberDataRow["Name"].ToString(), expectedChatRoomMember.Name.ToString());
    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatRoomMember expectedChatRoomMember = GetTestEntity();
      // Add
      Guid actualChatRoomMemberId = _dataServiceProvider.Add(expectedChatRoomMember);
      // Now get this inserted record.
      ChatRoomMember actualChatRoomMember = _dataServiceProvider.GetEntity(actualChatRoomMemberId);

      Assert.IsNotNull(actualChatRoomMember);
      Assert.IsNotNull(actualChatRoomMember);
      Assert.AreEqual(actualChatRoomMember.ChatRoomMemberId, expectedChatRoomMember.ChatRoomMemberId);
      Assert.AreEqual(actualChatRoomMember.Name, expectedChatRoomMember.Name);
      Assert.AreEqual(actualChatRoomMember.ChatRoomId, expectedChatRoomMember.ChatRoomId);
      Assert.AreEqual(actualChatRoomMember.MemberId, expectedChatRoomMember.MemberId);
      Assert.AreEqual(actualChatRoomMember.TenantId, expectedChatRoomMember.TenantId);


    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatRoomMember expectedChatRoomMember = GetTestEntity();

        Guid newChatRoomMemberId = _dataServiceProvider.Add(expectedChatRoomMember);
        // Get this newly generated chat Room Member.
        ChatRoomMember newChatRoomMember = _dataServiceProvider.GetEntity(newChatRoomMemberId);
        // update some records.
        newChatRoomMember.Name = "Updated department 5";

        _dataServiceProvider.Update(newChatRoomMember);

        ChatRoomMember actualChatRoomMember = _dataServiceProvider.GetEntity(newChatRoomMemberId);
        Assert.IsNotNull(actualChatRoomMember);
        Assert.IsNotNull(actualChatRoomMember);
        Assert.AreEqual(actualChatRoomMember.ChatRoomMemberId, newChatRoomMember.ChatRoomMemberId);
        Assert.AreEqual(actualChatRoomMember.Name, newChatRoomMember.Name);
        Assert.AreEqual(actualChatRoomMember.ChatRoomId, newChatRoomMember.ChatRoomId);
        Assert.AreEqual(actualChatRoomMember.MemberId, newChatRoomMember.MemberId);
        Assert.AreEqual(actualChatRoomMember.TenantId, newChatRoomMember.TenantId);



      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatRoomMember chatRoomMember = GetTestEntity();

      Guid newChatRoomMemberId = _dataServiceProvider.Add(chatRoomMember);
      // Now get this record.
      ChatRoomMember expectedChatRoomMember = _dataServiceProvider.GetEntity(newChatRoomMemberId);

      Assert.IsNotNull(expectedChatRoomMember);
      Assert.AreEqual(expectedChatRoomMember.ChatRoomMemberId, newChatRoomMemberId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatRoomMember);
      // Now try to get this deleted chat Room record, it should be null.
      ChatRoomMember notExpectedChatRoomMember = _dataServiceProvider.GetEntity(newChatRoomMemberId);

      //Assert actual chat Room Member should be null as it is deleted.
      Assert.IsNull(notExpectedChatRoomMember);
    }

    #endregion

    #region Private Methods

    private static ChatRoomMember GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatRoomMember chatRoomMember = new ChatRoomMember();
      chatRoomMember.Name = "TestChatRoomMember";
      chatRoomMember.TenantId = session.TenantId;
      chatRoomMember.MemberId = Guid.NewGuid();
      chatRoomMember.ChatRoomId = AddChatRoom();

      return chatRoomMember;
    }

    private static Guid AddChatRoom() {

      IChatRoomDataService chatRoomProvider = (IChatRoomDataService)ChatDataServiceFactory.GetDataService<ChatRoom>(ChatEntityType.ChatRoom);
      ChatRoom chatRoom = new ChatRoom();
      chatRoom.Name = "TestchatRoom";
      chatRoom.Topic = "TestChatRoomTopic";
      EwAppSession session = EwAppSessionManager.GetSession();
      chatRoom.TenantId = session.TenantId;

      return chatRoomProvider.Add(chatRoom);

    }
    #endregion Private Methods

  }
}

