﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;
using Bankrupt.Application.Resources;
using Bankrupt.Model.Enum;

namespace Bankrupt.Application.Model
{
    public class GameResultView
    {
        [Display(Name = "WinnerType", ResourceType = typeof(GameResultResource))]
        public PlayerType WinnerType { get; set; }
        [Display(Name = "Rounds", ResourceType = typeof(GameResultResource))]
        public int Rounds { get; set; }
        [Display(Name = "TimeOut", ResourceType = typeof(GameResultResource))]
        public bool TimeOut { get; set; }
        [Display(Name = "WinnerType", ResourceType = typeof(GameResultResource))]
        public string WinnerTypeDescription
        {
            get
            {
                switch (WinnerType)
                {
                    case PlayerType.Random:
                        return GameResultResource.PlayerTypeRandom;
                    case PlayerType.Cautious:
                        return GameResultResource.PlayerTypeCautious;
                    case PlayerType.Demanding:
                        return GameResultResource.PlayerTypeDemanding;
                    case PlayerType.Impulsive:
                        return GameResultResource.PlayerTypeImpulsive;
                    default:
                        return GameResultResource.PlayerTypeUndefined;
                }
            }
        }
    }
}
