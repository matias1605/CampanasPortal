namespace CampanasPortal.Models
{
    public class ResumenViewModel
    {
        public int                        Total           { get; set; }
        public int                        Vigentes        { get; set; }
        public int                        Proximas        { get; set; }
        public int                        Finalizadas     { get; set; }
        public decimal                    PromedioDescuento { get; set; }
        public Dictionary<string, int>    PorCanal        { get; set; } = new();
    }
}
