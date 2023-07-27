# nuevaAppInventario
NET. 7.0, Aplicación de WebApi NETCore, Se tomo como guía el prioyectoInventario ya creado anteriormente en el cual se implementa Entity Framework API, Migraciones y conexión a base de datos y creación de entidades y sus respectivas configuraciones en C# Csharp. Creación de Interfaces y repositorios e implementación de Dtos.

Pero para este Nuevo Proyecto se va a implementar la aplicación de interfaces y repositorios Genéricos al igual que una entidad Base, con el fin de evitar escribir mucho código

=> se agrego codigo para realizar un numero maximo de peticiones en un determinado tiempo
=> ademas se agrego o se genero codigo para llevar el control de versiones de los Endpoint implementados 

1. Cosas ya realizadas:
=> se realizo el CRUD para las entidades de Pais y estado Implementando sus Dtos

=> se adiciono nuevos metodos que permiten ver el numero de paginas que contiene un registro de la base de datos asi como tambien una expresion LINQ para encontrar un determinado pais (para este caso como ejemplo para la entidad pais), asi como tambien tener un control de las verciones ejecutadas para los Enpoint para las diferentes entidades

2. cosa por terminar:
=> El CRUD para las demas entidades  y la creacion de sus Dtos y la implementacion de las versiones y la paginacion de sus regitros. 