using System;
using Newtonsoft.Json;

namespace bwaniaProject.Core.Entities
{
    public class EntityBase : IEntity
    {
        #region Fields
        private static string _typeName;
        #endregion

        #region Constructors
        protected EntityBase()
        {
            if (_typeName == null)
            {
                _typeName = GetType().Name;
            }
            Type = _typeName;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the cas.
        /// </summary>
        /// <value>
        /// The cas.
        /// </value>
        public ulong Cas { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        /// <value>
        /// The updated.
        /// </value>
        public DateTime Updated { get; set; }
        #endregion
    }
}
