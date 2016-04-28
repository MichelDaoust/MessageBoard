using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
  public class MessageBoardMigrationsConfiguration
    : DbMigrationsConfiguration<MessageBoardContext>
  {
    public MessageBoardMigrationsConfiguration()
    {
      this.AutomaticMigrationDataLossAllowed = true;
      this.AutomaticMigrationsEnabled = true;
    }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);

#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Title = "I love MVC",
                    Created = DateTime.Now,
                    Body = "I love ASP.NET MVC and I want everyone to know it",
                    Replies = new List<Reply>()
                {
                new Reply()
                {
                    Body = "I love it too!",
                    Created = DateTime.Now
                },
                new Reply()
                {
                    Body = "Me too",
                    Created = DateTime.Now
                },
                new Reply()
                {
                    Body = "Aw shucks",
                    Created = DateTime.Now
                },
                }

                };
            }

            if (context.ScheduleList.Count() == 0)
            {
                var game = new Game()
                {
                    Title = "Partie 1"
                };

                context.ScheduleList.Add(game);

                game = new Game()
                {
                    Title = "Partie 2"
                };

                context.ScheduleList.Add(game);
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
#endif
    }
  }
}
