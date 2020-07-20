using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManagement : MonoBehaviour
{
    [SerializeField] private List<Modul> moduls;
    [SerializeField] private Reactor _reactor;

    private void Start()
    {
        Switch("PowerStation");
    }

    public void Switch(string roomName)
    {
        Modul currentRoom = SearchRoom(roomName);

        if (currentRoom.RoomName == roomName)
        {
            if (currentRoom.RoomPower)
            {
                currentRoom.TurnOffPower();
                _reactor.TurnOffRoom();
            }
            else
            {
                if (_reactor.CheckCountPower())
                {
                    currentRoom.TurnOnPower();
                    _reactor.TurnOnRoom();
                }
            }
        }
    }

    private Modul SearchRoom(string nameRoom)
    {
        Modul currentModul = null;

        for (int i = 0; i < moduls.Count; i++)
        {
            if (moduls[i].RoomName == nameRoom)
            {
                currentModul = moduls[i];
                break;
            }
        }

        return currentModul;
    }
}
