namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entMenu
    {
        public int IdMenu { get; set; }
        public string? Nombre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
        public int IdMenuPadre { get; set; }
        public List<entMenu>? ListaMenu { get; set; }

    }
}
