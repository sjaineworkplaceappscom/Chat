using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ewApps.CommonRuntime;
using System.Reflection;
using ewApps.CommonRuntime.Common;

namespace ewApps.Chat.Common {

  /// <summary>
  /// This class contains application information.  
  /// </summary>
  public class ChatApplicationInfo : BaseApplicationInfo {

    #region Local Members

    public static readonly Guid AppId = new Guid("6B898494-9F5B-4EA1-98FF-E207F0E36F14");
    public const string AppAbbreviation = "Chat";
    public const string AppName = "Chat";
    public const string AppVersion = "1.0.0";
    public static readonly List<NotificationInfo> NotificationInformationList = new List<NotificationInfo>();

    #endregion Local Members

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatApplicationInfo"/> class.
    /// </summary>
    /// <param name="applicationData">The dictionary of application data.</param>
    public ChatApplicationInfo(Func<AppCallbackCommand, Dictionary<string, object>, object> applicationData) {
      ApplicationCallbackHandler = applicationData;
    }

    static ChatApplicationInfo() {
      NotificationInformationList = new List<NotificationInfo>();
      InitializeChatNotificationInformation();
    }

    #endregion Constructor

    #region Override Properties

    ///<inheritdoc/>  
    public override Guid ApplicationId {
      get {
        return AppId;
      }
    }

    ///<inheritdoc/>  
    public override string Abbreviation {
      get {
        return AppAbbreviation;
      }
    }

    ///<inheritdoc/>  
    public override string Name {
      get {
        return AppName;
      }
    }

    ///<inheritdoc/>  
    public override string ApplicationVersion {
      get {
        return AppVersion;
      }
    }

    ///<inheritdoc/>  
    public override string ApplicationUrl {
      get {
        throw new NotImplementedException();
      }
    }

    ///<inheritdoc/>  
    public override List<NotificationInfo> NotificationInformation {
      get {
        return NotificationInformationList;
      }
    }

    #endregion Override Properties

    private static void InitializeChatNotificationInformation() {
      //// Employee 'Out of Office' event notification.
      //NotificationInfo outOfOfficeEventNotification = new NotificationInfo(NotificationTypeEnum.Event, (int)ChatEntityType.Employee, (int)ChatEntityType.Employee, (int)ChatEmployeeEventNotification.EmployeeOutOfOffice, (int)ChatEntityType.Employee, new List<NotificationDeliveryType>() { NotificationDeliveryType.Email }, null);
      //NotificationInformationList.Add(outOfOfficeEventNotification);

      //// This Week email notification.
      //NotificationInfo thisWeekEmailNotification = new NotificationInfo(NotificationTypeEnum.Cyclic, (int)ChatEntityType.Employee, (int)ChatEntityType.Employee, (int)ChatCyclicNotification.WeeklyDigest, (int)ChatEntityType.None, new List<NotificationDeliveryType>() { NotificationDeliveryType.Email }, null);
      //NotificationInformationList.Add(outOfOfficeEventNotification);

      //// Employee 'Ping' Adhoc notification.
      //NotificationInfo pingAdhocNotification = new NotificationInfo(NotificationTypeEnum.Adhoc, (int)ChatEntityType.Employee, (int)ChatEntityType.Employee, (int)ChatAdhocNotification.Ping, (int)ChatEntityType.None, new List<NotificationDeliveryType>() { NotificationDeliveryType.Email, NotificationDeliveryType.SMS }, null);
      //NotificationInformationList.Add(pingAdhocNotification);

      //// 'Welcome Tenant' Adhoc notification.
      //NotificationInfo welcomeTenantNotification = new NotificationInfo(NotificationTypeEnum.Adhoc, (int)ChatEntityType.None, (int)ChatEntityType.None, (int)ChatAdhocNotification.WelcomeSignupTenant, (int)ChatEntityType.None, new List<NotificationDeliveryType>() { NotificationDeliveryType.Email }, null);
      //NotificationInformationList.Add(welcomeTenantNotification);

      //// 'Welcome Employee' Adhoc notification.
      //NotificationInfo welcomeEmployeeNotification = new NotificationInfo(NotificationTypeEnum.Adhoc, (int)ChatEntityType.None, (int)ChatEntityType.None, (int)ChatAdhocNotification.WelcomeSignupEmployee, (int)ChatEntityType.None, new List<NotificationDeliveryType>() { NotificationDeliveryType.Email }, null);
      //NotificationInformationList.Add(welcomeEmployeeNotification);

      //// 'Reset Password Request' Adhoc notification.
      //NotificationInfo resetPasswordRequestNotification = new NotificationInfo(NotificationTypeEnum.Adhoc, (int)ChatEntityType.None, (int)ChatEntityType.None, (int)ChatAdhocNotification.ResetPasswordRequest, (int)ChatEntityType.None, new List<NotificationDeliveryType>() { NotificationDeliveryType.Email }, null);
      //NotificationInformationList.Add(resetPasswordRequestNotification);

      //// 'Change Password' Adhoc notification.
      //NotificationInfo changePasswordNotification = new NotificationInfo(NotificationTypeEnum.Adhoc, (int)ChatEntityType.None, (int)ChatEntityType.None, (int)ChatAdhocNotification.ChangePassword, (int)ChatEntityType.None, new List<NotificationDeliveryType>() { NotificationDeliveryType.Email }, null);
      //NotificationInformationList.Add(changePasswordNotification);

    }

    /// </summary>
    /// <returns>An array of fully qualified resource names</returns>
    public static string[] GetEmbeddedResourceNames() {
      return Assembly.GetExecutingAssembly().GetManifestResourceNames();
    }
  }
}
