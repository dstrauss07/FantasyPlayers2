using System;
using System.Collections.Generic;
using System.Text;
using StraussDa.ApplicationCore.Entities;
using StraussDa.ApplicationCore.Interfaces;

namespace StraussDa.Infrastructure
{
    public class PlayerRepositoryInMemory : IPlayerRepository
    {
        private static List<Player> _players;
        private static int _nextId = 1;

        public PlayerRepositoryInMemory()
        {
            if (_players == null)
            {
                _players = new List<Player>();
            }
        }
      
        public void Add(Player newPlayer)
        {
            newPlayer.Id = _nextId++;
            _players.Add(newPlayer);
        }

        public void Delete(Player deletedPlayer)
        {
            var origPlayer = GetById(deletedPlayer.Id);
            _players.Remove(origPlayer);
        }

        public void Edit(Player editedPlayer)
        {
            var origPlayer = GetById(editedPlayer.Id);

            origPlayer.FirstName = editedPlayer.FirstName;
            origPlayer.LastName = editedPlayer.LastName;
            origPlayer.Team = editedPlayer.Team;
            origPlayer.Pos = editedPlayer.Pos;
            origPlayer.PosRank = editedPlayer.PosRank;
        }

        public Player GetById(int id)
        {
            return _players.Find(p => p.Id == id);
        }

        public List<Player> ListAll()
        {
            return _players;
        }
    }
}
