// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidatorFactory.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using Catel;
using FluentValidation;

namespace BwaniaProject.Domain.Validation
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        #region Fields

        /// <summary>
        ///     The service locator
        /// </summary>
        private readonly IServiceContainer _serviceContainer;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidatorFactory" /> class.
        /// </summary>
        /// <param name="serviceContainer">The service locator.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="serviceContainer" /> is <c>null</c>.</exception>
        public ValidatorFactory(IServiceContainer serviceContainer)
        {
            Argument.IsNotNull("serviceLocator", serviceContainer);
            _serviceContainer = serviceContainer;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates the instance.
        /// </summary>
        /// <param name="validatorType">Type of the validator.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The <paramref name="validatorType" /> is <c>null</c>.</exception>
        public override IValidator CreateInstance(Type validatorType)
        {
            Argument.IsNotNull("validatorType", validatorType);

            return _serviceContainer.GetService(validatorType) as IValidator;
        }

        #endregion
    }
}