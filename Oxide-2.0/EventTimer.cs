using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using Oxide.Core;
using System.Collections;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("EventTimer", "Sh1ne", "1.0.0")]
    class EventTimer : RustLegacyPlugin
    {
        //Время в секундах, через которое будет запускаться ивент
        float repeatTime = 10f;

        //Время, которое дается на то, чтобы написать правильный ответ
        float timeForAnswer = 8f;

        //Минимальная и максимальная награда
        int minReward = 1000; 
		int maxReward = 5000;

        string ChatName = "EventTimer";

        int TrueAnswer;
        int Reward;
        bool eventRunning = false;

        void Loaded()
        {
            timer.Repeat(repeatTime, 0, () =>
            {
				
                timer.Once(timeForAnswer, () =>
                {
                    if (eventRunning)
                    {
                        Broadcast.MessageAll($"[COLOR#FF0000]Время для ответа вышло. Следующий ивент через {repeatTime - timeForAnswer} секунд!", ChatName);
                        eventRunning = false;
                    }
                });

                StartEvent();
            });
        }

        void StartEvent()
        {
            eventRunning = true;
            int number_1 = Core.Random.Range(1, 500);
            int number_2 = Core.Random.Range(1, 500);

            Reward = Core.Random.Range(minReward, maxReward);
            TrueAnswer = number_1 + number_2;
			
			string text = $"[COLOR#FF0000][COLOR#FFFF00]Сколько будет {number_1} + {number_2}? Победитель получит [COLOR#00FF00]{Reward}$[COLOR#FFFF00] за правильный ответ!";
            Broadcast.MessageAll(text, ChatName);
        }

        bool OnPlayerChat(NetUser netUser, string message)
        {
            if (eventRunning && message.Length < 5)
            {
                int answer;
				
                try
                {
                    answer = Int32.Parse(message);
                }
                catch
                {
                    return false;
                }

                if (answer == TrueAnswer)
                {
                    eventRunning = false; 
					
					string text = $"[COLOR#FF0000]{netUser.user.displayname_} [COLOR#FFFF00]победил и получает [COLOR#00FF00]{Reward}$[COLOR#FFFF00] на свой счет! Правильный ответ: {TrueAnswer}!";
                    Broadcast.MessageAll(text, ChatName);
					
					ulong reward = (ulong) Reward;					
                    Economy.Get(netUser.userID).Balance += reward;
                    return true;
                }
            }
            return false;
        }
    }
}