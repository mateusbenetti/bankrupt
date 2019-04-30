using System;
using Bankrupt.Domain.Interface;
using Bankrupt.Model;
using Bankrupt.Model.Interface;

namespace Bankrupt.Domain
{
    public class PlayerDomain : IPlayerDomain
    {
        public void Play(IPlayer player, BoardGame boardGame)
        {
            var diceNumber = DiceRoll(boardGame);
            Walk(player, boardGame, diceNumber);
            if (player.CurrentBoardHouse.Owner != null)
            {
                PayBoardHouseRent(player, player.CurrentBoardHouse);
            }
            else
            {
                var playerHasCash = player.Coins >= player.CurrentBoardHouse.PurchaseValue;
                if (playerHasCash && player.WantBuy)
                    BuyBoardHouse(player, player.CurrentBoardHouse);
            }
            if (player.Coins < 0)
                LostGame(player);
        }

        private static int DiceRoll(BoardGame boardGame)
        {
            var randomNumber = new Random();
            return randomNumber.Next(1, boardGame.DiceFaces + 1);
        }

        private  static void Walk(IPlayer player, BoardGame boardGame, int diceNumber)
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