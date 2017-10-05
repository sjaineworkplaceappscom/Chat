using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ewApps.CommonRuntime;
using ewApps.Chat.Common;
using ewApps.Chat.Entity;
using ewApps.Chat.DataService;
using ewApps.CommonRuntime.DataService;
using ewApps.CommonRuntime.Entity;
using ewApps.CommonRuntime.Common;


namespace ewApps.Chat.DataService {

  /// <summary>
  /// This class contains Init() method which will execute init code, 
  /// like registering the app with Notification Service module etc.
  /// This class may have other init-related data and methods if required.
  /// The EXE of the server (WC in our case) will call the static Init() method to register app. 
  /// </summary>
  public static class AppInit {

    /// <summary>
    /// This method is call on application start.
    /// </summary>
    public static void Init() {
      ChatApplicationInfo appInfo = new ChatApplicationInfo(GetApplicationData);
      ApplicationManager.Register(appInfo);
    }

    /// <summary>
    /// Call back function to get employee directory application data
    /// </summary>
    /// <param name="command">Application callback command to get application data</param>
    /// <param name="parameters">Parameters  to get application data</param>
    /// <returns>Required information for given parameter</returns>
    public static object GetApplicationData(AppCallbackCommand command, Dictionary<string, object> parameters) {
      switch (command) {
        //case AppCallbackCommand.SignUpTenant:
        //  return SingUpTenant(parameters);
        //case AppCallbackCommand.SendChangePasswordEmail:
        //  SendChangePasswordEmail(parameters);
        //  return true;
        //case AppCallbackCommand.ForgotPasswordEmail:
        //  SendForgotPasswordEmail(parameters);
        //  return true;
        case AppCallbackCommand.ResolveNotificationRecipient:
          //return ResolveNotificationRecipients(parameters);
          return null;
        case AppCallbackCommand.ResolveUNQToNotification:
          return ResolveUNQToNotification(parameters);
        case AppCallbackCommand.ResolveCyclicNotificationContent:
          //return ResolveCyclicNotificationContent();
          return null;
        default:
          break;
      }
      return null;
    }

    #region Employee

    //private static Guid SingUpTenant(Dictionary<string, object> parameters) {
    //  // Extract parameter information
    //  string userName = Convert.ToString(parameters["UserName"]);
    //  string loginEmail = Convert.ToString(parameters["LoginEmail"]);
    //  Guid userId = new Guid(Convert.ToString(parameters["UserId"]));
    //  Guid tenantId = new Guid(Convert.ToString(parameters["TenantId"]));
    //  string tenantName = Convert.ToString(parameters["TenantName"]);

    //  // Generate Tenant SignUp for Chat 
    //  ITenantDataService tenantDS = DataServiceFactory.GetDataService<Tenant>(EntityType.Tenant) as ITenantDataService;
    //  tenantDS.GenenrateTenantSignUpDataForChat(tenantId);

    //  // SignUp Primary Employee
    //  IEmployeeDataService empDS = ChatDataServiceFactory.GetDataService<Employee>(ChatEntityType.Employee) as IEmployeeDataService;
    //  return empDS.SignupPrimaryEmployee(tenantName, userName, loginEmail, userId, tenantId);
    //}

    //private static void SendChangePasswordEmail(Dictionary<string, object> parameters) {
    //  IEmployeeDataService empDS = ChatDataServiceFactory.GetDataService<Employee>(ChatEntityType.Employee) as IEmployeeDataService;
    //  Guid userId = new Guid(Convert.ToString(parameters["UserId"]));
    //  List<Guid> tenantIdList = (parameters["TenantIdList"] as List<Guid>);
    //  empDS.SendChangePasswordEmail(userId, Convert.ToString(parameters["LoginEmail"]), tenantIdList);
    //}

    //private static void SendForgotPasswordEmail(Dictionary<string, object> parameters) {
    //  IEmployeeDataService empDS = ChatDataServiceFactory.GetDataService<Employee>(ChatEntityType.Employee) as IEmployeeDataService;
    //  empDS.SendForgotPasswordEmail(Convert.ToString(parameters["LoginEmail"]));
    //}

    //private static List<NotificationRecipientDetail> ResolveNotificationRecipients(Dictionary<string, object> parameters) {
    //  switch ((NotificationTypeEnum)parameters["NotificationType"]) {
    //    case NotificationTypeEnum.Event:
    //      return ChatNotificationDataService.Instance.GetResolvedEventNotificationRecipientDetailList((List<EventNotification>)parameters["ResolvedNotificationInfo"], (Guid)parameters["TenantId"], (ChatEntityType)parameters["NotifierEntityType"], (Guid)parameters["NotifierEntityId"]);
    //    case NotificationTypeEnum.Adhoc:
    //      break;
    //    case NotificationTypeEnum.Cyclic:
    //    default:
    //      break;
    //  }
    //  return null;
    //}

    private static Tuple<NotificationQueue, List<NotificationAttachment>> ResolveUNQToNotification(Dictionary<string, object> parameters) {
      //return ChatNotificationDataService.Instance.ResolveUNQToNotification(parameters["UNQInstance"] as UnpreparedNotificationQueue);
      return null;
    }

    //private static List<CyclicNotificationCallbackResult> ResolveCyclicNotificationContent() {
    //  return ChatNotificationDataService.Instance.GetWeekEmailRecipientAndOtherInformation();
    //}

    #endregion Employee
  }
}
