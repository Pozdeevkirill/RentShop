
namespace VideoRentShop.Models.ScopeContexts
{
    public abstract class BaseScopeCtxt<T, TTo>
        : IScopeContext<T, TTo>
        where T : Entity
        where TTo : Entity
    {
        public Guid Id { get; set; }
        public T Entity { get; set; }
        public TTo EntitTo { get; set; }
    }
}
