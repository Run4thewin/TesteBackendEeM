namespace TesteBackendEeM.Entidades
{
    public abstract class BaseEntity<TKeyType>
    {
        public virtual TKeyType Id { get; set; }
    }
}
