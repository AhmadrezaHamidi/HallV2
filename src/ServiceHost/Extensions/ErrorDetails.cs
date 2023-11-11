using Newtonsoft.Json;

namespace ServiceHost.Extensions
{
    internal class ErrorDetails
    {
        public string Message { get; set; }
        public object Code { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}