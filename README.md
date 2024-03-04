# Presentación prueba técnica Juan David Gómez

Este repositorio contiene la solución para la prueba técnica. Incluye ejercicios, instrucciones y detalles relevantes.


## Instrucciones

1. Clona este repositorio.
2. Abre la solución en Visual Studio 2022
3. Presiona F5 al abrir el proyecto


## Agradecimientos


Estimado equipo de **PersonalSoft**,

Me gustaría expresar mi entusiasmo por la oportunidad de formar parte de su equipo. El hecho de trabajar con ustedes sería un honor y una experiencia enriquecedora. Aunque reconozco que puedo carecer de algunas habilidades específicas requeridas para el cargo, quiero asegurarles que estoy dispuesto(a) a aprender y a dar lo mejor de mí para cumplir con las expectativas.

Estoy comprometido(a) a crecer profesionalmente y a contribuir al éxito de la empresa. Mi pasión por la tecnología y mi deseo de aprender me motivan a enfrentar nuevos desafíos con determinación. Aprecio la posibilidad de aprender prácticas y técnicas avanzadas, y estoy seguro(a) de que puedo adaptarme rápidamente para contribuir al logro de los objetivos del equipo.

Agradezco sinceramente la oportunidad y espero poder demostrar mi valía en el proceso de selección.

¡Gracias por considerar mi candidatura!

## Explicación arquitectura implementada

La arquitectura implementada se basa en la separación de las capas del servicio de acuerdo a su responsabilidad.

El proyecto se divide en dos partes principales:

1.  Un proyecto que contiene todo el código de la aplicación.
2.  Un proyecto dedicado a las pruebas unitarias.

Opté por no utilizar el patrón MVVM, ya que no estaba claro cómo aplicarlo en un servicio REST. Tradicionalmente, el modelo MVVM se asocia más con aplicaciones de escritorio o móviles, mientras que para servicios REST se prefiere otra arquitectura. Me gustaría explorar cómo podría adaptarse este patrón a un servicio REST en el futuro.

La implementación se basa en los principios del patrón CQRS (Command Query Responsibility Segregation) y EDA (Event-Driven Architecture), con un enfoque en los principios SOLID, KISS y DRY.

## Base de datos

Se usó una base de datos relacional en MySQL, los datos de la base de datos son las siguientes:
Host:  pruebapersonalsoft.c5sga0s4go9t.us-east-2.rds.amazonaws.com
Database: MilesCarRental
Port: 3306
User: admin
Pass: root1234

## Diagrama ER base de datos
![Diagrama ER proyecto prueba técnica PersonalSoft](https://github.com/ingjuang/pruebaPersonalSoft/blob/main/Diagrama%20ER%20de%20base%20de%20datos%20Prueba%20PersonalSoft.png?raw=true)
