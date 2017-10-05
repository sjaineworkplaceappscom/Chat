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
  public class ChatMessageDataServiceTest : ChatBaseDataServiceTest {

    private static IChatMessageDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatMessageDataService)ChatDataServiceFactory.GetDataService<ChatMessage>(ChatEntityType.ChatMessage);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatMessage expectedChatMessage = GetTestEntity();
      // Add
      Guid actualChatMessageId = _dataServiceProvider.Add(expectedChatMessage);
      // Now get this inserted record.
      ChatMessage actualChatMessage = _dataServiceProvider.GetEntity(actualChatMessageId);

      Assert.IsNotNull(actualChatMessage);
      Assert.AreEqual(actualChatMessage.ChatMessageId, expectedChatMessage.ChatMessageId);
      Assert.AreEqual(actualChatMessage.ChatThreadId, expectedChatMessage.ChatThreadId);
      Assert.AreEqual(actualChatMessage.TenantId, expectedChatMessage.TenantId);
      Assert.AreEqual(actualChatMessage.MessageType, expectedChatMessage.MessageType);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatMessage expectedChatMessage = GetTestEntity();
      // Add
      Guid newChatMessageId = _dataServiceProvider.Add(expectedChatMessage);
      // Now get this inserted record.
      DataTable actualChatMessageDT = _dataServiceProvider.GetEntityAsDT(newChatMessageId);

      Assert.IsNotNull(actualChatMessageDT);
      //Datatable should have only one row for expected Chat Message.
      Assert.IsTrue(actualChatMessageDT.Rows.Count > 0);

      //Datarow  of expected Chat Message
      DataRow actualChatMessageDataRow = actualChatMessageDT.Rows[0];

      Assert.AreEqual(actualChatMessageDataRow["ChatMessageId"], expectedChatMessage.ChatMessageId);
      Assert.AreEqual(actualChatMessageDataRow["ChatThreadId"].ToString(), expectedChatMessage.ChatThreadId.ToString());
      Assert.AreEqual(actualChatMessageDataRow["MessageType"].ToString(), expectedChatMessage.MessageType.ToString());
      Assert.AreEqual(actualChatMessageDataRow["TenantId"].ToString(), expectedChatMessage.TenantId.ToString());
    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatMessage expectedChatMessage = GetTestEntity();
      // Add
      Guid actualChatMessageId = _dataServiceProvider.Add(expectedChatMessage);
      // Now get this inserted record.
      ChatMessage actualChatMessage = _dataServiceProvider.GetEntity(actualChatMessageId);

      Assert.IsNotNull(actualChatMessage);
      Assert.AreEqual(actualChatMessage.ChatMessageId, expectedChatMessage.ChatMessageId);
      Assert.AreEqual(actualChatMessage.ChatThreadId, expectedChatMessage.ChatThreadId);
      Assert.AreEqual(actualChatMessage.TenantId, expectedChatMessage.TenantId);
      Assert.AreEqual(actualChatMessage.MessageType, expectedChatMessage.MessageType);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatMessage expectedChatMessage = GetTestEntity();

        Guid newChatMessageId = _dataServiceProvider.Add(expectedChatMessage);
        // Get this newly generated chat Message.
        ChatMessage newChatMessage = _dataServiceProvider.GetEntity(newChatMessageId);
        // update some records.


        _dataServiceProvider.Update(newChatMessage);

        ChatMessage actualChatMessage = _dataServiceProvider.GetEntity(newChatMessageId);

        Assert.IsNotNull(actualChatMessage);
        Assert.AreEqual(actualChatMessage.ChatMessageId, expectedChatMessage.ChatMessageId);
        Assert.AreEqual(actualChatMessage.ChatThreadId, expectedChatMessage.ChatThreadId);
        Assert.AreEqual(actualChatMessage.TenantId, expectedChatMessage.TenantId);
        Assert.AreEqual(actualChatMessage.MessageType, expectedChatMessage.MessageType);

      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatMessage chatMessage = GetTestEntity();

      Guid newChatMessageId = _dataServiceProvider.Add(chatMessage);
      // Now get this record.
      ChatMessage expectedChatMessage = _dataServiceProvider.GetEntity(newChatMessageId);

      Assert.IsNotNull(expectedChatMessage);
      Assert.AreEqual(expectedChatMessage.ChatMessageId, newChatMessageId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatMessage);
      // Now try to get this deleted chat Message record, it should be null.
      ChatMessage notExpectedChatMessage = _dataServiceProvider.GetEntity(newChatMessageId);

      //Assert actual chat Message should be null as it is deleted.
      Assert.IsNull(notExpectedChatMessage);
    }

    #endregion

    #region Private Methods

    private static ChatMessage GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatMessage chatMessage = new ChatMessage();
      chatMessage.TenantId = session.TenantId;
      chatMessage.MessageType = 1;//need to update this
      chatMessage.ChatThreadId = AddThread();

      return chatMessage;
    }

    private static Guid AddThread() {
      IChatThreadDataService chatThreadProvider = (IChatThreadDataService)ChatDataServiceFactory.GetDataService<ChatThread>(ChatEntityType.ChatThread);

      ChatThread chatThread = new ChatThread();
      EwAppSession session = EwAppSessionManager.GetSession();
      chatThread.TenantId = session.TenantId;
      chatThread.ThreadType = 1;//update this
      chatThread.ThreadName = "ChatThread";

      return chatThreadProvider.Add(chatThread);
    }
    #endregion Private Methods

  }
}
