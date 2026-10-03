# Registro de Gastos

## Descripción

Este proyecto consiste en una aplicación de consola desarrollada en C# que permite llevar un registro sencillo de gastos.

El programa permite agregar gastos, mostrar los gastos registrados, buscar gastos por categoría y guardar la información en un archivo CSV para conservar los datos después de cerrar el programa.

## Funcionalidades

- Agregar un nuevo gasto.
- Asignar un ID automáticamente.
- Registrar descripción, monto y categoría.
- Validar que los datos ingresados sean correctos.
- Listar todos los gastos registrados.
- Calcular el total gastado.
- Buscar gastos por categoría.
- Guardar los datos en un archivo `gastos.csv`.
- Cargar automáticamente los gastos guardados.
- Continuar la numeración de los ID al volver a ejecutar el programa.

## Menú principal

El programa muestra las siguientes opciones:

1. Agregar gasto
2. Listar gastos
3. Buscar por categoría
4. Salir

## Clase Gasto

La clase `Gasto` contiene las siguientes propiedades:

- Id
- Descripcion
- Monto
- Categoria

La clase se encuentra en el archivo `Gasto.cs`.

## Archivos del proyecto

- `Program.cs`: contiene el menú y la lógica principal del programa.
- `Gasto.cs`: contiene la clase Gasto.
- `gastos.csv`: almacena los gastos registrados.
- `README.md`: contiene la información del proyecto.

## Ejemplo

Se pueden registrar gastos como:

- Almuerzo - Q45.50 - Comida
- Gasolina - Q250.00 - Transporte

El programa calcula el total de los gastos registrados.

## Persistencia de datos

Los gastos se guardan en el archivo `gastos.csv`.

Al iniciar nuevamente el programa, los datos son cargados y el ID continúa a partir del último registro existente.

## Tecnología utilizada

- C#
- .NET
- Visual Studio

