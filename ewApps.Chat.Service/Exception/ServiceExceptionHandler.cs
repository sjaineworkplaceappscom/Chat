//===============================================================================
// Copyright © eWorkplace Apps.  All rights reserved.
// eWorkplace Apps Common Tools
// Main Author: Sanjeev Khanna
// Original Date: Apr. 02, 2012
//===============================================================================

using System;
using System.Diagnostics;
using System.Net;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using ewApps.CommonRuntime.Common;
using System.Xml;
using System.Web.Http;
using System.Net.Http;

namespace ewApps.ED.Service {

  /// <summary> 
  /// This class provide exception handling method in Service module. 
  /// Exception is handled by Rethrow category.In this category it log the exception and throw
  /// new WebFault exception in xml format.
  /// </summary>
  public class ServiceExceptionHandler {

    /// <summary>
    /// This method is used to handle exception.
    /// </summary>
    /// <param name="ex">Exception.</param>         
    public static void HandleException(ref System.Exception ex) {
      HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
      string message = "A fatal error has occurred in completing this operation. Please retry it, and if it happens again, report the problem to application support.";
      HandleException(ref ex, message, httpStatusCode, TraceEventType.Error);
    }

    /// <summary>
    /// This method is used to handle exception.
    /// </summary>
    /// <param name="ex">Exception.</param>      
    /// <param name="message">Exception Message.</param>   
    public static void HandleException(ref System.Exception ex, string message) {
      HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
      HandleException(ref ex, message, httpStatusCode, TraceEventType.Error);
    }

    /// <summary>
    /// This method is used to handle exception.
    /// </summary>
    /// <param name="ex">Exception.</param>      
    /// <param name="message">Exception Message.</param> 
    /// <param name="httpStatusCode">Http Status Code.</param>       
    public static void HandleException(ref System.Exception ex, string message, HttpStatusCode httpStatusCode) {
      HandleException(ref ex, message, httpStatusCode, TraceEventType.Error);
    }

    /// <summary>
    /// This method is used to handle all web client module exception.
    /// </summary>
    /// <param name="ex">Exception.</param>
    /// <param name="message">Additional Message.</param>
    /// <param name="statusCode">Http Status code.</param>
    /// <param name="severity">Severity.</param>       
    public static void HandleException(ref System.Exception ex, string message, HttpStatusCode statusCode, TraceEventType severity) {
      try {
        // Set current status code in exception data collection. 
        ExceptionUtils.SetHttpSatusCode(ex, statusCode);
        // Set additional message in exception data collection. 
        ExceptionUtils.SetAdditionalMsg(ex, message);
        // Initialize MapRethrownExceptions handler.
        MapRethrownExceptions mapRethrownExceptions = new MapRethrownExceptions(MapRethrowEx);
        // Pass the exception to common exception handler written in server side, under rethrow category.
        // This exception handler will call back to MapRethrowEx handler and log the exception.
        ExceptionHandler.HandleException(ref ex, ExceptionCategoryEnum.Rethrow, severity, message, MapRethrowEx, Constants.LogPolicyKey);
      }
      catch (Exception exService) {
        if (exService.GetType() == typeof(HttpResponseException))
          //if (exService.GetType() == typeof(WebFaultException<EwpError>))
          throw exService;
        else {
          EwpServiceErrorData error = new EwpServiceErrorData(ErrorType.SystemError, new List<string>() { exService.Message }, null);
          XmlDocument xmlError = EwpServiceErrorData.ToXmlWriter(error);
          HttpResponseMessage resMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError) {
            Content = new StringContent(xmlError.ToString())
          };
          throw new HttpResponseException(resMsg);
        }
      }
    }

