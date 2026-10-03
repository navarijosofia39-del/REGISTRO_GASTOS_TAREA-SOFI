using System;
using System.Collections.Generic;
using System.IO;

namespace RegistroGastos
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Gasto> gastos = new List<Gasto>();
            int siguienteId = 1;
            int opcion;

            CargarGastos(gastos, ref siguienteId);

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        AgregarGasto(gastos, ref siguienteId);
                        break;

                    case 2:
                        ListarGastos(gastos);
                        break;

                    case 3:
                        BuscarPorCategoria(gastos);
                        break;

                    case 4:
                        GuardarGastos(gastos);
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 4);
        }


        private static int LeerOpcionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== REGISTRO DE GASTOS ===");
            Console.WriteLine("1. Agregar gasto");
            Console.WriteLine("2. Listar gastos");
            Console.WriteLine("3. Buscar por categoría");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");

            int opcion;
            int.TryParse(Console.ReadLine(), out opcion);

            return opcion;
        }


        private static void AgregarGasto(
            List<Gasto> gastos,
            ref int siguienteId)
        {
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            Console.Write("Monto: ");
            string textoMonto = Console.ReadLine();

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine();

            decimal monto;

            if (!decimal.TryParse(textoMonto, out monto) ||
                monto <= 0 ||
                string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            Gasto nuevoGasto = new Gasto();

            nuevoGasto.Id = siguienteId;
            nuevoGasto.Descripcion = descripcion;
            nuevoGasto.Monto = monto;
            nuevoGasto.Categoria = categoria;

            gastos.Add(nuevoGasto);

            siguienteId++;

            Console.WriteLine("Gasto agregado.");
        }


        private static void ListarGastos(List<Gasto> gastos)
        {
            decimal total = 0;

            for (int i = 0; i < gastos.Count; i++)
            {
                Console.WriteLine(gastos[i]);

                total = total + gastos[i].Monto;
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL GASTADO: Q {total:F2}");
        }


        private static void BuscarPorCategoria(List<Gasto> gastos)
        {
            Console.Write("Categoría a buscar: ");
            string categoria = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < gastos.Count; i++)
            {
                if (gastos[i].Categoria.ToLower() ==
                    categoria.ToLower())
                {
                    Console.WriteLine(gastos[i]);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron gastos.");
            }
        }


        private static void GuardarGastos(List<Gasto> gastos)
        {
            List<string> lineas = new List<string>();

            for (int i = 0; i < gastos.Count; i++)
            {
                string linea =
                    gastos[i].Id + ";" +
                    gastos[i].Descripcion + ";" +
                    gastos[i].Monto + ";" +
                    gastos[i].Categoria;

                lineas.Add(linea);
            }

            File.WriteAllLines("gastos.csv", lineas);
        }


        private static void CargarGastos(
            List<Gasto> gastos,
            ref int siguienteId)
        {
            if (!File.Exists("gastos.csv"))
            {
                return;
            }

            string[] lineas = File.ReadAllLines("gastos.csv");

            for (int i = 0; i < lineas.Length; i++)
            {
                string[] datos = lineas[i].Split(';');

                if (datos.Length == 4)
                {
                    int id;
                    decimal monto;

                    bool idValido =
                        int.TryParse(datos[0], out id);

                    bool montoValido =
                        decimal.TryParse(datos[2], out monto);

                    if (idValido && montoValido)
                    {
                        Gasto gasto = new Gasto();

                        gasto.Id = id;
                        gasto.Descripcion = datos[1];
                        gasto.Monto = monto;
                        gasto.Categoria = datos[3];

                        gastos.Add(gasto);

                        if (id >= siguienteId)
                        {
                            siguienteId = id + 1;
                        }
                    }
                }
            }

            Console.WriteLine(
                $"Cargados {gastos.Count} gastos desde gastos.csv.");
        }
    }
}