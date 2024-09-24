using BenchmarkDotNet.Running;
using HomeWork02;

var summary = BenchmarkRunner.Run<CollectionsTestService>(new QuickBenchmarkConfig());