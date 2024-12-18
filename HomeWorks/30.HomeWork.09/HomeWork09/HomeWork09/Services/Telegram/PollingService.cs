using HomeWork09.Abstract;
using Serilog;

namespace HomeWork09.Services.Telegram;
public class PollingService(IServiceProvider serviceProvider, IUpdateEventProvider eventProvider, ILogger logger)
    : PollingServiceBase<ReceiverService>(serviceProvider, eventProvider, logger);
