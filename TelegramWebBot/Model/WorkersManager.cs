using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramWebBot.Data;
using WebBotCore.Interfase;
using WebBotCore.Model;

namespace TelegramWebBot.Model
{
    public class ProfileManager
    {
        private TelegramProfile profile;
        private List<TelegramWorker> workers;
    }

    public class TelegramWorker : Worker
    {       
        public bool IsLogin { private set; get; }
        TelegramProfile profile;
    }

    public class WebWidget
    {

    }
}
