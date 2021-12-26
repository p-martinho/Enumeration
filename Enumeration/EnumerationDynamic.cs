namespace PM.Enumeration
{
    /// <summary>
    /// A base class to create enumeration classes with dynamic value.
    /// </summary>
    /// <typeparam name="T">The type that is inheriting from this class.</typeparam>
    public abstract class EnumerationDynamic<T> : Enumeration<T> where T : EnumerationDynamic<T>, new()
    {
        /// <summary>
        /// Initializes a new instance of the class <see cref="EnumerationDynamic{T}"/>.
        /// </summary>
        protected EnumerationDynamic()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the class <see cref="EnumerationDynamic{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        protected EnumerationDynamic(string value) : base(value)
        {
        }

        /// <summary>
        /// Gets the instance of type <see cref="T"/> that has the specified value, or, if not found, a new instance with the specified value.
        /// </summary>
        /// <param name="value">The value of the instance to get or to create.</param>
        /// <returns>
        /// The instance of type <see cref="T"/> with the specified value, or <c>null</c> if not found.
        /// </returns>
        public static T GetFromValueOrNew(string value)
        {
            return GetFromValueOrDefault(value) ?? new T { Value = value };
        }
    }
}