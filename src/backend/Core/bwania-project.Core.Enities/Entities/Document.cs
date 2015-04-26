// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Document.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace BwaniaProject.Entities
{
    /// <summary>
    /// </summary>
    public class Document : EntityBase, IDocument
    {
        public Document()
        {
            Commentaires = new List<ICommentaire>();
        }

        /// <summary>
        ///     Gets or sets the titre.
        /// </summary>
        /// <value>
        ///     The titre.
        /// </value>
        public string Titre { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the domaine.
        /// </summary>
        /// <value>
        ///     The domaine.
        /// </value>
        public string Domaine { get; set; }

        /// <summary>
        ///     Gets or sets the discipline.
        /// </summary>
        /// <value>
        ///     The discipline.
        /// </value>
        public string Discipline { get; set; }

        /// <summary>
        ///     Gets or sets the fichier.
        /// </summary>
        /// <value>
        ///     The fichier.
        /// </value>
        public byte[] Fichier { get; set; }

        /// <summary>
        ///     Gets or sets the date of publication.
        /// </summary>
        /// <value>
        ///     The date of publication.
        /// </value>
        public DateTime DateDePublication { get; set; }

        /// <summary>
        ///     Gets or sets the date of modification.
        /// </summary>
        /// <value>
        ///     The date of modification.
        /// </value>
        public DateTime DateModification { get; set; }

        /// <summary>
        ///     Gets or sets the mot cle.
        /// </summary>
        /// <value>
        ///     The mot cle.
        /// </value>
        public List<string> MotCle { get; set; }

        /// <summary>
        ///     Gets or sets the niveau.
        /// </summary>
        /// <value>
        ///     The niveau.
        /// </value>
        public string Niveau { get; set; }

        /// <summary>
        ///     Gets or sets the number of consultation.
        /// </summary>
        /// <value>
        ///     The number of consultation.
        /// </value>
        public long NbConsultation { get; set; }

        /// <summary>
        ///     Gets or sets the number of etoile.
        /// </summary>
        /// <value>
        ///     The nnumber etoile.
        /// </value>
        public long NbEtoile { get; set; }

        /// <summary>
        ///     Gets or sets the nnumber of vote.
        /// </summary>
        /// <value>
        ///     The number of vote.
        /// </value>
        public int NbVote { get; set; }

        /// <summary>
        ///     Gets or sets the "moyenne etoile".
        /// </summary>
        /// <value>
        ///     The "moyenne etoile".
        /// </value>
        public int MoyenneEtoile { get; set; }

        /// <summary>
        ///     Gets or sets the "niveau difficulte".
        /// </summary>
        /// <value>
        ///     The "niveau difficulte".
        /// </value>
        public string NiveauDifficulte { get; set; }

        /// <summary>
        ///     Gets or sets the commentaire.
        /// </summary>
        /// <value>
        ///     The commentaire.
        /// </value>
        public List<ICommentaire> Commentaires { get; set; }
    }
}