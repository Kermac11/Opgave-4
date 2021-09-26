using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using ModelLib;

namespace RestfulServer.Managers
{
    public interface IManageFootball
    {
        IEnumerable<FootballPlayer> Get();
        FootballPlayer Get(int id); 
        bool Create(FootballPlayer value);
        bool Update(int id, FootballPlayer value);
        FootballPlayer Delete(int id);
    }
}
