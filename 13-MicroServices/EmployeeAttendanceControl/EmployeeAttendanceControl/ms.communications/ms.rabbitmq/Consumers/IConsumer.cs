namespace ms.rabbitmq.Consumers
{
    public interface IConsumer
    {
        void Subscribe();
        void Unsubscribe();
    }
}
