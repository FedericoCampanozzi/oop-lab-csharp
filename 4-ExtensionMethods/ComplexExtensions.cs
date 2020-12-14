using System;

namespace ExtensionMethods
{
    /// <summary>
    /// The static class declares extension methods for complex numbers.
    /// </summary>
    public static class ComplexExtensions
    {
        /// <summary>
        /// Add two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the sum.</returns>
        public static IComplex Add(this IComplex c1, IComplex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        /// <summary>
        /// Substract <paramref name="c2"/> from <paramref name="c1"/>.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the difference.</returns>
        public static IComplex Subtract(this IComplex c1, IComplex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        /// <summary>
        /// Multiply two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the product.</returns>
        public static IComplex Multiply(this IComplex c1, IComplex c2)
        {
            double a = c1.Real;
            double b = c1.Imaginary;
            double c = c2.Real;
            double d = c2.Imaginary;

            return new Complex(a * c - b * d, a * d + b * c);
        }

        /// <summary>
        /// Divide two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the quotient.</returns>
        public static IComplex Divide(this IComplex c1, IComplex c2)
        {
            double a = c1.Real;
            double b = c1.Imaginary;
            double c = c2.Real;
            double d = c2.Imaginary;
            double den = c * c + d * d;

            return new Complex((a * c + b * d) / den, (b * c - a * d) / den);
        }

        /// <summary>
        /// Get the complex conjugate of a complex number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The complex conjugate of a complex number is the number with an equal real part
        /// and an imaginary part equal in magnitude, but opposite in sign.
        /// </para>
        /// </remarks>
        /// <param name="c1">the complex operand.</param>
        /// <returns>the complex conjugate.</returns>
        public static IComplex Conjugate(this IComplex c1)
        {
            return new Complex(c1.Real, -c1.Imaginary);
        }

        /// <summary>
        /// Get the reciprocal of a complex number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The multiplicative inverse (or reciprocal) of a complex number is a number,
        /// that when multiplied with that complex number, gives an answer of 1.
        /// </para>
        /// </remarks>
        /// <param name="c1">the complex operand.</param>
        /// <returns>the complex reciprocal.</returns>
        public static IComplex Reciprocal(this IComplex c1)
        {
            double den = c1.Real * c1.Real + c1.Imaginary * c1.Imaginary;
            return new Complex(c1.Real / den, -c1.Imaginary / den);
        }
    }
}
