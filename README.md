[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/x1Nq8_Zo)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=17489091)

<div align="center">

![./media/media/image1.png](./media/logo-upt.png)

**UNIVERSIDAD PRIVADA DE TACNA**  

**FACULTAD DE INGENIERÍA**  

**Escuela Profesional de Ingeniería de Sistemas**  

**Proyecto _UPT-SYNC: Herramienta de apoyo para estudiantes_**  

Curso: _Calidad y Pruebas de Software_  

Docente: _Mag. Patrick Cuadros Quiroga_  

Integrantes:  

***CAXI CALANI Luis Eduardo (2018062487)***  
***AGUILAR PINTO Victor Eleazar (2018062487)***  

**Tacna – Perú**  

***2024***  

</div>

<div style="page-break-after: always; visibility: hidden">\pagebreak</div>

# **Sistema UPT-SYNC**

## **10. Reportes Generados**

A continuación, se presentan los enlaces a los reportes generados durante el análisis y pruebas de la aplicación **UPT-SYNC**, utilizando diversas herramientas para evaluar la calidad del código, la cobertura de pruebas y la seguridad.

---

### **10.1 Reportes de Cobertura de Pruebas**

1. **Reporte de Cobertura de Pruebas Unitarias:**  
   [Ver Reporte de Cobertura de Pruebas Unitarias](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u2-caxi_aguilar_chata/unit-tests)  
   Este reporte muestra los resultados de las pruebas unitarias realizadas sobre los módulos principales de la aplicación.  
   - **Cobertura Total Alcanzada:** 90%  
   - **Herramienta Utilizada:** Jest  

2. **Reporte de Cobertura de Pruebas de Integración:**  
   [Ver Reporte de Cobertura de Pruebas de Integración](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u2-caxi_aguilar_chata/integration-tests)  
   Este informe detalla los resultados de las pruebas de integración, enfocándose en la interacción entre los diferentes módulos de la aplicación.  
   - **Cobertura Total Alcanzada:** 85%  
   - **Herramienta Utilizada:** Postman  

---

### **10.2 Reportes de Mutaciones y Aceptación**

3. **Reporte de Mutaciones:**  
   [Ver Reporte de Mutaciones](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/mutation-report.html)  
   Evalúa la robustez del código al introducir mutaciones en el mismo y validar la eficacia de las pruebas existentes.  
   - **Propósito:** Identificar posibles fallos en las pruebas automatizadas.

4. **Reporte de Aceptación:**  
   [Ver Reporte de Aceptación](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/LivingDocReport.html)  
   Documenta los escenarios de prueba funcional que validan los requerimientos del usuario final.  
   - **Propósito:** Garantizar que las funcionalidades cumplen con las expectativas del usuario.

---

### **10.3 Reportes de Seguridad**

5. **Reporte de Análisis de Contenedor (Snyk):**  
   [Ver Reporte de Seguridad - Snyk](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/container-test-result.html)  
   Resultado del análisis de vulnerabilidades en las dependencias y contenedores utilizados en el proyecto.  
   - **Herramienta Utilizada:** Snyk  

6. **Reporte de Análisis Estático de Código (Semgrep):**  
   [Ver Reporte de Seguridad - Semgrep](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/semgrep-report.html)  
   Este análisis detecta posibles problemas de seguridad y estándares de código no cumplidos.  
   - **Herramienta Utilizada:** Semgrep  

---

### **Resumen General de Reportes**

| **Reporte**                         | **Propósito**                                   | **Herramienta**      | **Enlace**                                                                 |
|-------------------------------------|-----------------------------------------------|----------------------|---------------------------------------------------------------------------|
| Cobertura de Pruebas Unitarias      | Validar el correcto funcionamiento del código  | Jest                | [Ver Reporte](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u2-caxi_aguilar_chata/unit-tests)  |
| Cobertura de Pruebas de Integración | Evaluar la interacción entre módulos           | Jest, Mocha            | [Ver Reporte](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u2-caxi_aguilar_chata/integration-tests) |
| Reporte de Mutaciones               | Verificar la robustez de las pruebas           | Stryke            | [Ver Reporte](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/mutation-report.html) |
| Reporte de Aceptación               | Validar funcionalidades finales                | LivingDoc           | [Ver Reporte](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/LivingDocReport.html) |
| Reporte de Seguridad (Snyk)         | Detectar vulnerabilidades en dependencias      | Snyk                | [Ver Reporte](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/container-test-result.html) |
| Reporte de Seguridad (Semgrep)      | Identificar problemas en estándares de código  | Semgrep             | [Ver Reporte](https://upt-faing-epis.github.io/proyecto-si784-2024-ii-u3-hernandez_contreras_paja/semgrep-report.html) |

---

**Nota:** Los reportes enlazados están alojados en GitHub Pages y documentan exhaustivamente los análisis y resultados de calidad, seguridad y pruebas implementados en **UPT-SYNC**.  



* Luis Eduardo Caxi Calani
* Victor aguilar Pinto


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



