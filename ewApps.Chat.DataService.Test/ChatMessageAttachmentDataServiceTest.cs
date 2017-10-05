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
  public class ChatMessageAttachmentDataServiceTest : ChatBaseDataServiceTest {

    private static IChatMessageAttachmentDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatMessageAttachmentDataService)ChatDataServiceFactory.GetDataService<ChatMessageAttachment>(ChatEntityType.ChatMessageAttachment);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatMessageAttachment expectedChatMessageAttachment = GetTestEntity();
      // Add
      Guid actualChatMessageAttachmentId = _dataServiceProvider.Add(expectedChatMessageAttachment);
      // Now get this inserted record.
      ChatMessageAttachment actualChatMessageAttachment = _dataServiceProvider.GetEntity(actualChatMessageAttachmentId);

      Assert.IsNotNull(actualChatMessageAttachment);
      Assert.AreEqual(actualChatMessageAttachment.ChatMessageId, expectedChatMessageAttachment.ChatMessageId);
      Assert.AreEqual(actualChatMessageAttachment.ChatThreadId, expectedChatMessageAttachment.ChatThreadId);
      Assert.AreEqual(actualChatMessageAttachment.TenantId, expectedChatMessageAttachment.TenantId);
      Assert.AreEqual(actualChatMessageAttachment.ChatMessageAttachmentId, expectedChatMessageAttachment.ChatMessageAttachmentId);
      Assert.AreEqual(actualChatMessageAttachment.AttachmentStream, expectedChatMessageAttachment.AttachmentStream);
      Assert.AreEqual(actualChatMessageAttachment.Thumbnail, expectedChatMessageAttachment.Thumbnail);
      Assert.AreEqual(actualChatMessageAttachment.FileName, expectedChatMessageAttachment.FileName);
      Assert.AreEqual(actualChatMessageAttachment.FileExtension, expectedChatMessageAttachment.FileExtension);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatMessageAttachment expectedChatMessageAttachment = GetTestEntity();
      // Add
      Guid newChatMessageAttachmentId = _dataServiceProvider.Add(expectedChatMessageAttachment);
      // Now get this inserted record.
      DataTable actualChatMessageAttachmentDT = _dataServiceProvider.GetEntityAsDT(newChatMessageAttachmentId);

      Assert.IsNotNull(actualChatMessageAttachmentDT);
      //Datatable should have only one row for expected Chat External User.
      Assert.IsTrue(actualChatMessageAttachmentDT.Rows.Count > 0);

      //Datarow  of expected Chat External User
      DataRow actualChatMessageAttachmentDataRow = actualChatMessageAttachmentDT.Rows[0];

      Assert.AreEqual(actualChatMessageAttachmentDataRow["ChatMessageId"], expectedChatMessageAttachment.ChatMessageId);
      Assert.AreEqual(actualChatMessageAttachmentDataRow["ChatThreadId"].ToString(), expectedChatMessageAttachment.ChatThreadId.ToString());
      Assert.AreEqual(actualChatMessageAttachmentDataRow["ChatMessageAttachmentId"].ToString(), expectedChatMessageAttachment.ChatMessageAttachmentId.ToString());
      Assert.AreEqual(actualChatMessageAttachmentDataRow["TenantId"].ToString(), expectedChatMessageAttachment.TenantId.ToString());
      Assert.AreEqual(actualChatMessageAttachmentDataRow["FileName"], expectedChatMessageAttachment.FileName.ToString());
      Assert.AreEqual(actualChatMessageAttachmentDataRow["FileExtension"].ToString(), expectedChatMessageAttachment.FileExtension.ToString());
      Assert.AreEqual(actualChatMessageAttachmentDataRow["AttachmentStream"].ToString(), expectedChatMessageAttachment.AttachmentStream.ToString());
      Assert.AreEqual(actualChatMessageAttachmentDataRow["Thumbnail"].ToString(), expectedChatMessageAttachment.Thumbnail.ToString());

    }


    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatMessageAttachment expectedChatMessageAttachment = GetTestEntity();
      // Add
      Guid actualChatMessageAttachmentId = _dataServiceProvider.Add(expectedChatMessageAttachment);
      // Now get this inserted record.
      ChatMessageAttachment actualChatMessageAttachment = _dataServiceProvider.GetEntity(actualChatMessageAttachmentId);

      Assert.IsNotNull(actualChatMessageAttachment);
      Assert.AreEqual(actualChatMessageAttachment.ChatMessageId, expectedChatMessageAttachment.ChatMessageId);
      Assert.AreEqual(actualChatMessageAttachment.ChatThreadId, expectedChatMessageAttachment.ChatThreadId);
      Assert.AreEqual(actualChatMessageAttachment.TenantId, expectedChatMessageAttachment.TenantId);
      Assert.AreEqual(actualChatMessageAttachment.ChatMessageAttachmentId, expectedChatMessageAttachment.ChatMessageAttachmentId);
      Assert.AreEqual(actualChatMessageAttachment.AttachmentStream, expectedChatMessageAttachment.AttachmentStream);
      Assert.AreEqual(actualChatMessageAttachment.Thumbnail, expectedChatMessageAttachment.Thumbnail);
      Assert.AreEqual(actualChatMessageAttachment.FileName, expectedChatMessageAttachment.FileName);
      Assert.AreEqual(actualChatMessageAttachment.FileExtension, expectedChatMessageAttachment.FileExtension);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatMessageAttachment expectedChatMessageAttachment = GetTestEntity();

        Guid newChatMessageAttachmentId = _dataServiceProvider.Add(expectedChatMessageAttachment);
        // Get this newly generated chat External User.
        ChatMessageAttachment newChatMessageAttachment = _dataServiceProvider.GetEntity(newChatMessageAttachmentId);
        // update some records.


        _dataServiceProvider.Update(newChatMessageAttachment);

        ChatMessageAttachment actualChatMessageAttachment = _dataServiceProvider.GetEntity(newChatMessageAttachmentId);
        Assert.IsNotNull(actualChatMessageAttachment);
        Assert.AreEqual(actualChatMessageAttachment.ChatMessageId, expectedChatMessageAttachment.ChatMessageId);
        Assert.AreEqual(actualChatMessageAttachment.ChatThreadId, expectedChatMessageAttachment.ChatThreadId);
        Assert.AreEqual(actualChatMessageAttachment.TenantId, expectedChatMessageAttachment.TenantId);
        Assert.AreEqual(actualChatMessageAttachment.ChatMessageAttachmentId, expectedChatMessageAttachment.ChatMessageAttachmentId);
        Assert.AreEqual(actualChatMessageAttachment.AttachmentStream, expectedChatMessageAttachment.AttachmentStream);
        Assert.AreEqual(actualChatMessageAttachment.Thumbnail, expectedChatMessageAttachment.Thumbnail);
        Assert.AreEqual(actualChatMessageAttachment.FileName, expectedChatMessageAttachment.FileName);
        Assert.AreEqual(actualChatMessageAttachment.FileExtension, expectedChatMessageAttachment.FileExtension);

      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      using (TransactionScope scope =CreateTransaction()) {

        // First add a record and then delete it.
        ChatMessageAttachment department = GetTestEntity();

        Guid newChatMessageAttachmentId = _dataServiceProvider.Add(department);
        // Now get this record.
        ChatMessageAttachment expectedChatMessageAttachment = _dataServiceProvider.GetEntity(newChatMessageAttachmentId);

        Assert.IsNotNull(expectedChatMessageAttachment);
        Assert.AreEqual(expectedChatMessageAttachment.ChatMessageAttachmentId, newChatMessageAttachmentId);

        // Now delete the same record.
        _dataServiceProvider.Delete(expectedChatMessageAttachment);
        // Now try to get this deleted chatExternal User record, it should be null.
        ChatMessageAttachment notExpectedChatMessageAttachment = _dataServiceProvider.GetEntity(newChatMessageAttachmentId);

        //Assert actual chat External User should be null as it is deleted.
        Assert.IsNull(notExpectedChatMessageAttachment); 
      }
    }

    #endregion

    #region Private Methods

    private static ChatMessageAttachment GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatMessageAttachment chatMessageAttachment = new ChatMessageAttachment();
      chatMessageAttachment.TenantId = session.TenantId;
      chatMessageAttachment.ChatMessageId = AddMessage();
      chatMessageAttachment.ChatThreadId = AddThread();
      chatMessageAttachment.AttachmentStream = "test AttachmentStream";
      chatMessageAttachment.Thumbnail = "test Thumbnail";
      chatMessageAttachment.FileExtension = "txt";
      chatMessageAttachment.FileName = "test File Name";

      return chatMessageAttachment;
    }

    //Add a general Message Record
    private static Guid AddMessage() {
      IChatMessageDataService chatMessageProvider = (IChatMessageDataService)ChatDataServiceFactory.GetDataService<ChatMessage>(ChatEntityType.ChatMessage);

      ChatMessage chatMessage = new ChatMessage();
      chatMessage.MessageType = 1;
      chatMessage.ChatThreadId = AddThread();
      EwAppSession session = EwAppSessionManager.GetSession();
      chatMessage.TenantId = session.TenantId;
      return chatMessageProvider.Add(chatMessage);
    }

    // Adds a general thread record.
    private static Guid AddThread() {
      IChatThreadDataService chatThreadProvider = (IChatThreadDataService)ChatDataServiceFactory.GetDataService<ChatThread>(ChatEntityType.ChatThread);

      ChatThread chatThread = new ChatThread();
      EwAppSession session = EwAppSessionManager.GetSession();
      chatThread.TenantId = session.TenantId;
      chatThread.ThreadName = "ChatThread";
      chatThread.ThreadType = 1;//need to update this

      return chatThreadProvider.Add(chatThread);
    }

    #endregion Private Methods

  }
}
