# Проект с общим функционалом
## ModelLibrary
Библиотека с общими моделями нашего проекта, такие как пользователь, устройство, сеть.
## CommonLibrary
Библиотека с более сложным функционалом. Это общие расширения, интерфейсы повсеместно используемых сервисов и так далее.
## RabbitLibrary
Библиотека с реализацией сервисов для отправки и приема сообщений. Интерфейсы этих сервисов указаны в CommonLibrary.
Для того, чтобы Rabbit корректно работал, в конфигурации надо указать очереди, которые мы будем прослушивать, и конечные точки, в которые мы будем отправлять сообщения (будь то Queue или Exchange).
### Пример конфигурации Rabbit-а в BackendService
При таком конфиге возможно отправить сообщение в 1 из 2 точек: "BackendAll" или "BackendMonitoring".
```
{
  /* Ваши прочие настройки */
  "Listeners": {
    "RabbitMQ": {
      "Endpoints": {
        "MonitoringBackend": {
          "HostName": "localhost",
          "VirtualHost": "OtusProjectHost",
          "UserName": "guest",
          "Password": "guest",
          "Queue": "MonitoringBackend"
        },
        "UsersBackend": {
          "HostName": "localhost",
          "VirtualHost": "OtusProjectHost",
          "UserName": "guest",
          "Password": "guest",
          "Queue": "AuthorizationBackend"
        }
      }
    }
  },
  "Senders": {
    "RabbitMQ": {
      "Endpoints": {
        "BackendAll": {
          "HostName": "localhost",
          "VirtualHost": "OtusProjectHost",
          "UserName": "guest",
          "Password": "guest",
          "Queue": "",
          "Exchange": "BackendAll"
        },
        "BackendMonitoring": {
          "HostName": "localhost",
          "VirtualHost": "OtusProjectHost",
          "UserName": "guest",
          "Password": "guest",
          "Queue": "BackendMonitoring",
          "Exchange": ""
        }
      }
    }
  }
}
```
