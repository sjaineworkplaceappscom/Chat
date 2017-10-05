using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ewApps.Chat.Common;
using ewApps.CommonRuntime.Entity;

namespace ewApps.Chat.OfDataService {

 public class ChatDataServiceFactory {

   /// <summary>
   /// Provides a data service handler to perform related operation for TEntity type.
   /// </summary>
   /// <typeparam name="TEntity">The type of entity.</typeparam>
   /// <param name="entityType">A EntityType enum value corresponding to given entity type.</param>
   /// <returns>
   /// Returns a data handler object for TEntity type.
   /// </returns>
   /// <remarks>
   /// If mapping for data handler is not found for TEntity, null reference is returned.
   /// </remarks>
   public static object GetDataService<TEntity>(ChatEntityType entityType) where TEntity : BaseEntity, new() {
     return GetDataService<TEntity>(entityType, false);
   }

   /// <summary>
   /// Provides a data service handler to perform related operation for TEntity type and ignore security(accroding to parameter value).
   /// </summary>
   /// <typeparam name="TEntity">The type of entity.</typeparam>
   /// <param name="entityType">EntityType enum value corresponding to given entity type.</param>
   /// <param name="ignoreSecuriy">if set to <c>true</c> [ignore securiy].</param>
   /// <returns>
   /// Returns a data handler instance for TEntity type.
   /// </returns>
   /// <exception cref="System.Exception">Unknown EDEntity Type</exception>
   /// <remarks>
   /// If mapping for data handler is not found for TEntity, null reference is returned.
   /// </remarks>
   internal static object GetDataService<TEntity>(ChatEntityType entityType, bool ignoreSecuriy) where TEntity : BaseEntity, new() {
     object serviceObject = null;
     switch (entityType) {
     
       default:
         throw new Exception("Unknown Chat Entity Type");
     }

     return serviceObject;
   }

  }
}
