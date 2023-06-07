# Challenge H5 Permissions Services
Muchas gracias por la oportunidad de realizar este reto. A continuación les detallo algunos detalles.

# Caracteristicas de mi PC & Software

PC

- SO Microsoft Windows 10 PRO
- HP ProBook 440 G8 Notebook PC
- 8 RAM
- Procesador	11th Gen Intel(R) Core(TM) i5-1135G7 @ 2.40GHz, 2419 Mhz, 4 procesadores principales, 8 procesadores lógicos
- 500G SSD

Software & Tools

- Visual Studio 2022
- Visual Studio Code
- Docker  4.2.0
- Node Js v16.9.1

# Ejecución del la aplicación

- Clone el repositorio
- Abrir la linea de comandos de su preferencia
- Ubicarse en la raiz de este proyecto
- Ejecutar el siguiente comando docker-compose up --build -d, considere que los siguientes puntos NO este en uso en la maquina local en donde ejecutará este comando: 1433,9200,9300,9092,8088,1443,8089
- Abrir el SqlServer Manager y autentiquese con las siguientes credenciales: Server:Localhost, Tipo Auth: Sql Server Autentication, user: sa, password: PasswordO1.
- Abrir el archivo "ddl.sql" SQLServer Manager y ejecute el script
- Abrir el Browser de su preferencia y escriba "http:localhost:8089/"

# Ejecución de las pruebas

- El docker-compose debe estar previamente ejecutandose, por causa de las pruebas integrales
- Abra el Visual Studio
- Compile la Aplicación
- Ejecute las pruebas ubicadas en:
  N5.PermissionsManager.Domain.UnitTests
  N5.PermissionsManager.IntegrationTests


