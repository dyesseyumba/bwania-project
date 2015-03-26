using System;
using System.Collections.Generic;

namespace bwaniaProject.Core.Entities
{
    public interface IDocument : IEntity
    {
        /// <summary>
        /// Gets or sets the titre.
        /// </summary>
        /// <value>
        /// The titre.
        /// </value>
        string Titre { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the domaine.
        /// </summary>
        /// <value>
        /// The domaine.
        /// </value>
        string Domaine { get; set; }

        /// <summary>
        /// Gets or sets the discipline.
        /// </summary>
        /// <value>
        /// The discipline.
        /// </value>
        string Discipline { get; set; }

        /// <summary>
        /// Gets or sets the fichier.
        /// </summary>
        /// <value>
        /// The fichier.
        /// </value>
        byte[] Fichier { get; set; }

        /// <summary>
        /// Gets or sets the date de publication.
        /// </summary>
        /// <value>
        /// The date de publication.
        /// </value>
        DateTime DateDePublication { get; set; }

        /// <summary>
        /// Gets or sets the date modification.
        /// </summary>
        /// <value>
        /// The date modification.
        /// </value>
        DateTime DateModification { get; set; }

        /// <summary>
        /// Gets or sets the mot cle.
        /// </summary>
        /// <value>
        /// The mot cle.
        /// </value>
        List<string> MotCle { get; set; }

        /// <summary>
        /// Gets or sets the niveau.
        /// </summary>
        /// <value>
        /// The niveau.
        /// </value>
        string Niveau { get; set; }

        /// <summary>
        /// Gets or sets the nb consultation.
        /// </summary>
        /// <value>
        /// The nb consultation.
        /// </value>
        long NbConsultation { get; set; }

        /// <summary>
        /// Gets or sets the nb etoile.
        /// </summary>
        /// <value>
        /// The nb etoile.
        /// </value>
        long NbEtoile { get; set; }

        /// <summary>
        /// Gets or sets the nb vote.
        /// </summary>
        /// <value>
        /// The nb vote.
        /// </value>
        int NbVote { get; set; }

        /// <summary>
        /// Gets or sets the "moyenne etoile".
        /// </summary>
        /// <value>
        /// The "moyenne etoile".
        /// </value>
        int MoyenneEtoile { get; set; }

        /// <summary>
        /// Gets or sets the "niveau difficulte".
        /// </summary>
        /// <value>
        /// The "niveau difficulte".
        /// </value>
        string NiveauDifficulte { get; set; }
    }
}