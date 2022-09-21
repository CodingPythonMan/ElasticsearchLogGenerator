﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchProject
{
    public class SendLogService
    {
        public void SendListLog(int loop)
        {
            Random random = new Random();
            List<int> ids = new List<int>();

            for (int i = 0; i < loop; i++)
            {
                ids.Add(random.Next(1, 10));
            }

            Custom1Log customLog = new Custom1Log();
            customLog.Kennen = 3;
            customLog.TM = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            customLog.Characters = ids;

            LogService.AddLog<Custom1Log>(customLog);
        }

        public void SendDictLog(int loop)
        {
            Random random = new Random();
            List<int> ids = new List<int>();

            Custom2Log customLog = new Custom2Log();
            customLog.Kennen = 3;
            customLog.TM = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            customLog.Characters = new Dictionary<int, int>();

            for (int i = 0; i < loop; i++)
            {
                ids.Add(random.Next(1, 10));
                customLog.Characters.Add(i, ids[i]);
            }

            LogService.AddLog<Custom2Log>(customLog);
        }

        public void SendArrayLog(int loop)
        {
            Random random = new Random();

            Custom3Log customLog = new Custom3Log();
            customLog.Kennen = 3;
            customLog.TM = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            customLog.Characters = new int[loop];

            for (int i = 0; i < loop; i++)
            {
                customLog.Characters[i] = random.Next(1, 10);
            }

            LogService.AddLog<Custom3Log>(customLog);
        }
    }
}
