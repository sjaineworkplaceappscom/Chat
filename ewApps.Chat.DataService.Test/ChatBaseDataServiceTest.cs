using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ewApps.CommonRuntime;
using ewApps.Chat.Common;
using System.Transactions;
using ewApps.CommonRuntime.DataService;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.DataServiceTest;
using ewApps.CommonRuntime.Common;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ewApps.Chat.DataService;

namespace ewApps.Chat.DataServiceTest {

  // A abstract base class initalize test methods execution and perform the clean up after all test have completed.
  [TestClass]
  public class ChatBaseDataServiceTest : BaseDataServiceTest {

    #region Constants

    //private TestContext _edTestContextInstance;
    //protected static Guid _edLoginUserId = new Guid("00FEDC0E-4B62-46A6-9FB6-C72DD985F320");
    protected static Guid _edLoginTenantId = new Guid();// new Guid("1B948F4A-67D7-4A50-A458-0CA16DAB4FAD");
    //private static string _loginTenantName = "BatchMaster Software.Inc";
    //private static string _edLoginUserFullName = "Sanjeev Khanna";
    protected static string _edLoginEmailId = "skhanna@batchmaster.com";
    protected static string _edLoginUserPwd = "Password@123";
    // To check notification related test case, please change this email to valid any valid email.
    protected static string _edExternalNotificationEmail = "test@batchmaster.com";


    #endregion

    public static AuthenticationResponse AuthenticationResponseResult {
      get;
      private set;
    }

    #region Assembly Methods

    // Take sql test database backup. It executes onces and before running the first test in the assembly.
    [AssemblyInitialize]
    public static void AssemblyEDTestInitialized(TestContext context) {

      AppInit.Init();
      ITenantUserDataService tenantUserDS = DataServiceFactory.GetDataService<TenantUser>(EntityType.TenantUser) as ITenantUserDataService;

      // Execute sample data script.    
      //DBUtils.ExecuteSampleDataScript();
      //System.Threading.Thread.Sleep(10000);

      // Attach a method with handler to return user id and 
      // initialize the user session object in dictionary.      

      EwAppSessionManager.GetSessionId = new Func<string>(GetEDSessionId);

      //// TODO: Nitin: Please use account admin flag based on user's permission instead of hardcoded true.
      //tenantUserDS.SetLoginSession(_edLoginUserId, _edLoginUserFullName, _edLoginTenantId, _loginTenantName, GetEDSessionId(), false, true, EDApplicationInfo.AppId, EDApplicationInfo.AppName, "US", IANATimeZoneEnum.US_Pacific);
      AuthenticationRequest request = new AuthenticationRequest();
      request.ApplicationId = ChatApplicationInfo.AppId.ToString();
      request.AuthenticationType = (int)AuthenticationType.EwApps;
      request.LoginEmail = _edLoginEmailId;
      request.Password = _edLoginUserPwd;
      request.RequesterIANATimeZone = "US/Pacific";
      request.RequesterId = "";
      request.RequesterRegion = "IN";
      request.RequesterType = (int)LoginDevice.WebClient;
      request.TenantUrl = "";
      request.ApplicationId = ChatApplicationInfo.AppId.ToString();
      AuthenticationResponse response = HttpClientHelper.ExecutePOSTRequest<AuthenticationResponse>(ConfigHelper.GetAuthenticationServiceUri(), "Authentication/AuthenticateUser", AcceptType.JSON, null, null, null, request);
      AuthenticationResponseResult = response;
      _edLoginTenantId = response.TenantList.First().TenantId.Value;
      //tenantUserDS.SetLoginSession(_edLoginEmailId, _edLoginTenantId, GetEDSessionId(), EwAppSessionManager.GetSessionId, EDApplicationInfo.AppId, EDApplicationInfo.AppName, "US", IANATimeZoneEnum.US_Pacific.ToString());
      //response.AccessToken
    }

    // Restore the sql test database backup. It executes onces and after all tests in a assembly have run.
    [AssemblyCleanup]
    public static void AssemblyEDTestCleanUp() {
      ITenantUserDataService tenantUserDS = DataServiceFactory.GetDataService<TenantUser>(EntityType.TenantUser) as ITenantUserDataService;

      // Call log-out to remove user session from dictionary.
      tenantUserDS.LogoutSession(AuthenticationResponseResult.UserId.ToString());
    }

    #endregion

    #region Session Methods

    /// <summary>
    /// Change the session from login user to provided user.
    /// </summary>
    /// <param name="loginEmail">Login email id.</param>
    /// <param name="tenantId">Tenant id.</param>
    protected static void ChangeEDSession(string loginEmail, Guid tenantId) {
      EwAppSession session = EwAppSessionManager.GetSession();
      ITenantUserDataService tenantUserDS = DataServiceFactory.GetDataService<TenantUser>(EntityType.TenantUser) as ITenantUserDataService;

      if (session != null)
        tenantUserDS.LogoutSession(_loginUserId.ToString());

      tenantUserDS.SetLoginSession(loginEmail, tenantId, _loginUserId.ToString(), GetEDSessionId, ChatApplicationInfo.AppId, ChatApplicationInfo.AppName, "US", GetDefaultIANATimeZone());
    }

    /// <summary>
    /// This method return the logged-in user id.
    /// </summary>
    /// <returns></returns>
    public static string GetEDSessionId() {
      return AuthenticationResponseResult.AccessToken.ToString();
    }

    /// <summary>
    /// Reset the current login session to initial values.
    /// </summary>
    protected static void SetEDDefaultSession() {
      ChangeEDSession(_edLoginEmailId, _edLoginTenantId);
    }

    /// <summary>
    /// Sets the ed admin user session.
    /// </summary>
    public static void SetEDAdminUserSession() {
      ChangeEDSession("skhanna@batchmaster.com", _edLoginTenantId);
    }

    /// <summary>
    /// Sets the ed employee user session.
    /// </summary>
    public static void SetEDEmployeeUserSession() {
      ChangeEDSession("rthakur@batchmaster.com", _edLoginTenantId);
    }

    /// <summary>
    /// Sets the ed system admin user session.
    /// </summary>
    public static void SetEDSysAdminUserSession() {
      ChangeEDSession("ewappsadmin@batchmaster.com", _edLoginTenantId);
    }

    #endregion
  }
}
