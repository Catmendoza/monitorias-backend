# Monitorias Backend
![monitorias](https://firebasestorage.googleapis.com/v0/b/files-f91c4.appspot.com/o/Mockup2.jpg?alt=media&token=cd7dff57-c44c-446d-9666-2bfefcf63bc5)

## Descripción del proyecto
Este proyecto sirve para llevar un control de las monitorias de la Universidad Santiago de Cali. La plataforma cuenta con tres roles de usuario (administrador, usuario normal, monitor) donde el usuario administrado puede crear monitorias, editarlas o eliminarlas, también puede crear convertir usuarios en monitores y asignarles monitorias creadas. El usuario normal puede ver las monitorias que están disponibles y apuntarse a ellas, también pueden ver un horario donde aparecen las monitorias a las cuales se han apuntado. Este es realizado con Blazor de dotnet y se conecta a una API hecha con web-api de dotnet. Repositorio de la API: https://github.com/Catmendoza/monitorias-backend

## Pasos para correr el proyecto:
1. Clonar el repositorio del proyecto ```git clone https://github.com/Catmendoza/monitorias-backend.git```
2. Tener instalado dotnet. https://dotnet.microsoft.com/download
3. Tener instalado mongodb. https://docs.mongodb.com/manual/administration/install-community/
4. Ejecutar el comando ```mongod``` Para prender la base de datos de mongodb.
5. En otra terminal ejecutar el comando ```dotnet run --urls=http://localhost:8080/``` en la carpeta donde tengas el proyecto.
6. ¡Listo!
