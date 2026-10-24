Prueba Técnica ASP.NET Web Forms
Descripción
Aplicación desarrollada en ASP.NET Web Forms (.NET Framework 4.8) que permite consultar empresas disponibles por canal consumiendo un servicio REST.

La configuración de cada canal se obtiene desde SQL Server mediante un Stored Procedure.

Componentes
Sitio Web
Proyecto Web Forms encargado de:

Consultar configuración de canal.
Consumir API REST.
Mostrar empresas.
Manejar sesiones.
Mostrar/ocultar menú según configuración obtenida de la base de datos.
Redireccionar a página destino.


API REST
Servicio Web API encargado de:

Validar API Key.
Devolver empresas disponibles por canal.
Simular errores.
Simular timeout.


Base de Datos
SQL Server.

Contiene:

Tabla ConfiguracionCanal
Stored Procedure SP_ObtenerConfiguracionCanal
Stored Procedure sp_getMenuCanal


Tecnologías utilizadas
ASP.NET Web Forms
ASP.NET Web API
VB.NET
ADO.NET
SQL Server
IIS Express
HttpClient
Session State
Configuración
Base de datos
Ejecutar los scripts ubicados en el archivo DB Canales.sql:

Los scripts estan en el orden de ejecución requerido

API
La API esta contenida dentro de la solución principal
se debe asegurar que la solucion ejecute multiples proyectos a la vez para poder proceder con las pruebas

Propiedades de la solución:

Multiple Startup Projects
Servicios      Start
ServiciosAPI   Start


Casos de prueba

Canal AB
Empresas.aspx?canal=AB
Resultado esperado:

Menú visible.

Empresas cargadas correctamente.


Canal CJ
Empresas.aspx?canal=CJ
Resultado esperado:

Menú oculto.

Empresas cargadas correctamente.

Canal inexistente
Empresas.aspx?canal=XX
Resultado esperado:

Mensaje controlado.

Timeout


Empresas.aspx?canal=LENTO
Resultado esperado:

Mensaje de timeout.

Registro en log.


Error interno
Empresas.aspx?canal=ERROR
Resultado esperado:

Mensaje de error controlado.

Registro en log.

API Key Incorrecta
Empresas.aspx?canal=UNAUTHORIZED
Resultado esperado:

Mensaje de error controlado.

Registro en log.

