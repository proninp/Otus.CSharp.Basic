using BenchmarkDotNet.Running;
using HomeWork02;

var summary = BenchmarkRunner.Run<CollectionsBenchmark>(new QuickBenchmarkConfig());