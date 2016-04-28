using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class ScheduleController : ApiController
    {
        private IMessageBoardRepository _repo;
        public ScheduleController(IMessageBoardRepository repo)
        {
          _repo = repo;
        }

        public Game Get(int Game)
        {
          return _repo.GetInfoByGame(Game);
        }


        public IEnumerable<Game> Get()
        {
            IQueryable<Game> result = _repo.GetScheduleList();
            return result;
        }

        public HttpResponseMessage Post(int GameID, [FromBody]Game newGame)
        {

            newGame.Id = GameID;

            if (_repo.AddGame(newGame) &&
                _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created,
                  newGame);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


    }
}
