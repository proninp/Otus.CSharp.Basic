﻿using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace HomeWork02;
public class QuickBenchmarkConfig : ManualConfig
{
    public QuickBenchmarkConfig()
    {
        AddJob(Job.Default
            .WithIterationCount(5)
            .WithWarmupCount(1));

        AddLogger(ConsoleLogger.Default);
        AddExporter(MarkdownExporter.Default);
        AddColumnProvider(DefaultColumnProviders.Instance);
    }
}
