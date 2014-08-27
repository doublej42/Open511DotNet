namespace Open511DotNet
{
    public class EventStatus : StringEnum
    {
        public static readonly EventStatus Active = new EventStatus("ACTIVE");
        public static readonly EventStatus Archived = new EventStatus("ARCHIVED");

        public EventStatus()
        {

        }

        public EventStatus(string status)
            : base(status)
        {

        }
    }
}
