using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpShared.Events
{
    public class UserFeedbackEventArgs:EventArgs
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public bool Cancel { get; set; } = false;

        public UserFeedbackEventArgs(string message, string title)
        {
            Message = message;
            Title = title;
        }
    }


}
