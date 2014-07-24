using System;

namespace tc_dev.Core.Service
{
    public interface ILogger
    {
        void Log(string message);

        void Log(Exception ex);
    }
}
