using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            Debug.WriteLine($"The resource {resourceName} has been started on the client.");

            RegisterCommand("owner", new Action<int, List<object>, string>((source, args, raw) =>
            {
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] {255, 0, 0},
                    args = new[] {"[Owner]", "The owner of this server is ClipZz"}
                });

            }), false);
        }
    }
}
