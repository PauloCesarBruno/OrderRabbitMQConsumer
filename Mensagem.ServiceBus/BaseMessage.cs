using System.ComponentModel.DataAnnotations;

namespace Mensagem.MessageBus
{
    public class BaseMessage
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataEntrada { get; set; }
    }
}
