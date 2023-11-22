namespace Business.Abstractions
{
    public interface IJwtSettings
    {
        public abstract string Key { get; }
        public abstract string Issuer { get; }
        public abstract string Audience { get; }
    }
}
