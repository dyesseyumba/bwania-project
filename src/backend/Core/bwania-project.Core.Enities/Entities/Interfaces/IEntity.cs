namespace bwaniaProject.Core.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the cas.
        /// </summary>
        /// <value>
        /// The cas.
        /// </value>
        ulong Cas { get; set; }
    }
}