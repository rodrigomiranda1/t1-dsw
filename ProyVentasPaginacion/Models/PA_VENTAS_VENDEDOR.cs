namespace ProyVentasPaginacion.Models
{
    public class PA_VENTAS_VENDEDOR
    {
        public string num_vta { get; set; } = "";
        public DateTime fec_vta { get; set; }
        public string cod_cli { get; set; } = "";
        public string nom_cli { get; set; } = "";
        public int cred_cli { get; set; }
        public decimal tot_vta { get; set; }

    }
}
