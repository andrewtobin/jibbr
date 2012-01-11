using System.Linq;
using System.Text.RegularExpressions;
using Jabbot;
using Jabbot.Models;
using Jabbot.Sprockets;

namespace RoomAnnouncementsSprocket
{
    public class ClearAnnouncement: RegexSprocket
    {
        public override Regex Pattern
        {
            get { return new Regex(@"[-_.\w\s]+clear announcement"); }
        }

        protected override void ProcessMatch(Match match, ChatMessage message, Bot bot)
        {
            if (!bot.GetRoomOwners(message.Room).Contains(message.FromUser))
            {
                bot.PrivateReply(message.FromUser, "Sorry, but you don't have permissions to do that");
                return;
            }

            bot.PrivateReply(message.FromUser, "Announcement cleared.");

            Announcement.Message = "";
        }
    }
}
