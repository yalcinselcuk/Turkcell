namespace DILifeTime.Models
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }
    public interface ISingletonGuid : IGuidGenerator
    {

    }
    public interface ITransientGuid : IGuidGenerator
    {

    }
    public interface IScopedGuid : IGuidGenerator
    {

    }

    public class SingletonGuid : ISingletonGuid
    {
        public Guid Guid { get; private set; }

        public SingletonGuid()
        {
            Guid = Guid.NewGuid();
        }
    }
    public class TransientGuid : ITransientGuid
    {
        public Guid Guid { get; private set; }
        public TransientGuid()
        {
            Guid = Guid.NewGuid();
        }
    }
    public class ScopedGuid : IScopedGuid
    {
        public Guid Guid { get; private set; }
        public ScopedGuid()
        {
            Guid = Guid.NewGuid();
        }
    }
}
