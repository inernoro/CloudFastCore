using System;

namespace Cloud.Domain
{
    /// <summary>
    /// This class is used to create standard responses for AJAX requests.
    /// </summary>
    [Serializable]
    public class AjaxResponse<TResult> : AjaxResponseBase
    {
        /// <summary>
        /// The actual result object of AJAX request.
        /// It is set if <see cref="P:Abp.Web.Models.AjaxResponseBase.Success" /> is true.
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// Creates an <see cref="T:Abp.Web.Models.AjaxResponse" /> object with <see cref="P:Abp.Web.Models.AjaxResponse`1.Result" /> specified.
        /// <see cref="P:Abp.Web.Models.AjaxResponseBase.Success" /> is set as true.
        /// </summary>
        /// <param name="result">The actual result object of AJAX request</param>
        public AjaxResponse(TResult result)
        {
            this.Result = result;
            this.Success = true;
        }

        /// <summary>
        /// Creates an <see cref="T:Abp.Web.Models.AjaxResponse" /> object.
        /// <see cref="P:Abp.Web.Models.AjaxResponseBase.Success" /> is set as true.
        /// </summary>
        public AjaxResponse()
        {
            this.Success = true;
        }

        /// <summary>
        /// Creates an <see cref="T:Abp.Web.Models.AjaxResponse" /> object with <see cref="P:Abp.Web.Models.AjaxResponseBase.Success" /> specified.
        /// </summary>
        /// <param name="success">Indicates success status of the result</param>
        public AjaxResponse(bool success)
        {
            this.Success = success;
        }

        /// <summary>
        /// Creates an <see cref="T:Abp.Web.Models.AjaxResponse" /> object with <see cref="P:Abp.Web.Models.AjaxResponseBase.Error" /> specified.
        /// <see cref="P:Abp.Web.Models.AjaxResponseBase.Success" /> is set as false.
        /// </summary>
        /// <param name="error">Error details</param>
        /// <param name="unAuthorizedRequest">Used to indicate that the current user has no privilege to perform this request</param>
        public AjaxResponse(ErrorInfo error, bool unAuthorizedRequest = false)
        {
            this.Error = error;
            this.UnAuthorizedRequest = unAuthorizedRequest;
            this.Success = false;
        }
    }
    public abstract class AjaxResponseBase
    {
        /// <summary>
        /// A special signature for AJAX responses. It's used in the client to detect if this is a response wrapped by ABP.
        /// </summary>
        public bool __abp { get; } = true;

        /// <summary>
        /// This property can be used to redirect user to a specified URL.
        /// </summary>
        public string TargetUrl { get; set; }

        /// <summary>
        /// Indicates success status of the result.
        /// Set <see cref="P:Abp.Web.Models.AjaxResponseBase.Error" /> if this value is false.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error details (Must and only set if <see cref="P:Abp.Web.Models.AjaxResponseBase.Success" /> is false).
        /// </summary>
        public ErrorInfo Error { get; set; }

        /// <summary>
        /// This property can be used to indicate that the current user has no privilege to perform this request.
        /// </summary>
        public bool UnAuthorizedRequest { get; set; }
    }
    /// <summary>Used to store information about an error.</summary>
    [Serializable]
    public class ErrorInfo
    {
        /// <summary>Error code.</summary>
        public int Code { get; set; }

        /// <summary>Error message.</summary>
        public string Message { get; set; }

        /// <summary>Error details.</summary>
        public string Details { get; set; }

        /// <summary>Validation errors if exists.</summary>
        public ValidationErrorInfo[] ValidationErrors { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ErrorInfo" />.
        /// </summary>
        public ErrorInfo()
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ErrorInfo" />.
        /// </summary>
        /// <param name="message">Error message</param>
        public ErrorInfo(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ErrorInfo" />.
        /// </summary>
        /// <param name="code">Error code</param>
        public ErrorInfo(int code)
        {
            this.Code = code;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ErrorInfo" />.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Error message</param>
        public ErrorInfo(int code, string message)
          : this(message)
        {
            this.Code = code;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ErrorInfo" />.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="details">Error details</param>
        public ErrorInfo(string message, string details)
          : this(message)
        {
            this.Details = details;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ErrorInfo" />.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Error message</param>
        /// <param name="details">Error details</param>
        public ErrorInfo(int code, string message, string details)
          : this(message, details)
        {
            this.Code = code;
        }
    }
    /// <summary>Used to store information about a validation error.</summary>
    [Serializable]
    public class ValidationErrorInfo
    {
        /// <summary>Validation error message.</summary>
        public string Message { get; set; }

        /// <summary>Relate invalid members (fields/properties).</summary>
        public string[] Members { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ValidationErrorInfo" />.
        /// </summary>
        public ValidationErrorInfo()
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ValidationErrorInfo" />.
        /// </summary>
        /// <param name="message">Validation error message</param>
        public ValidationErrorInfo(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ValidationErrorInfo" />.
        /// </summary>
        /// <param name="message">Validation error message</param>
        /// <param name="members">Related invalid members</param>
        public ValidationErrorInfo(string message, string[] members)
          : this(message)
        {
            this.Members = members;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Abp.Web.Models.ValidationErrorInfo" />.
        /// </summary>
        /// <param name="message">Validation error message</param>
        /// <param name="member">Related invalid member</param>
        public ValidationErrorInfo(string message, string member)
          : this(message, new string[1] { member })
        {
        }
    }
}