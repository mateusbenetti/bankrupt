﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Bankrupt.Application.Interface;
using Bankrupt.Application.Resources;
using Bankrupt.Application.ViewModel;
using Bankrupt.Domain.Interface;
using Bankrupt.Domain.Model;
using Bankrupt.Domain.Model.Enum;
using Bankrupt.Domain.Model.Interface;

namespace Bankrupt.Application.Service
{
    public class GameService : IGameService
    {
        private const int NumberOfGames = 300;
        private const int MaxRound = 1000;
        private readonly IGameDomain _domain;
        private readonly IMapper _mapper;
        public GameService(IMapper mapper, IGameDomain domain)
        {
            _domain = domain;
            _mapper = mapper;
        }

        public IList<GameResultDetailView> GetGameResultDetails(string registerCode)
        {
            var result = new List<GameResultDetailView>();
            return result;
        }

        public int GetMaxRoundsByGame()
        {
            return MaxRound;
        }

        public int GetNumberOfGames()
        {
            return NumberOfGames;
        }

        public IDictionary<PlayerType, string> GetPlayerTypes()
        {
            var playerTypes = new Dictionary<PlayerType, string>
            {
                { PlayerType.Impulsive, GameResultResource.PlayerTypeImpulsive },
                { PlayerType.Demanding, GameResultResource.PlayerTypeDemanding },
                { PlayerType.Cautious, GameResultResource.PlayerTypeCautious },
                { PlayerType.Random, GameResultResource.PlayerTypeRandom }
            };
            return playerTypes;
        }

        public IList<GameResultView> PlayBankrupt(string pathConfig)
        {
            string registerCode = BuildRegisterCode();
            IList<GameResultView> result = new List<GameResultView>();
            for (var i = 0; i < NumberOfGames; i++)
            {
                IDictionary<int, IPlayer> players = new Dictionary<int, IPlayer>
                {
                    { 1, new ImpulsivePlayer() },
                    { 2, new DemandingPlayer() },
                    { 3, new CautiousPlayer() },
                    { 4, new RandomPlayer() }
                };
                var game = _domain.StartGame(players, pathConfig, MaxRound, registerCode);
                _domain.LetsPlay(game);
                _domain.FinishGame(game, MaxRound);
                result.Add(_mapper.Map<GameResultView>(game.Result));
            }
            return result;
        }
        private string BuildRegisterCode()
        {
            string registerCode = "BKRPT0000" + DateTime.Now.Year.ToString("0000") +
                DateTime.Now.Month.ToString("00") +
                DateTime.Now.Day.ToString("00") +
                DateTime.Now.Hour.ToString("00") +
                DateTime.Now.Minute.ToString("00") +
                DateTime.Now.Second.ToString("00");
            return registerCode;
        }
    }
}