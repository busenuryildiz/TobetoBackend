
using StackExchange.Redis;

public class RedisService
{
    private ConnectionMultiplexer _connectionMultiplexer;

    public RedisService()
    {
        Connect("redis-16350.c267.us-east-1-4.ec2.cloud.redislabs.com:16350,password=6CkWVBIu5cVuXRa7sU2LLeXCZZv389yY");
    }

    private void Connect(string redisConnectionString)
    {
        _connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
    }

    public IDatabase GetDatabase(int db = -1)
    {
        return _connectionMultiplexer.GetDatabase(db);
    }
}
