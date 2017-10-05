using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using ewApps.CommonRuntime.Common;
using System.Xml;
using System.Text;

namespace ewApps.Chat.Service {

  /// <summary>
  /// This handler vlidate token on every client request. 
  /// </summary>
  public class TokenValidationHandler : DelegatingHandler {
    string[] anonymousActionMethods = new string[] { "AddChatUser" };

    /// <summary>
    /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
    /// </summary>
    /// <param name="request">The HTTP request message to send to the server.</param>
    /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
    /// <returns>
    /// Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
    /// </returns>
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
      string token;
      EwpServiceErrorData error = new EwpServiceErrorData();
      // If request for anonymous action
      if (AnonymousActionRequest(request))
        return base.SendAsync(request, cancellationToken);


      // Get token from header
      try {
        token = request.Headers.GetValues(ewApps.CommonRuntime.Common.Constants.EwpAccessTokenKey).FirstOrDefault();
      }
      catch (System.InvalidOperationException) {
        return Task.Factory.StartNew(() => {

          EwpErrorData errorData = new EwpErrorData() {
            Data = "EwpAccessTokenKey",
            ErrorSubType = ErroSubType.FieldRequired,
            Message = ServerMessages.FieldDataRequired
          };
          error.DataList = new List<EwpErrorData>();
          error.ErrorType = ErrorType.AuthenticationError;
          error.MessageList = new List<string>();
          error.MessageList.Add(String.Format(ServerMessages.FieldDataRequired, "EwpAccessTokenKey"));
          error.DataList.Add(errorData);

          XmlDocument xmlError = EwpServiceErrorData.ToXmlWriter(error);
          return new HttpResponseMessage(HttpStatusCode.BadRequest) {
            Content = new StringContent(xmlError.InnerXml, Encoding.UTF8, "application/xml")
          };
        });
      }
      //Validate Token      
      try {
        string baseUrl = ConfigHelper.GetAuthenticationServiceUri();
        string requestUrl = "Authentication/ValidateLoginToken";
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("EwpAccessToken", token));
        bool valid = Convert.ToBoolean(HttpClientHelper.ExecuteGetRequest<string>(baseUrl, requestUrl, AcceptType.JSON, headers, null, null));
        if (!valid)
          return Task.Factory.StartNew(() => {

            EwpErrorData errorData = new EwpErrorData() {
              Data = "EwpAccessTokenKey",
              ErrorSubType = ErroSubType.InvalidLoginToken,
              Message = String.Format(ServerMessages.FieldDataRequired, "EwpAccessTokenKey")
            };
            error.ErrorType = ErrorType.AuthenticationError;
            error.MessageList = new List<string>();
            error.MessageList.Add(String.Format(ServerMessages.FieldDataRequired, "EwpAccessTokenKey"));
            error.DataList = new List<EwpErrorData>();
            error.DataList.Add(errorData);

            XmlDocument xmlError = EwpServiceErrorData.ToXmlWriter(error);
            return new HttpResponseMessage(HttpStatusCode.BadRequest) {
              Content = new StringContent(xmlError.InnerXml, Encoding.UTF8, "application/xml")
            };
          });
      }
      catch (Exception ex) {
        return Task.Factory.StartNew(() => {
          error.ErrorType = ErrorType.SystemError;
          error.MessageList = new List<string>();
          error.MessageList.Add(ServerMessages.ErrorOccurredDuringTokenProcessing);
          error.DataList = new List<EwpErrorData>();
          XmlDocument xmlError = EwpServiceErrorData.ToXmlWriter(error);
          return new HttpResponseMessage(HttpStatusCode.InternalServerError) {
            Content = new StringContent(xmlError.ToString())
          };
        });
      }
      return base.SendAsync(request, cancellationToken);
    }

    private bool AnonymousActionRequest(HttpRequestMessage request) {
      object actionName = request.RequestUri.Segments[request.RequestUri.Segments.Length - 1].ToString();
      var routeData = request.GetRouteData();
      //object controllerName;

      //routeData.Values.TryGetValue("controller", out controllerName);
      //routeData.Values.TryGetValue("id", out actionName);
      //if (String.Equals(Convert.ToString(controllerName), "Authentication", StringComparison.OrdinalIgnoreCase)
      //    && String.Equals(Convert.ToString(actionName), "AuthenticateUser", StringComparison.OrdinalIgnoreCase)
      //   )

      if (anonymousActionMethods.Contains(actionName))
        return true;
      else
        return false;
    }

  }
}