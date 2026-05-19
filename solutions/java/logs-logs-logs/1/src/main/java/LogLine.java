public class LogLine {
    private final String logLine;
    public LogLine(String logLine) {
        this.logLine = logLine;
    }

    public LogLevel getLogLevel() {
        int initialIndex = this.logLine.indexOf('[') + 1;
        int finalIndex = this.logLine.indexOf(']');
        String shortLogLevel = this.logLine.substring(initialIndex, finalIndex);

        return switch(shortLogLevel){
          case "TRC" -> LogLevel.TRACE;
          case "DBG" -> LogLevel.DEBUG;
          case "INF" -> LogLevel.INFO;
          case "WRN" -> LogLevel.WARNING;
          case "ERR" -> LogLevel.ERROR;
          case "FTL" -> LogLevel.FATAL;
          default -> LogLevel.UNKNOWN;
        };
    }

    public String getOutputForShortLog() {
        int initialIndex = this.logLine.indexOf(':') + 1;
        String logLineMsg = this.logLine.substring(initialIndex).trim();
        String shortLogLevel = String.valueOf(getLogLevel().getShortLogLevel());
        return shortLogLevel + ":" + logLineMsg;
    }
}
