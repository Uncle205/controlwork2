namespace ControlWork
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PasswordsContext : DbContext
    {
        // Контекст настроен для использования строки подключения "PasswordsContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ControlWork.PasswordsContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "PasswordsContext" 
        // в файле конфигурации приложения.
        public PasswordsContext()
            : base("name=PasswordsContext")
        {
        }
        public DbSet<User> Users { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}