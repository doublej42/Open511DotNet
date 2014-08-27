namespace Open511DotNet
{
    public class EventSeverity : StringEnum
    {
        public static readonly EventSeverity Minor = new EventSeverity("MINOR");
        public static readonly EventSeverity Moderate = new EventSeverity("MODERATE");
        public static readonly EventSeverity Major = new EventSeverity("MAJOR");
        public static readonly EventSeverity Unknown = new EventSeverity("UNKNOWN");
      

        public EventSeverity()
        {

        }

        public EventSeverity(string severity)
            : base(severity)
        {
         
        }
    }
}
