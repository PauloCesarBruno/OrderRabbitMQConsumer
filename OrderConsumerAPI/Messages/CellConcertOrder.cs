using Mensagem.MessageBus;

namespace OrderConsumerAPI.Messages;

public class CellConcertOrder : BaseMessage
{       
    public string MarcaAparelho { get; set; }
    public string ModeloAparelho { get; set; }
    public bool Reparado { get; set; }
    public decimal ValorConserto { get; set; }
}
