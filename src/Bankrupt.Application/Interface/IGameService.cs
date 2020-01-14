﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bankrupt.Application.ViewModel;
using Bankrupt.Domain.Model.Enum;

namespace Bankrupt.Application.Interface
{
    public interface IGameService
    {
        IList<GameResultView> PlayBankrupt(string pathConfig);
        IDictionary<PlayerType, string> GetPlayerTypes();
        int GetMaxRoundsByGame();
        int GetNumberOfGames();
        Task SaveRegisterRound(GameResultRoundRegisters item, CancellationToken token);
    }
}