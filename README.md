# Proyecto para el control de asistencia y calificaciones en una escuela primaria

_Como parte de un proyecto universitario este software permite tener el control de calificaciones y asistencias de una escuela primaria_
_Así como la generación de reportes PDF y EXCEL_

## Comenzando 🚀

_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._


### Pre-requisitos 📋

* Necesitarás tener instalado **Visual Studio 2019** _(también lo puedes abrir en el 2017)_ con **Net Framework 4.7.2** o superior.
* Para ejecutar los scripts de base de datos necesitarás **MySQL 8.0** o superior.


### Instalación 🔧

* Abre **Visual Studio 2019** selecciona **Clonar un repositorio** y pega la siguiente URL
```
https://github.com/Alexxlml/Proyecto-Calificaciones
```
* Selecciona la ruta donde se guardará el proyecto y listo.

* Para agregar la base de datos, el procedimiento almacenado y el script de registro
* Abre Workbench abre tu instancia local y después abre los archivos y ejecutalos en ese orden:

**Boletas.sql**
**Registros_boletas.sql**
**procedimiento_porcentajes.sql**

Para abrirlo en consola usa los siguientes comandos (adaptalos a tu información)
```
mysql -u nom-usr -p base-dato
```

```
source script.sql;
```

* Por último al abrir la solucion en VS2019 abre la opción **Editar** del menú superior, después **Buscar y reemplazar**, por último selecciona **Reemplazar en archivos**
* Pega esta línea en el primer espacio:
```
"Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m"
```

En el segundo espacio copia y pega la misma pero cambiando el valor de **Password**
```
"Server=localhost; Port=3306; User id=root; Database=boletas; Password=tucontraseña"
```

## Ejecutando las pruebas ⚙️

Para probar el programa inicialo y utiliza las siguientes credenciales para probar las funciones

**Director**
* U: alex@outlook.com
* P: 1234

**Maestro** 
* U: alda@outlook.com
* P: 0000

## Construido con 🛠️

* [Visual Studio 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)
* [MySQL 8.0](https://dev.mysql.com/downloads/installer/)


## Autores ✒️

* **Alexis Zacarias** - *Trabajo Inicial* - [Alexxlml](https://github.com/Alexxlml)
* **Kevin Meléndez** - *Apoyo en base de datos y lógica de programación*

## Expresiones de Gratitud 🎁

Gracias por esta plantilla de README a [Villanuevand](https://github.com/Villanuevand) 😊
