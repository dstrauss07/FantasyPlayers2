using StraussDa.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StraussDa.ApplicationCore.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> ListAll();
        Player GetById(int id);
        void Add(Player newPlayer);
        void Edit(Player editedPlayer);
        void Delete(Player deletedPlayer);
    }
}
