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
  public class ChatThreadDataServiceTest : ChatBaseDataServiceTest {

    private static IChatThreadDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatThreadDataService)ChatDataServiceFactory.GetDataService<ChatThread>(ChatEntityType.ChatThread);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatThread expectedChatThread = GetTestEntity();
      expectedChatThread.ThreadName = "New ChatThread 1";
      // Add
      Guid actualChatThreadId = _dataServiceProvider.Add(expectedChatThread);
      // Now get this inserted record.
      ChatThread actualChatThread = _dataServiceProvider.GetEntity(actualChatThreadId);

      Assert.IsNotNull(actualChatThread);
      Assert.AreEqual(actualChatThread.ChatThreadId, expectedChatThread.ChatThreadId);
      Assert.AreEqual(actualChatThread.ThreadName, expectedChatThread.ThreadName);
      Assert.AreEqual(actualChatThread.ThreadType, expectedChatThread.ThreadType);
      Assert.AreEqual(actualChatThread.TenantId, expectedChatThread.TenantId);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatThread expectedChatThread = GetTestEntity();
      expectedChatThread.ThreadName = "New ChatThread 2";
      // Add
      Guid newChatThreadId = _dataServiceProvider.Add(expectedChatThread);
      // Now get this inserted record.
      DataTable actualChatThreadDT = _dataServiceProvider.GetEntityAsDT(newChatThreadId);

      Assert.IsNotNull(actualChatThreadDT);
      //Datatable should have only one row for expected Chat Thread.
      Assert.IsTrue(actualChatThreadDT.Rows.Count == 1);

      //Datarow  of expected Chat Thread
      DataRow actualThreadDataRow = actualChatThreadDT.Rows[0];

      Assert.AreEqual(actualThreadDataRow["ThreadName"].ToString(), expectedChatThread.ThreadName.ToString());
      Assert.AreEqual(actualThreadDataRow["ChatThreadId"], expectedChatThread.ChatThreadId);
      Assert.AreEqual(actualThreadDataRow["ThreadType"].ToString(), expectedChatThread.ThreadType.ToString());
      Assert.AreEqual(actualThreadDataRow["TenantId"].ToString(), expectedChatThread.TenantId.ToString());
    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatThread expectedChatThread = GetTestEntity();
      expectedChatThread.ThreadName = "New ChatThread 1";
      // Add
      Guid actualChatThreadId = _dataServiceProvider.Add(expectedChatThread);
      // Now get this inserted record.
      ChatThread actualChatThread = _dataServiceProvider.GetEntity(actualChatThreadId);

      Assert.IsNotNull(actualChatThread);
      Assert.AreEqual(actualChatThread.ChatThreadId, expectedChatThread.ChatThreadId);
      Assert.AreEqual(actualChatThread.ThreadName, expectedChatThread.ThreadName);
      Assert.AreEqual(actualChatThread.TenantId, expectedChatThread.TenantId);
      Assert.AreEqual(actualChatThread.ThreadType, expectedChatThread.ThreadType);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatThread expectedChatThread = GetTestEntity();
        expectedChatThread.ThreadName = "New ChatThread 5";

        Guid newChatThreadId = _dataServiceProvider.Add(expectedChatThread);
        // Get this newly generated chat thread.
        ChatThread newChatThread = _dataServiceProvider.GetEntity(newChatThreadId);
        // update some records.
        newChatThread.ThreadName = "Updated department 5";

        _dataServiceProvider.Update(newChatThread);

        ChatThread actualChatThread = _dataServiceProvider.GetEntity(newChatThreadId);

        Assert.IsNotNull(actualChatThread);
        Assert.AreEqual(actualChatThread.ThreadName, newChatThread.ThreadName);
        Assert.AreEqual(actualChatThread.ChatThreadId, newChatThread.ChatThreadId);
        Assert.AreEqual(actualChatThread.ThreadType, newChatThread.ThreadType);
        Assert.AreEqual(actualChatThread.TenantId, newChatThread.TenantId);
      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatThread chatThread =GetTestEntity();
      chatThread.ThreadName = "New ChatThread 5";

      Guid newChatThreadId = _dataServiceProvider.Add(chatThread);
      // Now get this record.
      ChatThread expectedChatThread = _dataServiceProvider.GetEntity(newChatThreadId);

      Assert.IsNotNull(expectedChatThread);
      Assert.AreEqual(expectedChatThread.ChatThreadId, newChatThreadId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatThread);
      // Now try to get this deleted chat thread record, it should be null.
      ChatThread notExpectedChatThread = _dataServiceProvider.GetEntity(newChatThreadId);

      //Assert actual chat thread should be null as it is deleted.
      Assert.IsNull(notExpectedChatThread);
    }

    #endregion

    #region Private Methods

    private static ChatThread GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatThread chatThread = new ChatThread();
      chatThread.ThreadName = "TestChatThread";
      chatThread.TenantId = session.TenantId;
      chatThread.ThreadType = 1;//need to update this

      return chatThread;
    }

    #endregion Private Methods

  }
}