    /// <summary>
    /// This is a handler of MapRethrownExceptions deligate.
    /// </summary>
    /// <param name="ex">Exception.</param>
    /// <returns>New Exception.</returns>
    private static Exception MapRethrowEx(Exception ex) {
      TraceEventType severity = ewApps.CommonRuntime.Common.ExceptionUtils.GetSeverity(ex);
      Exception originalEx = ex.GetBaseException();
      List<string> messages = new List<string>();
      ErrorType errorType = ErrorType.SystemError;
      IList<EwpErrorData> errorDataList = new List<EwpErrorData>();

      // If generated excetption is WebFaultException type.         
      if (ex is HttpResponseException) {
        //WebFaultException<string> webFaultEx = ex as WebFaultException<string>;
        messages.Add(ex.Message);
        severity = TraceEventType.Critical;
        errorType = ErrorType.SystemError;
      }
      // Invalid remote device or device not register on local.
      else if (originalEx is InvalidDeviceIdException) {
        InvalidDeviceIdException invalidDeviceIdEx = (InvalidDeviceIdException)originalEx;
        messages.Add(originalEx.Message);
        errorType = ErrorType.InvalidDeviceId;
      }

      // Validation Exception like required fields.
      else if (originalEx is ValidationException) {
        ValidationException validationEx = (ValidationException)originalEx;
        messages.Add(originalEx.Message);
        errorType = ErrorType.ValidationError;
        errorDataList = validationEx.ErrorDataList;
      }
      // Duplicate Name Exception.
      else if (originalEx.GetType() == typeof(ewApps.CommonRuntime.Common.DuplicateNameException)) {
        messages.Add(originalEx.Message);
        errorType = ErrorType.ValidationError;
      }
      // DataConcurrency Excetpion.
      else if (originalEx is DataConcurrencyException) {
        messages.Add(originalEx.Message);
        errorType = ErrorType.ConcurrencyError;
      }
      // Security Exception. 
      else if (originalEx is SecurityException) {
        messages.Add(originalEx.Message);
        errorType = ErrorType.SecurityError;
      }
      // Recoverable Exception.
      else if (originalEx.GetType().BaseType == typeof(RecoverableException)) {
        messages.Add(originalEx.Message);
        errorType = ErrorType.ValidationError;
      }
      // Not Implemented Exception. 
      else if (originalEx is NotImplementedException) {
        messages.Add(originalEx.Message);
        severity = TraceEventType.Critical;
        errorType = ErrorType.SystemError;
      }
      // Session expired Exception. 
      else if (originalEx is InvalidSessionException) {
        messages.Add(originalEx.Message);
        errorType = ErrorType.SystemError;
      }
      // For email server is down
      else if (originalEx.GetType() == typeof(System.Net.Mail.SmtpException) || originalEx.GetType() == typeof(System.Net.Sockets.SocketException)) {
        messages.Add(ServerMessages.MailServerUnavailable);
        severity = TraceEventType.Critical;
        errorType = ErrorType.SystemError;
      }
      // For sql connection timeout
      else if (originalEx.GetType() == typeof(System.Data.SqlClient.SqlException)) {
        if (originalEx.Message.Contains("Timeout expired"))
          messages.Add(ServerMessages.SQLConTimeOut);
        else
          messages.Add(originalEx.Message);
        severity = TraceEventType.Critical;
        errorType = ErrorType.DatabaseError;
      }
      // Invalid Login Email
      else if (originalEx is InvalidLoginEmailIdException) {
        messages.Add(originalEx.Message);
        errorType = ErrorType.SecurityError;
        errorDataList.Add(new EwpErrorData() {
          Data = "Email",
          ErrorSubType = ErroSubType.InvalidEmail,
          Message = originalEx.Message
        });
      }
      // If System generated excetpion or custom  excetpioin.
      else {
        messages.Add(string.IsNullOrWhiteSpace(ex.Message) ? ex.Message : string.Format("A fatal error has occurred in completing this operation. Please retry it, and if it happens again, report the problem to application support."));
        severity = TraceEventType.Critical;
      }

      // Format and log error message
      string errorMsg = new ExceptionFormatter().Format("", originalEx);
      MessageLogger.Instance.LogMessage(errorMsg, LoggerCategory.Production, null, false);
      EwpServiceErrorData error = new EwpServiceErrorData(errorType, messages, errorDataList);
      XmlDocument xmlError = EwpServiceErrorData.ToXmlWriter(error);
      HttpResponseMessage resMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError) {
        Content = new StringContent(xmlError.ToString())
      };
      throw new HttpResponseException(resMsg);
    }
  }
}
