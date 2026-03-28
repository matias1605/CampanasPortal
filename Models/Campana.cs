namespace CampanasPortal.Models
{
    public class Campana
    {
        public int      Id           { get; set; }
        public string   Nombre       { get; set; } = string.Empty;
        /// <summary>Electro | Hogar | Moda | Tecnología</summary>
        public string   Categoria    { get; set; } = string.Empty;
        /// <summary>Vigente | Próxima | Finalizada</summary>
        public string   Estado       { get; set; } = string.Empty;
        public DateTime FechaInicio  { get; set; }
        public DateTime FechaFin     { get; set; }
        /// <summary>Descuento en decimal. Ej: 0.15 = 15 %</summary>
        public decimal  DescuentoPct { get; set; }
        /// <summary>Web | App | Tienda</summary>
        public string   Canal        { get; set; } = string.Empty;
        public string   Descripcion  { get; set; } = string.Empty;
    }
}
