using System.Linq;
using System.Text.RegularExpressions;
using Jabbot;
using Jabbot.Models;
using Jabbot.Sprockets;

namespace RoomAnnouncementsSprocket
{
    public class SetAnnouncement: RegexSprocket
    {
        public override Regex Pattern
        {
            get { return new Regex(@"[-_.\w\s]+set announcement [-_.\w\s]+"); }
        }

        protected override void ProcessMatch(Match match, ChatMessage message, Bot bot)
        {
            if(!bot.GetRoomOwners(message.Room).Contains(message.FromUser))
            {
                bot.PrivateReply(message.FromUser,"Sorry, but you don't have permissions to do that");
                return;
            }

            bot.PrivateReply(message.FromUser, "Announcement set.");

            Announcement.Message = Regex.Split(match.Value, "set announcement")[1].Trim();

            foreach(var user in bot.GetUsers(message.Room))
            {
                if(user.Name.ToString() != bot.Name)
                    bot.PrivateReply(user.Name.ToString(), Announcement.Message);
            }
        }
    }
}
