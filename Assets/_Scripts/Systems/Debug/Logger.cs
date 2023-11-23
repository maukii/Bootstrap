using UnityEngine;

[CreateAssetMenu(fileName = "Logger", menuName = "Logger/new Logger")]
public class Logger : ScriptableObject
{
    public enum LogType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }

    [SerializeField] private bool showLogs = true;
    [SerializeField] private string prefix = "";
    [SerializeField] private Color prefixColor = Color.green;


    public void Log(string msg, Object sender = null) => LogMessage(msg, sender, LogType.Info);

    public void Warning(string msg, Object sender = null) => LogMessage(msg, sender, LogType.Warning);

    public void Error(string msg, Object sender = null) => LogMessage(msg, sender, LogType.Error);

    private void LogMessage(string message, Object sender, LogType logType = LogType.Info)
    {
        if (!showLogs) return;

        string logMessage = $"[<color=#{ColorUtility.ToHtmlStringRGB(prefixColor)}>{prefix}</color>] {message}";

        switch (logType)
        {
            case LogType.Info:
                Debug.Log(logMessage, sender);
                break;
            case LogType.Warning:
                Debug.LogWarning(logMessage, sender);
                break;
            case LogType.Error:
                Debug.LogError(logMessage, sender);
                break;
            default:
                Debug.Log(logMessage, sender);
                break;
        }
    }
}
