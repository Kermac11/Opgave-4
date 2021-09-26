using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModelLib;

namespace RestfulServer.Managers
{
    public class ManageFootball : IManageFootball
    {
        private static List<FootballPlayer> players = new List<FootballPlayer>()
        {
         new FootballPlayer(1,"Peter",80,1),
         new FootballPlayer(5,"John", 50,5),
         new FootballPlayer(7,"Jens", 77,7),
         new FootballPlayer(21,"Knud",150,21)
        };


        public IEnumerable<FootballPlayer> Get()
        {
            return new List<FootballPlayer>(players);
        }

        public FootballPlayer Get(int id)
        {
            return players.Find(p => p.Id == id);
        }

        public bool Create(FootballPlayer value)
        {
            players.Add(value);
           return players.Exists(p => p == value);
        }

        public bool Update(int id, FootballPlayer value)
        {
            players[players.FindIndex(ind => ind.Equals(Get(id)))] = value;
            return players.Exists(p => p == value);
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer place = Get(id);
            players.Remove(Get(id));
            return place;
        }
    }
}
