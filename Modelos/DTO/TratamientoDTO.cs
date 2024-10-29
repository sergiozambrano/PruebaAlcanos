namespace Modelos.DTO
{
    public class TratamientoDTO
    {
        public int IdTratamiento { get; set; }
        public string NombreTratamiento { get; set; } = null!;
        public int? IdEnfermedad {  get; set; }
        public int? IdMedicamento {  get; set; }
    }
}
