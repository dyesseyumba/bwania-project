using System;

namespace bwaniaProject.Entities
{
    public class Commentaire : EntityBase, ICommentaire
    {
        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        public string designation { get; set; }

        /// <summary>
        /// Gets or sets the date ajout.
        /// </summary>
        /// <value>
        /// The date ajout.
        /// </value>
        public DateTime dateAjout { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string userId { get; set; }
    }
}