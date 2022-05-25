using System;
using System.Collections.Generic;

using System.Text;

namespace VentaTienda
{
    class PrendaVestir:Producto
    {
        private string talla;
        private bool permitePlanchado;
        public PrendaVestir(string codigo,string descripcion, int compra, int venta, int cantidad, int cantidadMinima, int cantidadMaxima, string talla, bool permitePlanchado) :base(codigo, descripcion, compra, venta, cantidad,cantidadMinima,cantidadMaxima)
        {
            this.talla = talla;
            this.permitePlanchado = permitePlanchado;
        }

        public static void MostrarProductos(PrendaVestir[] p)
        {
            string planchado = "";
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].permitePlanchado == true) planchado = "si";
                else planchado = "no";
                Console.WriteLine("Código: " + p[i].getCodigo() + ", Producto: " + p[i].getDescripcion() + ", Cantidad Actual: " + p[i].getCantidad() +
                    ", Cantidad Mínima: " + p[i].getCantidadMinima() + ", Cantidad Máxima: " + p[i].getCantidadMaxima() + ", Talla: " + p[i].talla+", Permite Plancahado: "+planchado);
            }
        }
    }
}
