﻿using Common;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core
{
    public class EventQueueInstaller : Installer
    {
        [SerializeField] private EventQueueImpl _eventQueue;
        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_eventQueue.gameObject);
            serviceLocator.RegisterService<EventQueue>(_eventQueue);
        }
    }
}