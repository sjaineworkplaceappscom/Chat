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
  public class ChatMessageReceiverDataServiceTest : ChatBaseDataServiceTest {

    private static IChatMessageReceiverDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatMessageReceiverDataService)ChatDataServiceFactory.GetDataService<ChatMessageReceiver>(ChatEntityType.ChatMessageReceiver);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatMessageReceiver expectedChatMessageReceiver = GetTestEntity();
      // Add
      Guid actualChatMessageReceiverId = _dataServiceProvider.Add(expectedChatMessageReceiver);
      // Now get this inserted record.
      ChatMessageReceiver actualChatMessageReceiver = _dataServiceProvider.GetEntity(actualChatMessageReceiverId);

      Assert.IsNotNull(actualChatMessageReceiver);
      Assert.AreEqual(actualChatMessageReceiver.ChatMessageId, expectedChatMessageReceiver.ChatMessageId);
      Assert.AreEqual(actualChatMessageReceiver.ChatThreadId, expectedChatMessageReceiver.ChatThreadId);
      Assert.AreEqual(actualChatMessageReceiver.TenantId, expectedChatMessageReceiver.TenantId);
      Assert.AreEqual(actualChatMessageReceiver.ChatMessageReceiverId, expectedChatMessageReceiver.ChatMessageReceiverId);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatMessageReceiver expectedChatMessageReceiver = GetTestEntity();
      // Add
      Guid newChatMessageReceiverId = _dataServiceProvider.Add(expectedChatMessageReceiver);
      // Now get this inserted record.
      DataTable actualChatMessageReceiverDT = _dataServiceProvider.GetEntityAsDT(newChatMessageReceiverId);

      Assert.IsNotNull(actualChatMessageReceiverDT);
      //Datatable should have only one row for expected Chat Message Receiver.
      Assert.IsTrue(actualChatMessageReceiverDT.Rows.Count > 0);

      //Datarow  of expected Chat Message Receiver
      DataRow actualChatMessageReceiverDataRow = actualChatMessageReceiverDT.Rows[0];

      Assert.AreEqual(actualChatMessageReceiverDataRow["ChatMessageId"], expectedChatMessageReceiver.ChatMessageId);
      Assert.AreEqual(actualChatMessageReceiverDataRow["ChatThreadId"].ToString(), expectedChatMessageReceiver.ChatThreadId.ToString());
      Assert.AreEqual(actualChatMessageReceiverDataRow["ChatMessageReceiverId"].ToString(), expectedChatMessageReceiver.ChatMessageReceiverId.ToString());
      Assert.AreEqual(actualChatMessageReceiverDataRow["TenantId"].ToString(), expectedChatMessageReceiver.TenantId.ToString());
    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatMessageReceiver expectedChatMessageReceiver = GetTestEntity();
      // Add
      Guid actualChatMessageReceiverId = _dataServiceProvider.Add(expectedChatMessageReceiver);
      // Now get this inserted record.
      ChatMessageReceiver actualChatMessageReceiver = _dataServiceProvider.GetEntity(actualChatMessageReceiverId);

      Assert.IsNotNull(actualChatMessageReceiver);
      Assert.AreEqual(actualChatMessageReceiver.ChatMessageReceiverId, expectedChatMessageReceiver.ChatMessageReceiverId);
      Assert.AreEqual(actualChatMessageReceiver.ChatMessageId, expectedChatMessageReceiver.ChatMessageId);

      Assert.AreEqual(actualChatMessageReceiver.ChatThreadId, expectedChatMessageReceiver.ChatThreadId);
      Assert.AreEqual(actualChatMessageReceiver.TenantId, expectedChatMessageReceiver.TenantId);
      Assert.AreEqual(actualChatMessageReceiver.ChatMessageReceiverId, expectedChatMessageReceiver.ChatMessageReceiverId);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatMessageReceiver expectedChatMessageReceiver = GetTestEntity();

        Guid newChatMessageReceiverId = _dataServiceProvider.Add(expectedChatMessageReceiver);
        // Get this newly generated chat Message Receiver.
        ChatMessageReceiver newChatMessageReceiver = _dataServiceProvider.GetEntity(newChatMessageReceiverId);
        // update some records.


        _dataServiceProvider.Update(newChatMessageReceiver);

        ChatMessageReceiver actualChatMessageReceiver = _dataServiceProvider.GetEntity(newChatMessageReceiverId);

        Assert.IsNotNull(actualChatMessageReceiver);
        Assert.AreEqual(actualChatMessageReceiver.ChatMessageId, expectedChatMessageReceiver.ChatMessageId);
        Assert.AreEqual(actualChatMessageReceiver.ChatThreadId, expectedChatMessageReceiver.ChatThreadId);
        Assert.AreEqual(actualChatMessageReceiver.TenantId, expectedChatMessageReceiver.TenantId);
        Assert.AreEqual(actualChatMessageReceiver.ChatMessageReceiverId, expectedChatMessageReceiver.ChatMessageReceiverId);

      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatMessageReceiver chatMessageReceiver = GetTestEntity();

      Guid newChatMessageReceiverId = _dataServiceProvider.Add(chatMessageReceiver);
      // Now get this record.
      ChatMessageReceiver expectedChatMessageReceiver = _dataServiceProvider.GetEntity(newChatMessageReceiverId);

      Assert.IsNotNull(expectedChatMessageReceiver);
      Assert.AreEqual(expectedChatMessageReceiver.ChatMessageReceiverId, newChatMessageReceiverId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatMessageReceiver);
      // Now try to get this deleted chat Room record, it should be null.
      ChatMessageReceiver notExpectedChatMessageReceiver = _dataServiceProvider.GetEntity(newChatMessageReceiverId);

      //Assert actual chat Message Receiver should be null as it is deleted.
      Assert.IsNull(notExpectedChatMessageReceiver);
    }

    #endregion

    #region Private Methods

    private static ChatMessageReceiver GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatMessageReceiver chatMessageReceiver = new ChatMessageReceiver();
      chatMessageReceiver.TenantId = session.TenantId;
      chatMessageReceiver.ChatMessageId = AddMessage();
      chatMessageReceiver.ChatThreadId = AddThread();

      return chatMessageReceiver;
    }

    private static Guid AddMessage() {
      IChatMessageDataService chatMessageProvider = (IChatMessageDataService)ChatDataServiceFactory.GetDataService<ChatMessage>(ChatEntityType.ChatMessage);

      ChatMessage chatMessage = new ChatMessage();
      chatMessage.Message = "test message";
      chatMessage.MessageType = 1; // TODO:" Update this message type.
      chatMessage.ChatThreadId = AddThread();

      return chatMessageProvider.Add(chatMessage);
    }

    private static Guid AddThread() {

      IChatThreadDataService chatThreadProvider = (IChatThreadDataService)ChatDataServiceFactory.GetDataService<ChatThread>(ChatEntityType.ChatThread);

      ChatThread chatThread = new ChatThread();
      EwAppSession session = EwAppSessionManager.GetSession();
      chatThread.TenantId = session.TenantId;
      chatThread.ThreadName = "testchatthread";
      chatThread.ThreadType = 1; // TODO:" Update this message type.

      return chatThreadProvider.Add(chatThread);
    }
    #endregion Private Methods

  }
}
