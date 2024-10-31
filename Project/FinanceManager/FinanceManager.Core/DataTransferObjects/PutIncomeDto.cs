﻿using FinanceManager.Core.DataTransferObjects.Abstractions;
using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects;
public sealed class PutIncomeDto : PutEntryDto
{
    public override Income ToModel()
    {
        return new Income
        {
            Id = Id,
            Amount = Amount,
            Description = Description,
        };
    }
}