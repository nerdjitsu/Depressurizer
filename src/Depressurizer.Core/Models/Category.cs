﻿using System;

namespace Depressurizer.Core.Models
{
    /// <summary>
    ///     Class representing a single Category.
    /// </summary>
    /// <inheritdoc />
    public class Category : IComparable
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Creates a category object.
        /// </summary>
        /// <param name="name">
        ///     Name of the category.
        /// </param>
        public Category(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Number of apps in the category.
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        ///     Name of the category.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is Category otherCategory))
            {
                throw new ArgumentException("Object is not a Category");
            }

            if (Name.Equals(otherCategory.Name, StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            if (Name.Equals("favorite", StringComparison.OrdinalIgnoreCase))
            {
                return -1;
            }

            if (otherCategory.Name.Equals("favorite", StringComparison.OrdinalIgnoreCase))
            {
                return 1;
            }

            int value = string.Compare(Name, otherCategory.Name, StringComparison.OrdinalIgnoreCase);
            if (value != 0)
            {
                return value;
            }

            return Count.CompareTo(otherCategory.Count);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
