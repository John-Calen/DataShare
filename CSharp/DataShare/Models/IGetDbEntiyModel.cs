namespace Models
{
    public interface IGetDbEntiyModel<T_Entity, T_Model> : IDbModel<T_Entity, T_Model>
        where T_Model : IDbModel<T_Entity, T_Model>
    {
        public abstract static T_Model ToModel(T_Entity entity);
    }
}
