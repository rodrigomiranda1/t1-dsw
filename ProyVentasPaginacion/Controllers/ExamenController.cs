using Microsoft.AspNetCore.Mvc;
using ProyVentasPaginacion.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyVentasPaginacion.Controllers
{
    public class ExamenController : Controller
    {
        string cdn_cnx = "";
        //recuperar la cadena de conexion
        public ExamenController(IConfiguration config)
        {
            cdn_cnx = config.GetConnectionString("cn1")!;
        }

        private List<Vendedor> pa_vendedor()
        {
            var lista = new List<Vendedor>();
            SqlDataReader dr = SqlHelper.ExecuteReader(cdn_cnx, "pa_vendedor");

            while(dr.Read())
            {
                lista.Add(new Vendedor()
                {
                    cod_ven = dr.GetInt32(0),
                    nom_ven = dr.GetString(1)
                });
            }
            dr.Close();

            return lista;
        }

        private List<PA_VENTAS_VENDEDOR> PA_VENTAS_VENDEDOR(int cod_ven)
        {
            var lista = new List<PA_VENTAS_VENDEDOR>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cdn_cnx, "pa_ventas_vendedor", cod_ven);

            while(dr.Read())
            {
                lista.Add(new PA_VENTAS_VENDEDOR()
                {
                    num_vta = dr.GetString(0),
                    fec_vta = dr.GetDateTime(1),
                    cod_cli = dr.GetString(2),
                    nom_cli = dr.GetString(3),
                    cred_cli = dr.GetInt32(4),
                    tot_vta = dr.GetDecimal(5)
                });
            }
            dr.Close();
            return lista;
        }


        public IActionResult GetVentasVendedor(int cod_ven = 0)
        {
            //dropdownlist
            ViewBag.vendedores = new SelectList(pa_vendedor(), "cod_ven", "nom_ven");

            //table
            var listado = PA_VENTAS_VENDEDOR(cod_ven);
            ViewBag.contador = listado.Count;

            return View(listado);
        }
    }
}
