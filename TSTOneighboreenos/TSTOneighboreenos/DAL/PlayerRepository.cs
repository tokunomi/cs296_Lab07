using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TSTOneighboreenos.Models;

namespace TSTOneighboreenos.DAL
{
    public class PlayerRepository : IPlayerRepository, IDisposable
    {
        private NeighboreenoContext context;   // class member
        
        public PlayerRepository(NeighboreenoContext c)  // overloaded constructor (the 'c' is for 'context')
        {
            context = c;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return context.Players.ToList();
        }

        public Player GetPlayerByID(int id)
        {
            return context.Players.Find(id);
        }

        public void InsertPlayer(Player player)
        {
            context.Players.Add(player);
        }

        public void DeletePlayer(int playerID)
        {
            Player player = context.Players.Find(playerID);
            context.Players.Remove(player);
        }

        public void UpdatePlayer(Player player)
        {
            context.Entry(player).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;  // class member for Dispose

        protected virtual void Dispose(bool disposing)  // from tutorial
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}