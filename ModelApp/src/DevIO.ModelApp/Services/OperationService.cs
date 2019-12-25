using System;

namespace DevIO.ModelApp.Services
{
    public class OperationService
    {
        public OperationService(
            IOperationTransient transient,
            IOperationScoped scoped,
            IOperationSingleton singleton,
            IOperationSingletonInstance singletonInstance
        )
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstance = singletonInstance;
        }

        public IOperationTransient Transient { get; set; }
        public IOperationScoped Scoped { get; set; }
        public IOperationSingleton Singleton { get; set; }
        public IOperationSingletonInstance SingletonInstance { get; set; }
    }

    public class Operation : IOperationTransient,
                             IOperationScoped,
                             IOperationSingleton,
                             IOperationSingletonInstance
    {
        public Operation() : this(Guid.NewGuid())
        {

        }

        public Operation(Guid id)
        {
            OperationId = id;
        }

        public Guid OperationId { get; private set; }
    }

    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperation
    {

    }

    public interface IOperationScoped : IOperation
    {

    }

    public interface IOperationSingleton : IOperation
    {

    }

    public interface IOperationSingletonInstance : IOperation
    {

    }
}
