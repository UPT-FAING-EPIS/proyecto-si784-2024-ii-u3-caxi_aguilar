[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/x1Nq8_Zo)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=17489091)
# Informe Proyecto Sistema de Asistencia
## Pruebas de Interfaz
Las pruebas de interfaz se realizan utilizando Playwright y están enfocadas en validar la interacción del usuario con la aplicación.

* Objetivos de las Pruebas de Interfaz
    - Verificar que los elementos clave de la interfaz se carguen correctamente.
    - Validar que las acciones del usuario (como iniciar sesión, navegar entre menús, y llenar formularios) funcionen según lo esperado.
    - Asegurar que los mensajes de error y validación se muestren de manera adecuada.
    - Comprobar que los datos de sesión y rutas redireccionen correctamente.

* Herramientas Utilizadas
    - Microsoft Playwright: Para automatizar y ejecutar las pruebas de interfaz.
    - NUnit: Framework para estructurar las pruebas.

* Casos de Prueba
    1. Página de Inicio (HomePage)

    - Verificar que el título principal se muestra correctamente.
    - Validar que se muestren la fecha y hora actualizadas.
    - Comprobar que el botón "Iniciar Sesión" redirige correctamente a la página de inicio de sesión.

    2. Página de Inicio de Sesión (LoginPage)

    - Validar el comportamiento del formulario de inicio de sesión:
        - Campos vacíos generan mensajes de error: Completa este campo o Please fill out this field.
        - Inicio de sesión exitoso redirige al dashboard.
    - Verificar que la funcionalidad de mostrar/ocultar contraseña funciona correctamente.

    3. Panel de Control (Dashboard)

    - Validar que se muestra el mensaje de bienvenida correcto.
    - Comprobar que el menú lateral contiene todas las opciones necesarias (Sincronizar, Horarios, Asistencias, Justificaciones).
    - Asegurar que cada opción del menú lateral navega correctamente a la sección correspondiente.

    4. Mensajes de Validación

    - Confirmar que los mensajes de error son consistentes y se muestran en español o inglés, según el contexto.

* Ejecución de las Pruebas

    - Para ejecutar las pruebas localmente, asegúrate de tener las herramientas necesarias instaladas y sigue estos pasos:

    - Configura el entorno de desarrollo:
        Instala los navegadores necesarios con Playwright:
```
    npx playwright install
```
   - Correr la aplicación
```
    npm run start
```
![image](https://github.com/user-attachments/assets/224ad41f-6064-4af4-a358-ed87cd9cb32f)

   - Ejecuta las pruebas:
```
dotnet test
```
Genera el reporte de pruebas: Un archivo HTML con los resultados de las pruebas se genera automáticamente en la carpeta videos del proyecto. Este archivo incluye videos de las pruebas ejecutadas.

Pruebas realizadas correctamente:
![image](https://github.com/user-attachments/assets/b687e061-e1ad-485a-b053-803979dba603)

Videos de las pruebas realizadas:
![image](https://github.com/user-attachments/assets/d4efa661-2c10-4cd1-a4cc-6eadfc3650a1)

Página con los videos de las pruebas:
![image](https://github.com/user-attachments/assets/8d75dbd1-296f-4455-92bb-654a8334840d)



