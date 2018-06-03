using System;

namespace BelatrixLogger.Model
{
    public class LogObject
    {
        public LogLevel Level;
        public String Message { get; set; }
        public Exception Ex { get; set; }
        public String MachineName { get; set; }
        public String UserName { get; set; }
        public DateTime CreatedDate { get; set; }

        public String ExceptionMessage
        {
            get {
                if (Ex != null)
                    return String.Format("->{0} // {1}", Ex.Message, Ex.StackTrace);
                else
                    return String.Empty;
            }
        }

        public LogObject(LogLevel _level)
        {
            MachineName = Environment.MachineName;
            UserName = Environment.UserName;
            CreatedDate = DateTime.Now;
            Level = _level;
        }


    }
}
