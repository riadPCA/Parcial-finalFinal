using System;
using System.Collections.Generic;
using System.Text;

namespace VentaTienda
{
    class Calzado:Producto
    {
        private int talla;
        public Calzado(string codigo,string descripcion, int compra, int venta, int cantidad, int cantidadMinima, int cantidadMaxima, int talla) : base(codigo, descripcion, compra, venta, cantidad, cantidadMinima, cantidadMaxima)
        {
            this.talla = talla;
        }

        public int getTalla()
        {
            return talla;
        }

        public static void MostrarProductos(Calzado[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine("Código: " + p[i].getCodigo() + ", Producto: " + p[i].getDescripcion() + ", Cantidad Actual: "+p[i].getCantidad()+
                    ", Cantidad Mínima: "+ p[i].getCantidadMinima()+", Cantidad Máxima: "+ p[i].getCantidadMaxima()+", Talla: "+ p[i].getTalla());
            }
        }

    }
}
