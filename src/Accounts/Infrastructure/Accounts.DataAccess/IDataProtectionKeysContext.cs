using Microsoft.EntityFrameworkCore;

namespace Sev1.Accounts.DataAccess
{
    
    /// <summary>
    /// Interface used to store instances of <see cref="DataProtectionKey"/> in a <see cref="DbContext"/>
    /// //https://github.com/dotnet/aspnetcore/blob/main/src/DataProtection/EntityFrameworkCore/src/IDataProtectionKeyContext.cs
    /// </summary>
    public interface IDataProtectionKeysContext
    {
        /// <summary>
        /// A collection of <see cref="DataProtectionKey"/>
        /// </summary>
        DbSet<DataProtectionKey> DataProtectionKeys { get; }
    }
}