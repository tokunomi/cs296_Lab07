using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSTOneighboreenos.Models;

namespace TSTOneighboreenos.DAL
{
    public class FakePlayerRepository : IPlayerRepository
    {
        List<Player> players;

        public FakePlayerRepository(List<Player> p)
        {
            players = p;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return players;
        }

        public Player GetPlayerByID(int playerId)
        {
            throw new NotImplementedException();
        }

        public void InsertPlayer(Player player)
        {
            players.Add(player);
        }

        public void DeletePlayer(int playerID)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}