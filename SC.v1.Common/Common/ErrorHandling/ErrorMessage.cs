using SC.v1.Common.Common.Localization;
using SC.v1.Common.Common.Models;
using Microsoft.Extensions.Localization;

namespace SC.v1.Common.Common.ErrorHandling
{
    public static class ErrorMessage
    {
        public static ErrorResponseAttribute CreateErrorMessage(string code, string title, string source, string detail, IStringLocalizer localizer)
        {
            ErrorResponseAttribute _error = new ErrorResponseAttribute();

            _error.code = code;
            _error.title = title;
            _error.source = source;
            string detailMessage = "";

            try {
                detailMessage = localizer[detail];
            }
            catch (Exception ex)
            {
                detailMessage = detail;
            }
      
            _error.detail = detailMessage;
            
            return _error;
        }
    }
}
