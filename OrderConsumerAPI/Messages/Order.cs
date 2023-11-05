using Mensagem.MessageBus;
using System.ComponentModel.DataAnnotations;

namespace OrderConsumerAPI.Messages;

public class Order : BaseMessage
{      
    public string Nome { get; set; }
    public string CPF { get; set; }    
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cartao { get; set; }     
    public string NumeroCartao { get; set; }      
    public string DataVencimento { get; set; }    
    public string CVV { get; set; }
}
