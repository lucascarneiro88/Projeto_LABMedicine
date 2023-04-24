

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoSistemaEnum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Ativo = 0,

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Inativo = 1
    }
}
