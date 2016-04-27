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

        public HttpResponseMessage Post(int topicId, [FromBody]Reply newReply)
        {
          if (newReply.Created == default(DateTime))
          {
            newReply.Created = DateTime.UtcNow;
          }

          newReply.TopicId = topicId;

          if (_repo.AddReply(newReply) &&
              _repo.Save())
          {
            return Request.CreateResponse(HttpStatusCode.Created,
              newReply);
          }

          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


    }
}
