# Practica MVC .Net

## Descripción
Este proyecto tiene como objetivo poner en práctica la arquitectura MVC utilizando el marco de desarrollo .Net, se utilizó HTML, CSS y JS puros y para el backend se utilizó el lenguaje C#. A continuación, se listarán la funcionalidades de la aplicación.

- Podrá agregar usuarios
- Podrá agregar cargos
- Podrá visualizar usuarios y cargos
- Podra filtrar usuarios por cargos

## Pasos para ejecutar

1. Clonar el repositorio utilizando el siguiente comando
```
git clone https://github.com/juanjmorelos/.net_mvc_practice.git
```
2. Dirijase a la carpeta `database` y descargue el archivo `employee_database.sql`, que contiene las tablas de la base de datos utilizada.

3. Cree una base de datos (en MySQL Workbench o phpMyAdmin), se recomienda utilizar el nombre `employee_database` e importe los datos que allí se encuentran. Cabe recalcar que se utilizó el gestor de base de datos relacionales MySQL

Si cambia el nombre, usuario o contraseña de la base de datos prosiga con el paso 4, de lo contrario continue al paso 5

4. Dirijase al archivo `controller/SQLController.cs` y actualicé los datos segun sea necesario por el nombre que le proporcionó a la base de datos de la siguiente forma:
```c#
public class SqlController {
    private static string server = "localhost"; //aquí debe poner el dominio del servidor
    private static string port = "3306"; //aquí debe poner el nuevo puerto
    private static string user = "root"; //aquí debe poner el nuevo usuario
    private static string password = ""; //aquí debe poner la nueva contraseña
    private static string dbName = "employee_database"; //aquí debe poner el nombre nuevo de la base de datos
    private static string conectUrl = "server=" + server + "; port=" + port + "; user id=" + user + "; password=" + password + "; database=" + dbName + ";";

    /* Más código */
```

5. Para ejecutar el proyecto asegúrese de estar en la carpeta `app`, si no esta puede usar el siguiente comando
```shell
cd app
```
y luego ejecutar el proyecto usando el siguiente comando
```shell
dotnet run
```
