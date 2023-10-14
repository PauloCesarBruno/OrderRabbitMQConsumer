using System.ComponentModel.DataAnnotations;

namespace Mensagem.MessageBus
{
    public class BaseMessage
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido !!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_Registro { get; set; }
    }
}
