using System;

namespace Infrastructure
{
    public class DbConfig
    {
        public string  ConnectionString { get; set; }
        public bool IsDevEnv {get; set;}
    }
}
