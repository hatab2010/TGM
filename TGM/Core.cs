using System;
using System.Collections.Generic;
using System.IO;
using WebBotCore.Interfase;
using WebBotCore.Model;

namespace WebBotCore
{
    public class Core
    {
        private ChromeProfileManager profileManager = new ChromeProfileManager();

        private List<IWorker> Workers = new List<IWorker>();

        private string currentDirrectory;

        public Core()
        {
            currentDirrectory = Directory.GetCurrentDirectory();
        }

        public ChromeProfileManager Manager()
        {
            return profileManager;
        }

        public void CreateWorker<T>(IEnumerable<IChromeProfile> profiles) where T : IWorker, new()
        {
            throw new NotImplementedException();
            //foreach (var profile in profiles)
            //{
            //    var newWorker = new T(profile);
            //    newWorker.Start(profile);
            //    Workers.Add(newWorker);
            //}
        }
    }
}
