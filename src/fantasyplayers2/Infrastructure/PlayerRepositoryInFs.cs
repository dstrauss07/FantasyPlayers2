using System;
using System.Collections.Generic;
using System.Text;
using StraussDa.ApplicationCore.Entities;
using StraussDa.ApplicationCore.Interfaces;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace StraussDa.Infrastructure
{
    public class PlayerRepositoryInFs : IPlayerRepository
    {
        private static List<Player> _players;
        private static int _nextId = 1;

        private const string PATH = "/playerdata";
        private const string FILENAME = "playerData.json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);

        public PlayerRepositoryInFs()
        {
            if (_players == null)
            {
                _players = LoadFile();
                _nextId = _players.Max(t => t.Id) + 1;
            }
        }
      
        public void Add(Player newPlayer)
        {
            newPlayer.Id = _nextId++;
            _players.Add(newPlayer);
            SaveFile();
        }

        public void Delete(Player deletedPlayer)
        {
            var origPlayer = GetById(deletedPlayer.Id);
            _players.Remove(origPlayer);
            SaveFile();
        }

        public void Edit(Player editedPlayer)
        {
            var origPlayer = GetById(editedPlayer.Id);

            origPlayer.FirstName = editedPlayer.FirstName;
            origPlayer.LastName = editedPlayer.LastName;
            origPlayer.Team = editedPlayer.Team;
            origPlayer.Pos = editedPlayer.Pos;
            origPlayer.PosRank = editedPlayer.PosRank;
            SaveFile();
        }

        public Player GetById(int id)
        {
            return _players.Find(p => p.Id == id);
        }

        public List<Player> ListAll()
        {
            return _players;    
        }

            
        public List<Player> LoadFile()
        { 


            try
            {
                string rawListStr = File.ReadAllText(_fileFullPath);

                List<Player> rawPlayerList = JsonConvert.DeserializeObject<List<Player>>(rawListStr);

                return rawPlayerList;
            }
            catch (Exception)
            {
                //LOG THE EXCEPTION
                return new List<Player>();
            }
           
        }

        public void SaveFile()
        {
            try
            {
                if(!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }
                string rawListStr = JsonConvert.SerializeObject(_players);

                File.WriteAllText(_fileFullPath, rawListStr);
            }
            catch (Exception)
            {
                //TODO log the exception
            }
        }
    }

}
