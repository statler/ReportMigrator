using System;

namespace cpReportDefinitions
{
    public class DatasourceException : Exception
    {
        public DatasourceException() : base()
        {
            _message = "The report requires a list of object Ids to get its datasource.";
        }
        public DatasourceException(string message) : base()
        {
            _message = message;
        }
        public override string Message
        {
            get { return _message; }
        }

        private string _message;
    }
}
