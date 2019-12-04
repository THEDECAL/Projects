using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer.Models
{
    /// <summary>
    /// Исключение которое срабатывает когда нужно выполнить перенаправление на страницу
    /// </summary>
    public class HttpRedirectException : Exception
    {
        public HttpRedirectException(string message) : base(message) { }
    }
    /// <summary>
    /// Исключение для сообщений на странице
    /// </summary>
    public class MessageException : Exception
    {
        public MessageException(string message) : base(message) { }
    }
}
