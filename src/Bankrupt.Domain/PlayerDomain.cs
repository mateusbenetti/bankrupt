using System;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Domain.Interface;
using Bankrupt.Domain.Model;
using Bankrupt.Domain.Model.Interface;

namespace Bankrupt.Domain
{
    public class PlayerDomain : IPlayerDomain
    {

        public void Play(IPlayer player, BoardGame boardGame, Guid gameId)
        {
            string action = "";
            var boardHouseBefore = player.CurrentBoardHouse;
            int coinsBefore = player.Coins;
            var diceNumber = DiceRoll(boardGame);
            Walk(player, boardGame, diceNumber);
            if (player.CurrentBoardHouse.Owner != null)
            {
                action = "Pagou Aluguel na Casa " + player.CurrentBoardHouse.Sequential;
                PayBoardHouseRent(player, player.CurrentBoardHouse);
            }
            else
            {
                var playerHasCash = player.Coins >= player.CurrentBoardHouse.PurchaseValue;
                if (playerHasCash && player.WantBuy)
                {
                    action = "Comprou Casa " + player.CurrentBoardHouse.Sequential;
                    BuyBoardHouse(player, player.CurrentBoardHouse);
                }
                else
                {
                    action = "Parou na Casa " + player.CurrentBoardHouse.Sequential;
                }
            }
            var boardHouseAfter = player.CurrentBoardHouse;
            int coinsAfter = player.Coins;
            RegisterRoundActivity(player, boardGame, boardHouseBefore, boardHouseAfter, coinsBefore, coinsAfter, action, gameId);
            if (player.Coins < 0)
                LostGame(player);
        }

        private void RegisterRoundActivity(IPlayer player,
            BoardGame boardGame, BoardHouse boardHouseBefore, BoardHouse boardHouseAfter,
            int coinsBefore, int coinsAfter, string action, Guid gameId)
        {
            boardGame.RoundRegisters.Add(new BoardGameRoundRegister()
            {
                BoardGameId = gameId,
                Player = player,
                BoardHouseAfter = boardHouseAfter.Sequential,
                BoardHouseBefore = boardHouseBefore.Sequential,
                CoinsAfter = coinsAfter,
                CoinsBefore = coinsBefore,
                Action = action
            });
        }

        private static int DiceRoll(BoardGame boardGame)
        {
            var randomNumber = new Random();
            return randomNumber.Next(1, boardGame.DiceFaces + 1);
        }

        private static void Walk(IPlayer player, BoardGame boardGame, int diceNumber)
        {
            for (var i = 0; i < diceNumber; i++)
            {
                player.CurrentBoardHouse = player.CurrentBoardHouse == boardGame.LastBoardHouse
                    ? boardGame.FirstBoardHouse
                    : player.CurrentBoardHouse.Next;
                if (player.CurrentBoardHouse == boardGame.FirstBoardHouse)
                    ReceiveCash(player, boardGame.CreditForRound);
            }
        }

        private static void BuyBoardHouse(IPlayer player, BoardHouse boardHouse)
        {
            player.Coins -= boardHouse.PurchaseValue;
            boardHouse.Owner = player;
            player.Possessions.Add(boardHouse);
        }

        private static void PayBoardHouseRent(IPlayer player, BoardHouse boardHouse)
        {
            var ownerReceiveValue = boardHouse.RentValue <= player.Coins ? boardHouse.RentValue : player.Coins;
            player.Coins -= boardHouse.RentValue;
            ReceiveCash(boardHouse.Owner, ownerReceiveValue);
        }

        private static void ReceiveCash(IPlayer player, int cash)
        {
            player.Coins += cash;
        }

        private static void LostGame(IPlayer player)
        {
            player.Possessions.ForEach(p => p.Owner = null);
            player.Playing = false;
        }
    }
}