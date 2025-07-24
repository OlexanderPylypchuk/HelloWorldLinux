using MessagePack;

namespace HelloWorldLinux.Models
{
    [MessagePackObject]
    public class Response
    {
        [Key(0)]
        public string Message { get; set; }
        [Key(1)]
        public DateTime Timestamp { get; set; }
    }
}
