## Sistema de registro de tutorias
Este sistema se realizo con la finalidad de hacer un registro en excel de deportistas de una foma sencilla y clara
### Como registrar a un deportista
+ Se da clic al documento de ejecutarRegistro.bat
![Alt text](imagenes/image2.png)
+ Se llenan los datos
+ Y se da clic guardar
![Alt text](imagenes/image.png)
### Como ver el excel
+ Da clic al documento verBaseDeDatos.bat
![Alt text](imagenes/image-1.png)
+ Y inmediatamente se abrira excel con la base de datos
### Cosas a tomar en cuenta
+ Al registrar un nuevo deportista el excel no debe de tener el documento abierto, se arrogara una excepción controlada en ese caso y no se registrar el deportista
+ Se recomienda realizar una migración hacia una base de datos centralizada en SQL. En el sistema actual, se basa en un único archivo de Excel compartido a través de un dispositivo de almacenamiento compartido. Esta configuración presenta desafíos, como la falta de normalización de datos y la posibilidad de conflictos en caso de que haya múltiples copias del programa con información crítica. Además, existen preocupaciones de seguridad, ya que cualquier usuario con acceso al programa puede modificar, visualizar o eliminar el documento de Excel que contiene información valiosa.
+ Todos los valores deben de ser llenado exceptuando el num interior para poder hacer un registro
+ Este sistema no valida duplicidad de datos en el excel sale del alcance del sistema