![C#](https://img.shields.io/badge/language-C%23-blue)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8-blue)
![MQTT](https://img.shields.io/badge/MQTT-enabled-green)
![RESTful API](https://img.shields.io/badge/RESTful-API-orange)

# IoT Command Hub

---

## English 

This project uses **MQTT**, **Command Pattern**, and **IoT** to create a system that controls various IoT devices. It implements a **command execution system** where different commands can be executed for devices like lights, TVs, and air conditioners, and these commands are transmitted over **MQTT** to ensure real-time control.

### Technologies Used
- **.NET Core 8**: The backend framework for building the API.
- **MQTT**: For communication between the IoT devices.
- **Command Pattern**: To encapsulate requests as objects, allowing for parameterization of clients with different requests, queuing of requests, and logging the commands.
- **RESTful API**: For external interaction with the system.

### Features
- Control IoT devices like lights, TVs, and air conditioners using commands.
- Real-time communication using MQTT.
- Supports execution and undoing of commands.
- Easy to extend with new devices and commands.

---

## Türkçe 

Bu proje, **MQTT**, **Komut Tasarımı Deseni** ve **IoT** teknolojilerini kullanarak çeşitli IoT cihazlarını kontrol eden bir sistem oluşturur. Bu sistemde, ışıklar, televizyonlar ve klimalar gibi cihazlar için farklı komutlar yürütülür ve bu komutlar **MQTT** üzerinden iletilerek gerçek zamanlı kontrol sağlanır.

### Kullanılan Teknolojiler
- **.NET Core 8**: API oluşturmak için kullanılan backend framework.
- **MQTT**: IoT cihazları arasındaki iletişimi sağlamak için kullanılır.
- **Komut Tasarımı Deseni**: İstemciler için farklı isteklerin parametrizasyonunu, isteklerin kuyruğa alınmasını ve komutların kaydedilmesini sağlayan bir desen.
- **RESTful API**: Sisteme harici olarak etkileşim sağlamak için kullanılır.

### Özellikler
- Işıklar, televizyonlar ve klimalar gibi IoT cihazlarını komutlarla kontrol edebilme.
- MQTT ile gerçek zamanlı iletişim.
- Komutların yürütülmesi ve geri alınması desteği.
- Yeni cihazlar ve komutlar ekleyerek kolayca genişletilebilir.

---

## Deutsch 

Dieses Projekt verwendet **MQTT**, **Command Pattern** und **IoT**, um ein System zu erstellen, das verschiedene IoT-Geräte steuert. Es implementiert ein **Befehlsausführungssystem**, bei dem verschiedene Befehle für Geräte wie Lichter, Fernseher und Klimaanlagen ausgeführt werden können. Diese Befehle werden über **MQTT** übertragen, um eine Echtzeitsteuerung zu gewährleisten.

### Verwendete Technologien
- **.NET Core 8**: Das Backend-Framework zur Erstellung der API.
- **MQTT**: Zur Kommunikation zwischen den IoT-Geräten.
- **Command Pattern**: Um Anforderungen als Objekte zu kapseln, sodass die Clients mit verschiedenen Anforderungen parametriert, Anforderungen in Warteschlangen gestellt und die Befehle protokolliert werden können.
- **RESTful API**: Für die externe Interaktion mit dem System.

### Funktionen
- Steuerung von IoT-Geräten wie Lichtern, Fernsehern und Klimaanlagen mit Befehlen.
- Echtzeitkommunikation mit MQTT.
- Unterstützung der Ausführung und des Rückgängigmachens von Befehlen.
- Einfach erweiterbar mit neuen Geräten und Befehlen.

---

## Español 

Este proyecto utiliza **MQTT**, **Patrón de Comando** e **IoT** para crear un sistema que controla varios dispositivos IoT. Implementa un **sistema de ejecución de comandos** donde se pueden ejecutar diferentes comandos para dispositivos como luces, televisores y acondicionadores de aire, y estos comandos se transmiten a través de **MQTT** para garantizar el control en tiempo real.

### Tecnologías Usadas
- **.NET Core 8**: El framework backend para construir la API.
- **MQTT**: Para la comunicación entre los dispositivos IoT.
- **Patrón de Comando**: Para encapsular solicitudes como objetos, lo que permite la parametrización de clientes con diferentes solicitudes, la cola de solicitudes y el registro de comandos.
- **RESTful API**: Para la interacción externa con el sistema.

### Funcionalidades
- Controlar dispositivos IoT como luces, televisores y aires acondicionados utilizando comandos.
- Comunicación en tiempo real mediante MQTT.
- Soporta la ejecución y reversión de comandos.
- Fácil de extender con nuevos dispositivos y comandos.
