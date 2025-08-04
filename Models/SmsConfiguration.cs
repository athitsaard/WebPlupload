namespace WebPlupload.Models
{
    public class SmsConfiguration
    {
        public string WsUrl { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }
        public string SenderName { get; set; }
        public bool EnableSMSNotification { get; set; }
        public string TestNumber { get; set; }
        public string AppIdSmeSms { get; set; }
    }
}
