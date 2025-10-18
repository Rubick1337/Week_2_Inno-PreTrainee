# Week_2_Inno-PreTrainee

Перед запуском создать базу данных под названием Inno_Course (пример есть в файле appsettings.json), затем запустить приложение и запустяться миграции с созданием таблицы и тестовых данных

### Application (Слой приложения)

- **Handler** - Обработчики ошибок
  - `ExceptionHandler.cs` -  обработка исключений 

- **Services** - Сервисы приложения
  - **Config** - Работа с конфигурацией
    - `ConfigReader.cs` - Чтение конфигурации
  - **Console** - Сервисы ввода-вывода
    - `ConsoleInputService.cs` - Сервис для чтения пользовательского ввода
    - `ConsoleOutputService.cs` - Сервис для вывода информации в консоль
  - **Tasks** - Сервисы задач
    - `TaskDisplayService.cs` - Сервис для отображения задач в консоли
    - `TaskManager.cs` - Менеджер задач
    - `TaskOperationService.cs` - Сервис операций с задачами
    - `UserInteractionTaskService.cs` - Сервис взаимодействия с пользователем для работы с задачами

- **UI** - Пользовательский интерфейс
  - `Menu.cs` - меню приложения

- **Validator** - Валидация ввода
  - `InputValidator.cs` - Валидатор пользовательского ввода

### Core (Ядро приложения)

- **Entities** - Сущности предметной области
  - `Task.cs` - Сущность задачи

- **Factories** - Фабрики
  - `DatabaseConnectionFactory.cs` - Абстрактная фабрика для создания подключений к БД

- **Interfaces** - Контракты и интерфейсы
  - `DatabaseConnection.cs` - Интерфейс подключения к базе данных
  - `InputService.cs` - Интерфейс сервиса ввода
  - `OutputService.cs` - Интерфейс сервиса вывода
  - `Repository.cs` - Интерфейс репозитория для работы с данными

- **Services** - Бизнес-логика
  - `TaskService.cs` - Сервис бизнес-логики для работы с задачами

### Infrastructure (Инфраструктурный слой)

- **Data** - Работа с данными
  - **Factories** - Фабрики БД
    - `SqlServerFactory.cs` - Фабрика для создания подключений к SQL Server
  - **Products** - Реализации БД
    - `SqlServer.cs` - Реализация подключения к SQL Server

- **Migrations** - Миграции базы данных
  - `CreateTableTasks.cs` - Миграция для создания таблицы задач
  - `InsertTestData.cs` - Миграция для добавления тестовых данных
  - `RunMigrations.cs` - Запуск всех миграций

- **Repository** - Репозитории данных
  - `RepositoryBase.cs` - Базовый репозиторий с общей логикой
  - `SqlServerTaskRepository.cs` - Репозиторий для работы с задачами
  
- **Services** - Сервисы инфраструктуры
  - `TaskService.cs` - Сервис для работы с задачами 

- `appsettings.json` - Файл конфигурации приложения с настройками подключения к БД
