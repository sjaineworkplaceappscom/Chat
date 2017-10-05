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
  public class ChatMuteSettingDataServiceTest : ChatBaseDataServiceTest {

    private static IChatMuteSettingDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatMuteSettingDataService)ChatDataServiceFactory.GetDataService<ChatMuteSetting>(ChatEntityType.ChatMuteSetting);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatMuteSetting expectedChatMuteSetting = GetTestEntity();

      // Add
      Guid actualUserId = _dataServiceProvider.Add(expectedChatMuteSetting);
      // Now get this inserted record.
      ChatMuteSetting actualChatMuteSetting = _dataServiceProvider.GetEntity(actualUserId);

      Assert.IsNotNull(actualChatMuteSetting);
      Assert.AreEqual(actualChatMuteSetting.UserId, expectedChatMuteSetting.UserId);
      Assert.AreEqual(actualChatMuteSetting.ChatThreadId, expectedChatMuteSetting.ChatThreadId);


    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatMuteSetting expectedChatMuteSetting = GetTestEntity();

      // Add
      Guid newUserId = _dataServiceProvider.Add(expectedChatMuteSetting);
      // Now get this inserted record.
      DataTable actualChatMuteSettingDT = _dataServiceProvider.GetEntityAsDT(newUserId);

      Assert.IsNotNull(actualChatMuteSettingDT);
      //Datatable should have only one row for expected Chat Mute Setting.
      Assert.IsTrue(actualChatMuteSettingDT.Rows.Count == 1);

      //Datarow  of expected Chat Mute Setting
      DataRow actualThreadDataRow = actualChatMuteSettingDT.Rows[0];

      Assert.AreEqual(actualThreadDataRow["UserId"], expectedChatMuteSetting.UserId);
      Assert.AreEqual(actualThreadDataRow["ChatThreadId"].ToString(), expectedChatMuteSetting.ChatThreadId.ToString());

    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatMuteSetting expectedChatMuteSetting = GetTestEntity();

      // Add
      Guid actualUserId = _dataServiceProvider.Add(expectedChatMuteSetting);
      // Now get this inserted record.
      ChatMuteSetting actualChatMuteSetting = _dataServiceProvider.GetEntity(actualUserId);

      Assert.IsNotNull(actualChatMuteSetting);
      Assert.AreEqual(actualChatMuteSetting.UserId, expectedChatMuteSetting.UserId);
      Assert.AreEqual(actualChatMuteSetting.ChatThreadId, expectedChatMuteSetting.ChatThreadId);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatMuteSetting expectedChatMuteSetting = GetTestEntity();


        Guid newUserId = _dataServiceProvider.Add(expectedChatMuteSetting);
        // Get this newly generated chat Mute Setting.
        ChatMuteSetting newChatMuteSetting = _dataServiceProvider.GetEntity(newUserId);
        // update some records.


        _dataServiceProvider.Update(newChatMuteSetting);

        ChatMuteSetting actualChatMuteSetting = _dataServiceProvider.GetEntity(newUserId);
        Assert.IsNotNull(actualChatMuteSetting);
        Assert.AreEqual(actualChatMuteSetting.UserId, newChatMuteSetting.UserId);
        Assert.AreEqual(actualChatMuteSetting.ChatThreadId, newChatMuteSetting.ChatThreadId);


      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatMuteSetting chatMuteSetting = GetTestEntity();


      Guid newUserId = _dataServiceProvider.Add(chatMuteSetting);
      // Now get this record.
      ChatMuteSetting expectedChatMuteSetting = _dataServiceProvider.GetEntity(newUserId);

      Assert.IsNotNull(expectedChatMuteSetting);
      Assert.AreEqual(expectedChatMuteSetting.UserId, newUserId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatMuteSetting);
      // Now try to get this deleted chat Mute Setting record, it should be null.
      ChatMuteSetting notExpectedChatMuteSetting = _dataServiceProvider.GetEntity(newUserId);

      //Assert actual chat Mute Setting  should be null as it is deleted.
      Assert.IsNull(notExpectedChatMuteSetting);
    }

    #endregion

    #region Private Methods

    private static ChatMuteSetting GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatMuteSetting chatMuteSetting = new ChatMuteSetting();
      chatMuteSetting.UserId = Guid.NewGuid();//need to update this must contain user id 
      chatMuteSetting.TenantId = session.TenantId;
      chatMuteSetting.ChatThreadId = AddThread();

      return chatMuteSetting;
    }
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
