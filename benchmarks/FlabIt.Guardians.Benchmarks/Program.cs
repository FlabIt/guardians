using BenchmarkDotNet.Running;

namespace FlabIt.Guardians.Benchmarks
{
    public static class Program
    {
        public static void Main()
        {
            _ = BenchmarkRunner.Run<GuardiansNotNullBenchmarks>();
        }
    }
}