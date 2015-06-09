namespace Mentoring.WEBApi.Models
{
    public class JiraItem
    {
        public long JiraItemId   { get; set; }   //(our internal)
        public int JiraSourceId { get; set; }
        public long RequestIdType { get; set; }
        public long JiraNumber { get; set; } 

    }
}
