namespace Gof.Behavioral.Strategy
{
    public interface IEntityValidator<T> where T : IEntity
    {
        bool Validate(T entity);
    }
}
