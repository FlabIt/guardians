using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace FlabIt.Guardians.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net50)]
    [MemoryDiagnoser]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Not catching could break benchmark. Exception value not needed.")]
    public class GuardiansNotNullBenchmarks
    {
        [Params("test", null)]
        public string TestArgument { get; set; }

        #region Benchmark executors

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithNoGuard(string argument) => _ = argument.Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithManualGuard(string argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }

            _ = argument.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithFlabIt(string argument)
        {
            global::FlabIt.Guardians.GenericGuardiansExtension.ThrowIfNull(argument, nameof(argument));

            _ = argument.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithArdalis(string argument)
        {
            global::Ardalis.GuardClauses.GuardClauseExtensions.Null(global::Ardalis.GuardClauses.Guard.Against, argument, nameof(argument));

            _ = argument.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithDawnGuard(string argument)
        {
            global::Dawn.Guard.NotNull(global::Dawn.Guard.Argument(argument, nameof(argument)));

            _ = argument.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithDefender(string argument)
        {
            global::Defender.Guard.NotNull(argument, nameof(argument));

            _ = argument.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithGuard(string argument)
        {
            global::Guards.Guard.ArgumentNotNull(argument, nameof(TestArgument));

            _ = argument.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithGuardExpression(string argument)
        {
            global::Guards.Guard.ArgumentNotNull(() => argument);

            _ = argument.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RunWithLiteGuard(string argument)
        {
            global::LiteGuard.Guard.AgainstNullArgument(nameof(argument), argument);

            _ = argument.Length;
        }

        #endregion Benchmark executors

        #region Benchmarks

        /// <summary>
        /// Benchmark for an unguarded call.
        /// </summary>
        [Benchmark]
        public void Unguarded()
        {
            try
            {
                RunWithNoGuard(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for a manually guarded call.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void ManuallyGuarded()
        {
            try
            {
                RunWithManualGuard(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for guard with FlabIt.Guardians.
        /// </summary>
        [Benchmark]
        public void FlabIt()
        {
            try
            {
                RunWithFlabIt(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for guard with Ardalis.
        /// </summary>
        [Benchmark]
        public void Ardalis()
        {
            try
            {
                RunWithArdalis(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for guard with Dawn.Guard.
        /// </summary>
        [Benchmark]
        public void DawnGuard()
        {
            try
            {
                RunWithDawnGuard(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for guard with Defender.
        /// </summary>
        [Benchmark]
        public void Defender()
        {
            try
            {
                RunWithDefender(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for guard with Guard.
        /// </summary>
        [Benchmark]
        public void Guard()
        {
            try
            {
                RunWithGuard(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for guard with Guard using expression syntax.
        /// </summary>
        [Benchmark]
        public void GuardExpression()
        {
            try
            {
                RunWithGuardExpression(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        /// <summary>
        /// Benchmark for guard with LiteGuard.
        /// </summary>
        [Benchmark]
        public void LiteGuard()
        {
            try
            {
                RunWithLiteGuard(TestArgument);
            }
            catch (Exception)
            {
                // Keep BenchmarkDotNet from discarding the results
            }
        }

        #endregion Benchmarks
    }
}