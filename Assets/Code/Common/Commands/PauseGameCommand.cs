﻿using System.Threading.Tasks;
using Patterns.Behaviour.Command;
using UnityEngine;

namespace Common.Commands
{
    public class PauseGameCommand : Command
    {
        public Task Execute()
        {
            Time.timeScale = 0;
            return Task.CompletedTask;
        }
    }
}
