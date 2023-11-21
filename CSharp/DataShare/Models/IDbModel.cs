namespace Models
{
    public interface IDbModel<T_Entity, T_Model>
        where T_Model : IDbModel<T_Entity, T_Model>
    {
        public abstract T_Entity ToEntity();
    }
}
