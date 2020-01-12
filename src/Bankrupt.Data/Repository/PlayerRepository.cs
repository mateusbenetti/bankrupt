using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Enum;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Bankrupt.Data.Model.Repository
{
    public class PlayerRepository : Repository<PlayerInfo>, IPlayerRepository
    {
        public PlayerRepository(BankruptContext bankruptContext, IConfiguration configuration) 
            : base(bankruptContext, configuration)
        {
        }

        public override string EntityName => "Players";

        public PlayerInfo GetPlayer(PlayerTypeEnum playerTypeEnum)
        {
            int playerType = GetPlayerType(playerTypeEnum);
            var playerInfo = new PlayerInfo();
            var parameters = new DynamicParameters();
            parameters.Add("@Type", playerType);      
            playerInfo = GetFirstOrDefault("SELECT * FROM Players WHERE Type = @Type", parameters) ?? new PlayerInfo() { Type = PlayerTypeEnum.None };
            return playerInfo;
        }

        private int GetPlayerType(PlayerTypeEnum playerTypeEnum)
        {
            switch (playerTypeEnum)
            {
                case PlayerTypeEnum.None:
                    return 0;
                case PlayerTypeEnum.Random:
                    return 1;
                case PlayerTypeEnum.Impulsive:
                    return 2;
                case PlayerTypeEnum.Cautious:
                    return 3;
                case PlayerTypeEnum.Demanding:
                    return 4;
                default:
                    return 0;
            }
        }
    }
}