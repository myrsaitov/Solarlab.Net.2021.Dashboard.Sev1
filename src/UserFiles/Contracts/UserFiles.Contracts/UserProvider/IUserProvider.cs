namespace UserFiles.Contracts.UserProvider
{
    /// <summary>
    /// Возвращает Id и роли авторизированного пользователя
    /// </summary>
    public interface IUserProvider
    {
        /// <summary>
        /// Возвращает Id авторизированного пользователя
        /// </summary>
        /// <returns></returns>
        string GetUserId();

        /// <summary>
        /// Возвращает роли авторизированного пользователя
        /// </summary>
        /// <returns></returns>
        string[] GetUserRoles();

        /// <summary>
        /// Проверяет, есть ли указанная роль у авторизированного пользователя
        /// </summary>
        /// <param name="role">Роль, которая проверяется</param>
        /// <returns></returns>
        bool IsInRole(string role);
    }
}
