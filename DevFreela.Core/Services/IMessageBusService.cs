namespace DevFreela.Core.Services
{
    public interface IMessageBusService
    {
        public void Publish(string queue, byte[] message);
    }
}
