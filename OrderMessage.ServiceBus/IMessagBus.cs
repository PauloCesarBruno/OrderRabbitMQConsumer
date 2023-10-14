using Mensagem.MessageBus;

namespace OrderMessage.ServiceBus;

public interface IMessagBus
{
    Task PublicMessage(BaseMessage message, string queueName);
}
