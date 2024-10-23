using Contract;
using NLog;

namespace LoggerService
{

    /// <summary>
    /// Class <c>LoggerManager</c> writes our logs to specified file in nlog.config at root level
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Writes logs based on type
        /// </summary>
        /// <param name="message">message we want to log</param>
        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(string message) => logger.Error(message);

        public void LogInfo(string message) => logger.Info(message);

        public void LogWarn(string message) => logger.Warn(message);
    }
}