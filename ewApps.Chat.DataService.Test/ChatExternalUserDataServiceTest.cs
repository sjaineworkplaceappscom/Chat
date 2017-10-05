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
  public class ChatExternalUserDataServiceTest : ChatBaseDataServiceTest {

    private static IChatExternalUserDataService _dataServiceProvider;

    #region Additional test attributes

    // It executes before running the first test in the class and initialize the class member.
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext) {
      _dataServiceProvider = (IChatExternalUserDataService)ChatDataServiceFactory.GetDataService<ChatExternalUser>(ChatEntityType.ChatExternalUser);
    }

    #endregion Additional test

    #region Get Methods

    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void GetEntity_Test() {
      // First add a record and then get it.
      ChatExternalUser expectedChatExternalUser = GetTestEntity();

      // Add
      Guid actualChatExternalUserId = _dataServiceProvider.Add(expectedChatExternalUser);
      // Now get this inserted record.
      ChatExternalUser actualChatExternalUser = _dataServiceProvider.GetEntity(actualChatExternalUserId);

      Assert.IsNotNull(actualChatExternalUser);
      Assert.AreEqual(actualChatExternalUser.ChatExternalUserId, expectedChatExternalUser.ChatExternalUserId);
      Assert.AreEqual(actualChatExternalUser.Email, expectedChatExternalUser.Email);
      Assert.AreEqual(actualChatExternalUser.TenantId, expectedChatExternalUser.TenantId);

    }

    //A test method for test GetEntityAsDT. 
    [TestMethod]
    [TestCategory(TestCategory.GetOperation)]
    [TestProperty("Author", "ShashankJain, 22 May 2015")]
    public void GetEntityAsDT_Test() {
      // First add a record and then get it.
      ChatExternalUser expectedChatExternalUser = GetTestEntity();

      // Add
      Guid newChatExternalUserId = _dataServiceProvider.Add(expectedChatExternalUser);
      // Now get this inserted record.
      DataTable actualChatExternalUserDT = _dataServiceProvider.GetEntityAsDT(newChatExternalUserId);

      Assert.IsNotNull(actualChatExternalUserDT);
      //Datatable should have only one row for expected External User Data.
      Assert.IsTrue(actualChatExternalUserDT.Rows.Count == 1);

      //Datarow  of expected Chat External User Data
      DataRow actualExternalUserDataRow = actualChatExternalUserDT.Rows[0];

      Assert.AreEqual(actualExternalUserDataRow["ChatExternalUserId"], expectedChatExternalUser.ChatExternalUserId);
      Assert.AreEqual(actualExternalUserDataRow["Email"].ToString(), expectedChatExternalUser.Email.ToString());
      Assert.AreEqual(actualExternalUserDataRow["TenantId"].ToString(), expectedChatExternalUser.TenantId.ToString());
    }

    #endregion Get Methods

    #region Add Methods

    [TestMethod]
    [TestCategory(TestCategory.AddOperation)]
    [TestProperty("Author", "Shashank Jain, 22 May 2015")]
    public void Add_Test() {
      // First add a record and then get it.
      ChatExternalUser expectedChatExternalUser = GetTestEntity();

      // Add
      Guid actualChatExternalUserId = _dataServiceProvider.Add(expectedChatExternalUser);
      // Now get this inserted record.
      ChatExternalUser actualChatExternalUser = _dataServiceProvider.GetEntity(actualChatExternalUserId);

      Assert.IsNotNull(actualChatExternalUser);
      Assert.AreEqual(actualChatExternalUser.ChatExternalUserId, expectedChatExternalUser.ChatExternalUserId);
      Assert.AreEqual(actualChatExternalUser.Email, expectedChatExternalUser.Email);
      Assert.AreEqual(actualChatExternalUser.TenantId, expectedChatExternalUser.TenantId);

    }

    #endregion Add Methods

    #region Update Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Update_Test() {

      using (TransactionScope transaction = CreateTransaction()) {
        ChatExternalUser expectedChatExternalUser = GetTestEntity();


        Guid newChatExternalUserId = _dataServiceProvider.Add(expectedChatExternalUser);
        // Get this newly generated chat External User.
        ChatExternalUser newChatExternalUser = _dataServiceProvider.GetEntity(newChatExternalUserId);
        // update some records.


        _dataServiceProvider.Update(newChatExternalUser);

        ChatExternalUser actualChatExternalUser = _dataServiceProvider.GetEntity(newChatExternalUserId);
        Assert.IsNotNull(actualChatExternalUser);
        Assert.AreEqual(actualChatExternalUser.ChatExternalUserId, expectedChatExternalUser.ChatExternalUserId);
        Assert.AreEqual(actualChatExternalUser.Email, expectedChatExternalUser.Email);
        Assert.AreEqual(actualChatExternalUser.TenantId, expectedChatExternalUser.TenantId);

      }

    }

    #endregion Update Methods

    #region Delete Methods

    [TestMethod]
    [TestCategory(TestCategory.UpdateOperation)]
    [TestProperty("Author", "Rajesh Thakur, 22 May 2015")]
    public void Delete_Test() {
      // First add a record and then delete it.
      ChatExternalUser externalUser = GetTestEntity();


      Guid newChatExternalUserId = _dataServiceProvider.Add(externalUser);
      // Now get this record.
      ChatExternalUser expectedChatExternalUser = _dataServiceProvider.GetEntity(newChatExternalUserId);

      Assert.IsNotNull(expectedChatExternalUser);
      Assert.AreEqual(expectedChatExternalUser.ChatExternalUserId, newChatExternalUserId);

      // Now delete the same record.
      _dataServiceProvider.Delete(expectedChatExternalUser);
      // Now try to get this deleted chat thread record, it should be null.
      ChatExternalUser notExpectedChatExternalUser = _dataServiceProvider.GetEntity(newChatExternalUserId);

      //Assert actual chat External User should be null as it is deleted.
      Assert.IsNull(notExpectedChatExternalUser);
    }

    #endregion

    #region Private Methods

    private static ChatExternalUser GetTestEntity() {
      EwAppSession session = EwAppSessionManager.GetSession();

      ChatExternalUser externalUser = new ChatExternalUser();
      externalUser.TenantId = session.TenantId;
      externalUser.Email = "ChatExternalUserEmail";
      externalUser.Name = "chatExternalUserTest";
      return externalUser;
    }

    #endregion Private Methods

  }
}
