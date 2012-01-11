using System.Text.RegularExpressions;
using Jabbot;
using Jabbot.Models;
using Jabbot.Sprockets;

namespace RoomAnnouncementsSprocket
{
    public class UserEntersRoomAnnouncement: RegexSprocket
    {
        public override Regex Pattern
        {
            get { return new Regex(@"\[JABBR\] -[-_.\w\s]+just entered[-_.\w\s]+"); }
        }

        protected override void ProcessMatch(Match match, ChatMessage message, Bot bot)
        {
            if (string.IsNullOrWhiteSpace(Announcement.Message)) return;

            if (message.FromUser == bot.Name) return;

            bot.PrivateReply(message.FromUser, Announcement.Message);
        }
    }
}
