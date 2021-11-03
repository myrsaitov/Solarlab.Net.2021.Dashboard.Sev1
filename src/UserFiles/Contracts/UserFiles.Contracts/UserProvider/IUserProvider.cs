namespace UserFiles.Contracts.UserProvider
{
    /// <summary>
    /// Возвращает Id текущего пользователя
    /// </summary>
    public interface IUserProvider
    {
        /// <summary>
        /// Возвращает Id текущего пользователя
        /// </summary>
        /// <returns></returns>
        string GetUserId();

        /// <summary>
        /// Возвращает роли пользователя
        /// </summary>
        /// <returns></returns>
        string[] GetUserRoles();

        /// <summary>
        /// Проверяет роль
        /// </summary>
        /// <returns></returns>
        bool IsInRole(string role);
    }
}
