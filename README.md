# Prueba-Tecnica

## 1. Documentación General del Proyecto

### Objetivo General
Evaluar la capacidad para diseñar, implementar y probar un sistema de lavado de autos con gestión de citas utilizando ASP.NET 6, Entity Framework y ASP.NET Identity. La prueba técnica se centrará en la correcta implementación de autenticación, autorización, mantenimiento de datos y la integración efectiva de una API en capas con un proyecto web MVC y una Base de datos SQL SERVER. 

### Contexto del Proyecto
Se requiere el desarrollo de un sistema de gestión de citas para un negocio de lavado de autos. El sistema debe permitir a los clientes programar citas para el lavado de sus vehículos, y a los empleados gestionar y dar seguimiento a estas citas. Se espera que la aplicación tenga una interfaz amigable y segura, con funcionalidades específicas para clientes y empleados. 

## 2. Documentación de Requerimientos Funcionales

### Autenticación y Autorización
Detalla cómo se implementará la autenticación mediante ASP.NET Identity, incluyendo la creación y gestión de roles como "Cliente" y "Empleado" para garantizar la correcta autorización de acceso.

### Gestión de Citas
Define cómo los clientes podrán programar citas y cómo los empleados gestionarán estas citas, marcándolas como completadas.

### Registro de Usuarios
Describe la funcionalidad de la página de inicio de sesión, registro de usuarios, validación de usuarios existentes y recuperación de contraseña.

### Roles y Permisos
Explica los permisos asignados a cada tipo de usuario (clientes, empleados y administradores) y cómo se gestionarán las operaciones CRUD.

### Seguridad
Detalla las medidas de seguridad implementadas, como la comunicación segura mediante HTTPS y la correcta autenticación y autorización antes de acceder a recursos protegidos.

## 3. Documentación de Requerimientos de Base de Datos

### Entidades
Proporciona información detallada sobre las entidades de la base de datos, incluyendo los campos específicos de cada tabla como Cita, Usuario (Cliente) y Tipo de Servicio.

## 4. Documentación de Evaluación de Requerimientos Técnicos

### Configuración del Proyecto API
Explica cómo crear un proyecto API en ASP.NET y configurar ASP.NET Identity para gestionar la autenticación de usuarios.

### Modelo de Datos
Detalla la definición de modelos de datos para representar entidades clave en el sistema, como "Citas", "Clientes", "Vehículos", etc.

### Operaciones CRUD
Explica cómo se implementarán las operaciones CRUD con validaciones exitosas para la gestión de citas.

### Roles y Autorización
Define roles como "Cliente" y "Empleado" y explica cómo se asignarán permisos específicos a cada tipo de usuario.

### JWT para Autenticación
Describe la implementación de la generación y validación de tokens JWT para la autenticación de usuarios y cómo se utilizan para autorizar solicitudes al API.

### Integración con Proyecto Web MVC
Explica cómo crear un proyecto web MVC para que los clientes programen citas, asegurando que la autenticación y autorización funcionen correctamente al consumir el API.

### Interfaz de Usuario Amigable
Detalla la implementación de una interfaz de usuario amigable para clientes y empleados en el proyecto web MVC, incluyendo el uso de Ajax, jQuery, Bootstrap y diseño responsive.

## 5. Documentación de Entregables Esperados

### Código Fuente del Proyecto API y Web MVC
Proporciona instrucciones claras para acceder y comprender el código fuente de ambos proyectos.

### Documentación Estructural y de Decisiones de Diseño
Incluye una guía detallada sobre la estructura del proyecto y las decisiones de diseño tomadas durante la implementación.

### Script de Creación de Base de Datos
Proporciona un script SQL que permita crear la base de datos con las tablas y relaciones definidas.

### Repositorio en GitHub
Explica cómo acceder al repositorio en GitHub que contiene todos los elementos del proyecto, incluyendo el código fuente y la documentación.

## 6. Documentación de Observaciones

### Tiempo de Entrega
Enfatiza la importancia del tiempo de entrega para la evaluación técnica, proporcionando pautas claras sobre la identificación del nivel y dominio de las tecnologías utilizadas.
