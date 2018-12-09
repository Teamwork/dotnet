using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LitJson;
using TeamworkProjects.Common;
using TeamworkProjects.Serialization;

namespace TeamworkProjects.Http
{
    class TeamworkErrorHandler
    {
        public static async Task ThrowIfErrorAsync(HttpResponseMessage msg)
        {
            const int TooManyRequests = 429;

            // TODO: research proper handling of 304

            if ((int)msg.StatusCode < 400) return;

            switch (msg.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    await HandleUnauthorizedAsync(msg).ConfigureAwait(false);
                    break;
                default:
                    switch ((int)msg.StatusCode)
                    {
                        case TooManyRequests:
                            await HandleTooManyRequestsAsync(msg).ConfigureAwait(false);
                            break;
                        default:
                            await HandleGenericErrorAsync(msg).ConfigureAwait(false);
                            break;
                    }
                    break;
            }
        }

        internal static async Task HandleGenericErrorAsync(HttpResponseMessage msg)
        {
            string responseStr = await msg.Content.ReadAsStringAsync().ConfigureAwait(false);

            BuildAndThrowTwitterQueryException(responseStr, msg);
        }

        internal static async Task HandleTooManyRequestsAsync(HttpResponseMessage msg)
        {
            string responseStr = await msg.Content.ReadAsStringAsync().ConfigureAwait(false);

            TeamworkErrorDetails error = ParseErrorMessage(responseStr);

            string message = error.Message + " - Please visit the HelpLink for help on resolving this error.";

            throw new TeamworkQueryException(message)
            {
                HelpLink = Constants.FaqHelpUrl,
                ErrorCode = error.Code,
                StatusCode = HttpStatusCode.SeeOther,
                ReasonPhrase = msg.ReasonPhrase + " (HTTP 429 - Too Many Requests)"
            };
        }

        internal static void BuildAndThrowTwitterQueryException(string responseStr, HttpResponseMessage msg)
        {
            TeamworkErrorDetails error = ParseErrorMessage(responseStr);

            throw new TeamworkQueryException(error.Message)
            {
                ErrorCode = error.Code,
                StatusCode = msg.StatusCode,
                ReasonPhrase = msg.ReasonPhrase
            };
        }

        internal static async Task HandleUnauthorizedAsync(HttpResponseMessage msg)
        {
            string responseStr = await msg.Content.ReadAsStringAsync().ConfigureAwait(false);

            TeamworkErrorDetails error = ParseErrorMessage(responseStr);

            string message = error.Message + " - Please visit the HelpLink for help on resolving this error.";

            throw new TeamworkQueryException(message)
            {
                HelpLink = Constants.FaqHelpUrl,
                ErrorCode = error.Code,
                StatusCode = HttpStatusCode.Unauthorized,
                ReasonPhrase = msg.ReasonPhrase
            };
        }

        internal static TeamworkErrorDetails ParseErrorMessage(string responseStr)
        {
            if (responseStr.StartsWith("{"))
            {
                JsonData responseJson = JsonMapper.ToObject(responseStr);

                var errors = responseJson.GetValue<JsonData>("errors");

                if (errors != null)
                {
                    if (errors.GetJsonType() == JsonType.String)
                        return new TeamworkErrorDetails
                        {
                            Message = responseJson.GetValue<string>("errors"),
                            Code = -1
                        };

                    if (errors.Count > 0)
                    {
                        var error = errors[0];
                        return new TeamworkErrorDetails
                        {
                            Message = error.GetValue<string>("message"),
                            Code = error.GetValue<int>("code")
                        };
                    }
                }
            }

            return new TeamworkErrorDetails { Message = responseStr };
        }

        internal class TeamworkErrorDetails
        {
            public int Code { get; set; }
            public string Message { get; set; }
        }
    }
}
