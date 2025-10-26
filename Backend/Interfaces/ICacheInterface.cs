namespace StoreEcommerce.Interfaces
{
    public interface ICacheInterface
    {
        Task SetAsync<T> (string key, T value, TimeSpan? expiry = null);
        Task<T> GetAsync<T>(string key);
        Task RemoveAsync   (string key);
    }
}
