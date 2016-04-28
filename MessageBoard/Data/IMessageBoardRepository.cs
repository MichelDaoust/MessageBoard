using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.Data
{
  public interface IMessageBoardRepository
  {
    IQueryable<Topic> GetTopics();
    IQueryable<Topic> GetTopicsIncludingReplies();
    IQueryable<Reply> GetRepliesByTopic(int topicId);
    IQueryable<Game> GetScheduleList();
    Game GetInfoByGame(int Game);

    bool Save();

    bool AddTopic(Topic newTopic);
    bool AddReply(Reply newReply);
    bool AddGame(Game newGame);

    }
}
