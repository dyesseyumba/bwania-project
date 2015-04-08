// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentDomainRepositoryFact.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using BwaniaProject.Entities;
using FluentAssertions;
using MethodTimer;
using Xunit;

namespace bwaniaProject.Data.Test.RepositoryFacts
{
    public class DocumentDomainRepositoryFact
    {
        #region Nested type: TheSave

        public class TheSave : RepositoryDomainFactsBase<IDocumentDomainRepository, Document>
        {
            #region Constructors
            
            public TheSave(IDocumentDomainRepository repository)
                : base(repository)
            {
            }
            #endregion

            #region Methods

            [Fact]
            [Time]
            public async void ShouldReturnsArgumentNullExceptionForNullAsEntity()
            {
                //var t = async () => 

                Repository.SaveAsync(null).ShouldThrow<ArgumentNullException>();
            }

            [Fact]
            [Time]
            public async Task ShouldInsertAsynchronously()
            {
                //Arrange
                var document = BuildEntity<Document>();

                //Act
                var result = await Repository.SaveAsync(document);

                //Assert
                result.Should().BeTrue();
            }

            #endregion
        }

        #endregion
    }
}