# Monitorias Backend
![monitorias](https://firebasestorage.googleapis.com/v0/b/files-f91c4.appspot.com/o/Mockup2.jpg?alt=media&token=cd7dff57-c44c-446d-9666-2bfefcf63bc5)

## Descripción del proyecto
Este proyecto es una API hecha con web-api de dotnet la cual se encarga de recibir las peticiones http realizadas por el frontend del proyecto (https://github.com/JuandaGarcia/frontend-monitorias) el cual sirve para llevar un control de las monitorias de la Universidad Santiago de Cali. La plataforma cuenta con tres roles de usuario (administrador, usuario normal, monitor) donde el usuario administrador puede crear monitorias, editarlas o eliminarlas, también puede crear convertir usuarios en monitores y asignarles monitorias creadas. El usuario normal puede ver las monitorias que están disponibles y apuntarse a ellas, también pueden ver un horario donde aparecen las monitorias a las cuales se han apuntado.

## Integrantes
- Catalina Mendoza
- Juan Jose Castro
- Juan David García Rincón

## Explicación Técnica
Esta aplicación de monitorias en la parte del back end se desarrolló una WebApi con MongoDB y se tiene unos modelos con unos atributos requeridos para guardar y validar la información en la base de datos. También se desarrolló controladores para configurar las peticiones http (get, post, put, delete) que se solicitan desde el front end. Y se creó unos servicios para conectarse con la base de datos. 
En el front end de esta aplicación se utilizó Blazor para desarrollar una SPA “single-page-application” y basar la aplicación en componentes para tener un mejor rendimiento. También se utilizó la librería System.Net.Http.Json en la versión 3.2.1 para realizar las consultas http de la API desde el front end.

![monitorias](https://firebasestorage.googleapis.com/v0/b/files-f91c4.appspot.com/o/Frame%206.png?alt=media&token=fe82f14a-75a3-4ad5-ab12-e08a9907342c)
![monitorias](https://firebasestorage.googleapis.com/v0/b/files-f91c4.appspot.com/o/WhatsApp%20Image%202020-11-27%20at%2012.04.27%20AM.jpeg?alt=media&token=ecea5a1f-bec6-4b85-85eb-9126810d47c4)




![monitorias](https://firebasestorage.googleapis.com/v0/b/files-f91c4.appspot.com/o/WhatsApp%20Image%202020-11-26%20at%2011.46.43%20PM.jpeg?alt=media&token=a41ec26e-886c-4a6e-9854-3b9ecab72150)

## Pasos para correr el proyecto:
1. Clonar el repositorio del proyecto ```git clone https://github.com/Catmendoza/monitorias-backend.git```
2. Tener instalado dotnet. https://dotnet.microsoft.com/download
3. Tener instalado mongodb. https://docs.mongodb.com/manual/administration/install-community/
4. Ejecutar el comando ```mongod``` Para prender la base de datos de mongodb.
5. En otra terminal ejecutar el comando ```dotnet run --urls=http://localhost:8080/``` en la carpeta donde tengas el proyecto.
6. ¡Listo!
