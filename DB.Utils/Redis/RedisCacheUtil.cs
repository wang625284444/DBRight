using StackExchange.Redis;
using System;

namespace DB.Utils.Redis
{
    public class RedisCacheUtil : IDisposable
    {
        public string IpAndPort { get; } = "127.0.0.1";
        public RedisCacheUtil() { }
        public RedisCacheUtil(string ipAndPort)
        {
            this.IpAndPort = ipAndPort;
        }
        private ConnectionMultiplexer instance;
        private readonly object locker = new object();
        public ConnectionMultiplexer Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null || instance.IsConnected == false)
                    {
                        instance = ConnectionMultiplexer.Connect(IpAndPort);
                    }
                }
                return instance;
            }
        }
        public void Dispose()
        {
            lock (locker)
            {
                if (instance != null)
                {
                    try
                    {
                        instance.Close(true);
                    }
                    catch { }
                }
            }
        }
    }
}