namespace GatewayAPI.Services
{
    public interface IManageUser<T>
    {
        Task<T> Register(T user);
        Task<T> Login(T user);
    }
}
