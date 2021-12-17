namespace Sev1.UserFiles.Contracts.Enums

{
    /// <summary>
    /// Тип хранилища
    /// </summary>
    public enum UserFileStorageType
    {
        /// <summary>
        /// Файл хранится в файловой системе сервера
        /// </summary>
        FileSystem,
        /// <summary>
        /// Файл хранится в БД
        /// </summary>
        DataBase,
        /// <summary>
        /// Файл хранится в облаке
        /// </summary>
        Cloud
    }
}