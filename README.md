# Week_2_Inno-PreTrainee
Перед запуском создать базу данных под названием Inno_Course(пример есть в файле appsettings.json), затем запустить приложение и запустяться миграции с созданием таблицы и тестовых данных

- **Application**(Консольное приложение)
  - `Handlers/` - Обработчики ошибок (ErrorHandler.cs)
  - `Services/` - Сервисы для консольного приложения (ConfigReader, TaskManager)
  - `UI/` - Пользовательский интерфейс (Menu)
  - `Validator/` - Валидация ввода пользователя (InputValidator)

- **Core** (Ядро приложения)
  - `Entities/` - Сущности предметной области
  - `Factories/` - Абстракная Фабрика подключения (DatabaseConnectionFactory)
  - `Interfaces/` - Контракты (IDataBaseConnection, Repository)

- **Infrastructure** (Инфраструктурный слой)
  - `Data/`
    - `Factories/` - Фабрики БД (SqlServerFactory)
    - `Products/` - Реализации БД (SqlServer)
    - `Migrations/` - Миграции БД и метод запуска миграции
  - `Repository/` - Репозитории (RepositoryBase, SqlServerTaskRepository)
  - `Services/` - Сервисы инфраструктуры (TaskService)

  - `appsettings.json` - Конфигурация
