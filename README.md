# Hola mundo..!
Este es un proyecto hecho en c# con el frameworks .netCore o supongo ello.
Emplea librerias para la injeccion de dependencias, conexion para la db, interaccion con la base de datos postgresql, este dentro de un contendor de docker pero configurable por medio del link.

> Es innegable el uso de IA dentro del proyecto, esta fue de asistencia y la absolucion de dudas que tuviese durante el desarrollo asi como la sugerencia de carpetas, aunque esto estuve traendo desde java spring.

¿Qué hace exactamente?, pues es un proyecto de consola enfocado en las transacciones de una cuenta A a una cuenta B, se posee la tabla del usuario con todos los datos, una tabla cuenta con los datos del saldo y una cuenta movimiento que registra el historico. Todas creadas con EF (entity framework), esto por medio de comandos que estan en el codigo pero aqui os dejo:

 - `dotnet ef database update`

Cosas a mejorar pues..., manejo de excepciones, lo lleve en spring y es cool, aqui no pude hacerlo, queria algo funcional en poco tiempo y aprender como funciona EntityFrame, ame la injeccion de dependencias; Me gustaria aprener mas sobre `Dbcontext` es interesante como funciona, mapeado de clases y lo que no sabia hasta casi terminar el proyecto, lo que me dio errores, el traking de clases y el save_global.
Otro detalle es la interfaz, debe ser mejor, he visto bibliotecas para hacer programas de consola y uf que son hermosas.

Puede que no sea un gran proyecto pero fue divertido completarlo y terminarlo; si si que es algo tonto porque tengo que crear las cuenta y los usuarios manualmente, me centre en la operacion.

>Detalles antes de subiro (10/05/26), me gusta c# es un buen lenguaje, tomarlo como practica este programilla para aprender logica y pos el uso de clases y sus interfacez, separacion de responsabilidades y creoo que debo borrar muchas funciones, en la ultima revision ya no uso todo el porron de utilidades que use en implementacion.