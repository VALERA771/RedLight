using Exiled.API.Features;
using Exiled.API.Interfaces;
using System;
using UnityEngine;

using Server = Exiled.Events.Handlers.Server;

namespace RedLignt
{
    public class Main : Plugin<Config>
    {
        public override string Name => "RedLight";
        public override string Prefix => "redlight";
        public override string Author => "VALERA771#1471";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            Server.RoundStarted += OnRoundStarted;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= OnRoundStarted;

            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
        }

        public void OnRoundStarted()
        {
            foreach(Room room in Room.List)
            {
                room.Color = Color.red;
            }
        }
    }

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}
