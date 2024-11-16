using BenchmarkDotNet.Running;
using HomeWork07;

var summary = BenchmarkRunner.Run<FibonacciBenchmark>(new QuickBenchmarkConfig());