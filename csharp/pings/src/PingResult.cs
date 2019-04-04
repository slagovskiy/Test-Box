using System.Net.NetworkInformation;

namespace Pings
{
    class PingResult
    {
        public string address;
        public string status;
        public bool wait = false;
        public Ping pinger = null;
        public string time;

        public PingResult(string address)
        {
            this.address = address;
        }
    }
}
