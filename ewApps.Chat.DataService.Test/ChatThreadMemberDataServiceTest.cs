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
  public class ChatThreadMemberDataServiceTest : ChatBaseDataServiceTest {

    private static IChatThreadMemberDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatThreadMemberDataService)ChatDataServiceFactory.GetDataService<ChatThreadMember>(ChatEntityType.ChatThreadMember);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatThreadMember expectedChatThreadMember = GetTestEntity();

      // Add
      Guid actualChatThreadMemberId = _dataServiceProvider.Add(expectedChatThreadMember);
      // Now get this inserted record.
      ChatThreadMember actualChatThreadMember = _dataServiceProvider.GetEntity(actualChatThreadMemberId);

      Assert.IsNotNull(actualChatThreadMember);
      Assert.AreEqual(actualChatThreadMember.ChatThreadId, expectedChatThreadMember.ChatThreadId);
      Assert.AreEqual(actualChatThreadMember.ChatThreadMemberId, expectedChatThreadMember.ChatThreadMemberId);
      Assert.AreEqual(actualChatThreadMember.ReceiverType, expectedChatThreadMember.ReceiverType);
      Assert.AreEqual(actualChatThreadMember.TenantId, expectedChatThreadMember.TenantId);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatThreadMember expectedChatThreadMember = GetTestEntity();

      // Add
      Guid newChatThreadMemberId = _dataServiceProvider.Add(expectedChatThreadMember);
      // Now get this inserted record.
      DataTable actualChatThreadMemberDT = _dataServiceProvider.GetEntityAsDT(newChatThreadMemberId);

      Assert.IsNotNull(actualChatThreadMemberDT);
      //Datatable should have only one row for expected Chat Thread Member.
      Assert.IsTrue(actualChatThreadMemberDT.Rows.Count == 1);

      //Datarow  of expected Chat Thread Member
      DataRow actualThreadMemberDataRow = actualChatThreadMemberDT.Rows[0];

      Assert.AreEqual(actualThreadMemberDataRow["ChatThreadId"].ToString(), expectedChatThreadMember.ChatThreadId.ToString());
      Assert.AreEqual(actualThreadMemberDataRow["ChatThreadMemberId"], expectedChatThreadMember.ChatThreadMemberId);
      Assert.AreEqual(actualThreadMemberDataRow["ReceiverType"].ToString(), expectedChatThreadMember.ReceiverType.ToString());
      Assert.AreEqual(actualThreadMemberDataRow["TenantId"].ToString(), expectedChatThreadMember.TenantId.ToString());
    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatThreadMember expectedChatThreadMember = GetTestEntity();

      // Add
      Guid actualChatThreadMemberId = _dataServiceProvider.Add(expectedChatThreadMember);
      // Now get this inserted record.
      ChatThreadMember actualChatThreadMember = _dataServiceProvider.GetEntity(actualChatThreadMemberId);

      Assert.IsNotNull(actualChatThreadMember);
      Assert.AreEqual(actualChatThreadMember.ChatThreadId, expectedChatThreadMember.ChatThreadId);
      Assert.AreEqual(actualChatThreadMember.ChatThreadMemberId, expectedChatThreadMember.ChatThreadMemberId);
      Assert.AreEqual(actualChatThreadMember.ReceiverType, expectedChatThreadMember.ReceiverType);
      Assert.AreEqual(actualChatThreadMember.TenantId, expectedChatThreadMember.TenantId);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatThreadMember expectedChatThreadMember = GetTestEntity();


        Guid newChatThreadMemberId = _dataServiceProvider.Add(expectedChatThreadMember);
        // Get this newly generated chat thread Member .
        ChatThreadMember newChatThreadMember = _dataServiceProvider.GetEntity(newChatThreadMemberId);
        // update some records.


        _dataServiceProvider.Update(newChatThreadMember);

        ChatThreadMember actualChatThreadMember = _dataServiceProvider.GetEntity(newChatThreadMemberId);
        Assert.IsNotNull(actualChatThreadMember);
        Assert.AreEqual(actualChatThreadMember.ChatThreadId, expectedChatThreadMember.ChatThreadId);
        Assert.AreEqual(actualChatThreadMember.ChatThreadMemberId, expectedChatThreadMember.ChatThreadMemberId);
        Assert.AreEqual(actualChatThreadMember.ReceiverType, expectedChatThreadMember.ReceiverType);
        Assert.AreEqual(actualChatThreadMember.TenantId, expectedChatThreadMember.TenantId);

      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatThreadMember chatThreadMember = GetTestEntity();


      Guid newChatThreadMemberId = _dataServiceProvider.Add(chatThreadMember);
      // Now get this record.
      ChatThreadMember expectedChatThreadMember = _dataServiceProvider.GetEntity(newChatThreadMemberId);

      Assert.IsNotNull(expectedChatThreadMember);
      Assert.AreEqual(expectedChatThreadMember.ChatThreadMemberId, newChatThreadMemberId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatThreadMember);
      // Now try to get this deleted chat thread Member  record, it should be null.
      ChatThreadMember notExpectedChatThreadMember = _dataServiceProvider.GetEntity(newChatThreadMemberId);

      //Assert actual chat thread Member should be null as it is deleted.
      Assert.IsNull(notExpectedChatThreadMember);
    }

    #endregion

    #region Private Methods

    private static ChatThreadMember GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatThreadMember chatThreadMember = new ChatThreadMember();
      chatThreadMember.TenantId = session.TenantId;
      chatThreadMember.ReceiverType = 1;//need to update this
      chatThreadMember.ChatThreadId = AddThread();

      return chatThreadMember;
    }

    private static Guid AddThread() {
      IChatThreadDataService chatThreadProvider = (IChatThreadDataService)ChatDataServiceFactory.GetDataService<ChatThread>(ChatEntityType.ChatThread);

      ChatThread chatThread = new ChatThread();
      chatThread.ThreadName = "ChatThread";
      chatThread.ThreadType = 1;//need to update this
      EwAppSession session = EwAppSessionManager.GetSession();
      chatThread.TenantId = session.TenantId;

      return chatThreadProvider.Add(chatThread);
    }

    #endregion Private Methods

  }
}
