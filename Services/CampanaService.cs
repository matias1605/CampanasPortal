using CampanasPortal.Models;

namespace CampanasPortal.Services
{
    /// <summary>
    /// Fuente de datos en memoria. Sin base de datos ni Entity Framework.
    /// </summary>
    public static class CampanaService
    {
        private static readonly List<Campana> _campanas = new()
        {
            new() { Id=1,  Nombre="Black Friday Tech",      Categoria="Tecnología", Estado="Vigente",    FechaInicio=new DateTime(2025,11,1),  FechaFin=new DateTime(2025,11,30), DescuentoPct=0.30m, Canal="Web",    Descripcion="Grandes descuentos en laptops, tablets y accesorios." },
            new() { Id=2,  Nombre="Temporada Hogar",        Categoria="Hogar",      Estado="Vigente",    FechaInicio=new DateTime(2025,10,15), FechaFin=new DateTime(2025,12,15), DescuentoPct=0.20m, Canal="Tienda", Descripcion="Renueva tu hogar con muebles y electrodomésticos." },
            new() { Id=3,  Nombre="Fashion Week Lima",      Categoria="Moda",       Estado="Próxima",    FechaInicio=new DateTime(2025,12,1),  FechaFin=new DateTime(2025,12,31), DescuentoPct=0.25m, Canal="App",    Descripcion="Las últimas tendencias en ropa y accesorios de temporada." },
            new() { Id=4,  Nombre="Electro Verano",         Categoria="Electro",    Estado="Próxima",    FechaInicio=new DateTime(2025,12,20), FechaFin=new DateTime(2026,1,20),  DescuentoPct=0.15m, Canal="Web",    Descripcion="Prepárate para el verano con aires acondicionados y ventiladores." },
            new() { Id=5,  Nombre="Cyber Wow 2025",         Categoria="Tecnología", Estado="Finalizada", FechaInicio=new DateTime(2025,6,1),   FechaFin=new DateTime(2025,6,5),   DescuentoPct=0.40m, Canal="Web",    Descripcion="El evento digital más grande del año ya concluyó." },
            new() { Id=6,  Nombre="Vuelta al Cole",         Categoria="Tecnología", Estado="Finalizada", FechaInicio=new DateTime(2025,3,1),   FechaFin=new DateTime(2025,3,31),  DescuentoPct=0.10m, Canal="App",    Descripcion="Útiles y tablets para el inicio del año escolar." },
            new() { Id=7,  Nombre="Navidad Hogar",          Categoria="Hogar",      Estado="Próxima",    FechaInicio=new DateTime(2025,12,10), FechaFin=new DateTime(2025,12,25), DescuentoPct=0.18m, Canal="Tienda", Descripcion="Decora tu hogar para las fiestas navideñas." },
            new() { Id=8,  Nombre="Rebajas de Invierno",    Categoria="Moda",       Estado="Finalizada", FechaInicio=new DateTime(2025,7,1),   FechaFin=new DateTime(2025,7,31),  DescuentoPct=0.35m, Canal="Tienda", Descripcion="Liquidación de temporada invierno en todas las tiendas." },
            new() { Id=9,  Nombre="Super App Day",          Categoria="Electro",    Estado="Vigente",    FechaInicio=new DateTime(2025,11,10), FechaFin=new DateTime(2025,11,25), DescuentoPct=0.22m, Canal="App",    Descripcion="Ofertas exclusivas solo por la aplicación móvil." },
            new() { Id=10, Nombre="Fiestas Patrias Tech",   Categoria="Tecnología", Estado="Finalizada", FechaInicio=new DateTime(2025,7,25),  FechaFin=new DateTime(2025,7,28),  DescuentoPct=0.28m, Canal="Web",    Descripcion="Celebra el Perú con precios especiales en tecnología." },
        };

        public static List<Campana> ObtenerTodas() => _campanas;

        public static Campana? ObtenerPorId(int id) =>
            _campanas.FirstOrDefault(c => c.Id == id);

        public static List<Campana> Filtrar(string? categoria, string? estado)
        {
            var resultado = _campanas.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(categoria))
                resultado = resultado.Where(c => c.Categoria == categoria);
            if (!string.IsNullOrWhiteSpace(estado))
                resultado = resultado.Where(c => c.Estado == estado);
            return resultado.ToList();
        }

        public static ResumenViewModel ObtenerResumen()
        {
            var lista = _campanas;
            return new ResumenViewModel
            {
                Total             = lista.Count,
                Vigentes          = lista.Count(c => c.Estado == "Vigente"),
                Proximas          = lista.Count(c => c.Estado == "Próxima"),
                Finalizadas       = lista.Count(c => c.Estado == "Finalizada"),
                PromedioDescuento = lista.Average(c => c.DescuentoPct),
                PorCanal          = lista.GroupBy(c => c.Canal)
                                        .ToDictionary(g => g.Key, g => g.Count())
            };
        }

        public static List<string> ObtenerCategorias() =>
            _campanas.Select(c => c.Categoria).Distinct().OrderBy(x => x).ToList();

        public static List<string> ObtenerEstados() =>
            _campanas.Select(c => c.Estado).Distinct().OrderBy(x => x).ToList();
    }
}
