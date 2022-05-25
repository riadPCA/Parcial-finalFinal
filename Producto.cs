using System;
using System.Collections.Generic;
using System.Text;

namespace VentaTienda
{
    class Producto
    {
        private string codigo;
        private string descripcion;
        private int compra;
        private int venta;
        private int cantidad;
        private int cantidadMinima;
        private int cantidadMaxima;
        private static double porcentajeDescuento=0.01;

        public Producto(string codigo,string descripcion, int compra, int venta, int cantidad, int cantidadMinima, int cantidadMaxima)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.compra = compra;
            this.venta = venta;
            this.cantidad = cantidad;
            this.cantidadMinima = cantidadMinima;
            this.cantidadMaxima = cantidadMaxima;
        }

        public string getDescripcion()
        {
            return descripcion;
        }

        public int getCantidad()
        {
            return cantidad;
        }

        public string getCodigo()
        {
            return codigo;
        }

        public int getCantidadMinima()
        {
            return cantidadMinima;
        }

        public int getVenta()
        {
            return venta;
        }

        public int getCompra()
        {
            return compra;
        }

        public int getCantidadMaxima()
        {
            return cantidadMaxima;
        }
        public void SetCantMinima(int minimo)
        {
            if (minimo < 0)
            {
                cantidadMinima = 0;
            }
            else
            {
                cantidadMinima = minimo;
            }
        }

        public void SetCantidad(int cantidad)
        {
            this.cantidad = this.cantidad - cantidad;
        }

        public void VenderProducto(int cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad debe ser mayor a cero\n");
            }
            else if(cantidad>this.cantidad)
            {
                Console.WriteLine("No hay sufiente unidades para la venta\n");
            }
            else
            {
                SetCantidad(cantidad);
                Console.WriteLine("Codigo Producto: " + codigo + ", Producto: " + descripcion + ", Cantidad Vender: " + cantidad + ", Precio Venta: " + venta + " pesos colombianos");
                Console.WriteLine("Precio a pagar sin descuento "+(cantidad*venta)+" pesos colombianos");
                Console.WriteLine("Precio a pagar con descuento " + ((cantidad * venta)-(cantidad * venta* porcentajeDescuento))+" pesos colombianos");
            }
        }

        public bool SolicitarPedido()
        {
            if (cantidad < cantidadMinima) return true;//solicitar al proveedor
            else return false;
        }

        public double TotalPagar(int cantidad)
        {
            return cantidad * compra;
        }

        public static int BuscarCodigo(Producto[] p,string codigo)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].getCodigo().ToLower().Equals(codigo.ToLower()))
                {
                    return i; //existe codigo
                }
            }
            return -1;//no existe codigo
        }

        

        public static void MayorCantidadUnidades(Producto[] p)
        {
            int mayor = -1;
            int pos = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].getCantidad() > mayor)
                {
                    mayor = p[i].getCantidad();
                    pos = i;
                }
            }

            Console.WriteLine("El código del producto con mayor cantidad de unidades actuales es: " + p[pos].getCodigo());
        }

       

    }
}
