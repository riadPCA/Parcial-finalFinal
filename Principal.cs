using System;

namespace VentaTienda
{
    class Principal
    {
        static void Main(string[] args)
        {
            int cantMinima,cantidad;
            string codigo,tipoProducto;
            string msj = "";
            int opMenu;
            int pos;
            Calzado[] calzados;
            PrendaVestir[] prendas;
            int cantidadCalzado = PedirCantidad("Ingrese cantidad de calzados para la bodega: ");
            int cantidadPrendas = PedirCantidad("Ingrese cantidad de prendas para la bodega: ");
            calzados = new Calzado[cantidadCalzado];
            prendas = new PrendaVestir[cantidadPrendas];
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            PedirDatos(calzados,cantidadCalzado, 1);
            PedirDatos(prendas,cantidadPrendas, 2);

            do
            {
                opMenu = Menu();
                switch (opMenu)
                {
                    case 1: 
                        for(int i=0; i< cantidadCalzado; i++)
                        {
                            if (calzados[i].SolicitarPedido())
                            {
                                msj += "Solicitar pedido al proveedor el calzado: " + calzados[i].getDescripcion() +", Cantidad Actual: "+calzados[i].getCantidad()+", Cantidad Mínima: "+calzados[i].getCantidadMinima()+ "\n";
                            }
                        }

                        for (int i = 0; i < cantidadPrendas; i++)
                        {
                            if (prendas[i].SolicitarPedido())
                            {
                                msj += "Solicitar pedido al proveedor la prenda de vestir: " + prendas[i].getDescripcion() + ", Cantidad Actual: " + prendas[i].getCantidad() + ", Cantidad Mínima: " + prendas[i].getCantidadMinima() + "\n";
                            }
                        }

                        if (msj.Equals(""))
                        {
                            Console.WriteLine("No hay productos a socilitar");
                        }
                        else
                        {
                            Console.WriteLine(msj);
                        }
                        break;
                    case 2:
                        Calzado.MostrarProductos(calzados);
                        Console.WriteLine();
                        Producto.MayorCantidadUnidades(calzados);
                        break;
                    case 3:
                        PrendaVestir.MostrarProductos(prendas);
                        Console.WriteLine();
                        Producto.MayorCantidadUnidades(prendas);
                        break;
                    case 4:

                        tipoProducto = MenuTipoProducto();
                        
                        do
                        {
                            try
                            {
                                Console.Write("Ingrese cantidad de unidades minima: ");
                                cantMinima = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("Valor ingresado incorrecto, ingrese nuevamente\n");
                            }
                        } while (true);


                        if (tipoProducto.Equals("calzado")){
                            Calzado.MostrarProductos(calzados);
                            
                            Console.Write("\nIngrese código del producto: ");
                            codigo = Console.ReadLine();

                            pos = Producto.BuscarCodigo(calzados, codigo);
                            if (pos == -1)//no existe codigo
                            {
                                Console.WriteLine("No existe codigo ingresado\n");
                            }
                            else
                            {
                                calzados[pos].SetCantMinima(cantMinima);
                                Console.WriteLine("Se modificó la cantidad mínima");
                                Console.WriteLine("Código: " + calzados[pos].getCodigo() + ", Nombre: " + calzados[pos].getDescripcion() + ", Cantidad Mínima: " + calzados[pos].getCantidadMinima());
                            }
                        }
                        else
                        {
                            PrendaVestir.MostrarProductos(prendas);

                            Console.Write("\nIngrese código del producto: ");
                            codigo = Console.ReadLine();

                            pos = Producto.BuscarCodigo(prendas, codigo);
                            if (pos == -1)//no existe codigo
                            {
                                Console.WriteLine("No existe codigo ingresado\n");
                            }
                            else
                            {
                                prendas[pos].SetCantMinima(cantMinima);
                                Console.WriteLine("Se modificó la cantidad mínima");
                                Console.WriteLine("Código: "+ prendas[pos].getCodigo()+", Nombre: "+prendas[pos].getDescripcion()+", Cantidad Mínima: "+ prendas[pos].getCantidadMinima());
                            }
                        }
                        break;
                    case 5:
                        Console.Write("Ingrese código del producto: ");
                        codigo = Console.ReadLine();
                        tipoProducto = MenuTipoProducto();
                        cantidad = PedirCantidad("Ingrese cantidad de unidades a vender: ");

                        if (tipoProducto.Equals("calzado"))
                        {
                            pos = Producto.BuscarCodigo(calzados, codigo);
                            if (pos == -1)//no existe codigo
                            {
                                Console.WriteLine("No existe codigo ingresado\n");
                            }
                            else
                            {
                                calzados[pos].VenderProducto(cantidad);
                            }
                        }
                        else
                        {
                            pos = Producto.BuscarCodigo(prendas, codigo);
                            if (pos == -1)//no existe codigo
                            {
                                Console.WriteLine("No existe codigo ingresado\n");
                            }
                            else
                            {
                                prendas[pos].VenderProducto(cantidad);
                            }
                        }

                        break;
                    case 6:
                        Console.WriteLine("Hasta Pronto, que tenga un buen día");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta, ingrese nuevamente\n");
                        break;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            } while (opMenu!=6);
        }

        static void PedirDatos(Producto[] productos, int total, int opcion)
        {
            string codigo,descripcion;
            int compra, venta;
            int cantidad, cantMin, cantMax;
            int tallaCalzado;
            string tallaPrenda;
            bool permitePlanchado;

            for (int i = 0; i < productos.Length; i++)
            {
                if (opcion == 1)
                {
                    Console.WriteLine("CALZADO "+(i + 1));
                }
                else
                {
                    Console.WriteLine("PRENDA DE VESTIR " + (i + 1));
                }

                Console.Write("Ingrese código: ");
                codigo = Console.ReadLine();

                Console.Write("Ingrese nombre: ");
                descripcion = Console.ReadLine();
                compra = PedirCantidad("Ingrese precio de Compra: ");
                venta = PedirCantidad("Ingrese precio de Venta: ");
                cantidad = PedirCantidad("Ingrese cantidad: ");
                cantMin = PedirCantidad("Ingrese cantidad mínima: ");
                cantMax = PedirCantidad("Ingrese cantidad máxima: ");
                if (opcion == 1)//calzando
                {
                    tallaCalzado = PedirCantidad("Ingrese talla de calzado: ");
                    productos[i] = new Calzado(codigo, descripcion, compra, venta, cantidad, cantMin, cantMax, tallaCalzado);
                    Console.WriteLine("Calzado agregado exitosamente");
                }
                else//prenda
                {
                    tallaPrenda = MenuTallaPrenda();
                    permitePlanchado = MenuPlanchado();
                    productos[i] = new PrendaVestir(codigo, descripcion, compra, venta, cantidad, cantMin, cantMax, tallaPrenda, permitePlanchado);
                    Console.WriteLine("Prenda de vestir agregado exitosamente");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        static int PedirCantidad(string msj)
        {
            int cantidad;
            do
            {
                try
                {
                    Console.Write(msj);
                    cantidad = int.Parse(Console.ReadLine());
                    if (cantidad <= 0)
                    {
                        Console.WriteLine("La cantidad debe ser mayor a cero\n");
                    }
                    else
                    {
                        return cantidad;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Valor ingresado incorrecto, ingrese nuevamente\n");
                }
            } while (true);
        }

        static bool MenuPlanchado()
        {
            int planchado;
            do
            {
                try
                {
                    Console.WriteLine("\n|-----------------------|");
                    Console.WriteLine("|   PERMITE PLANCHADO   |");
                    Console.WriteLine("|-----------------------|");
                    Console.WriteLine("| 1.- Si                |");
                    Console.WriteLine("| 2.- No                |");
                    Console.WriteLine("|-----------------------|");
                    Console.Write("Seleccione opción: ");
                    planchado = int.Parse(Console.ReadLine());
                    if (planchado == 1) return true;
                    if (planchado == 2) return false;
                    Console.WriteLine("Opción incorrecta, ingrese nuevamente\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Valor ingresado incorrecto, ingrese nuevamente\n");
                }
            } while (true);
        }

        static string MenuTipoProducto()
        {
            int tipo;
            do
            {
                try
                {
                    Console.WriteLine("\n|--------------------------|");
                    Console.WriteLine("|     TIPO PRODUCTO       |");
                    Console.WriteLine("|-------------------------|");
                    Console.WriteLine("| 1.- Calzado             |");
                    Console.WriteLine("| 2.- Prenda              |");
                    Console.WriteLine("|-------------------------|");
                    Console.Write("Seleccione tipo: ");
                    tipo = int.Parse(Console.ReadLine());
                    if (tipo == 1) return "calzado";
                    if (tipo == 2) return "prenda";
                    Console.WriteLine("Opción incorrecta, ingrese nuevamente\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Valor ingresado incorrecto, ingrese nuevamente\n");
                }
            } while (true);
        }

        static string MenuTallaPrenda()
        {
            string talla;
            do
            {
                try
                {
                    Console.WriteLine("\n|-------------------|");
                    Console.WriteLine("|  TALLA DE PRENDA  |");
                    Console.WriteLine("|-------------------|");
                    Console.WriteLine("| S.- Talla Small   |");
                    Console.WriteLine("| P.- Talla Pequeña |");
                    Console.WriteLine("| M.- Talla Mediano |");
                    Console.WriteLine("| L.- Talla Grande  |");
                    Console.WriteLine("| XL.- Extra Grande |");
                    Console.WriteLine("|-------------------|");
                    Console.Write("Seleccione talla: ");
                    talla = Console.ReadLine();
                    talla = talla.ToUpper();
                    if(talla.Equals("S") || talla.Equals("P") || talla.Equals("M") || talla.Equals("L")|| talla.Equals("XL"))
                    {
                        return talla;
                    }
                    else
                    {
                        Console.WriteLine("Opción incorrecta, ingrese nuevamente\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Valor ingresado incorrecto, ingrese nuevamente\n");
                }
            } while (true);
        }

        static int Menu()
        {
            int op;
            do
            {
                try
                {
                    Console.WriteLine("|---------------------------------------------------|");
                    Console.WriteLine("|                  MENU DE OPCIONES                 |");
                    Console.WriteLine("|---------------------------------------------------|");
                    Console.WriteLine("| 1.- Verificar Producto                            |");
                    Console.WriteLine("| 2.- Calzado con mayor cantidad de unidades        |");
                    Console.WriteLine("| 3.- Prenda con mayor cantidad de unidades         |");
                    Console.WriteLine("| 4.- Modificar cantidad minima requerida en bodega |");
                    Console.WriteLine("| 5.- Vender Producto                               |");
                    Console.WriteLine("| 6.- Salir                                         |");
                    Console.WriteLine("|---------------------------------------------------|");
                    Console.Write("Seleccione opción: ");
                    op = int.Parse(Console.ReadLine());
                    return op;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Valor ingresado incorrecto, ingrese nuevamente\n");
                }
            } while (true);
        }
    }
}
