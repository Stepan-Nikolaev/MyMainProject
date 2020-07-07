using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManagement : MonoBehaviour
{
    [SerializeField] private Reactor _reactor;
    [SerializeField] private Image _greenhouseDarkness;
    [SerializeField] private Image _powerStationDarkness;
    [SerializeField] private Image _miningRobotDarkness;
    [SerializeField] private Image _synthesizerDarkness;
    [SerializeField] private Image _sewageTreatmentDarkness;
    [SerializeField] private Image _bedroomDarkness;
    [SerializeField] private Image _communicationUnitDarkness;
    private bool _greenhousePower;
    private bool _powerStationPower;
    private bool _miningRobotPower;
    private bool _synthesizerPower;
    private bool _sewageTreatmentPower;
    private bool _bedroomPower;
    private bool _communicationUnitPower;

    private void Start()
    {
        _greenhousePower = false;
        _powerStationPower = false;
        _miningRobotPower = false;
        _synthesizerPower = false;
        _sewageTreatmentPower = false;
        _bedroomPower = false;
        _communicationUnitPower = false;

        Switch("PowerStation");
    }

    public void Switch(string roomName)
    {
        switch (roomName)
        {
            case "Greenhouse":
                _greenhouseDarkness = Turn(_greenhouseDarkness);
                _greenhousePower = !_greenhousePower;
                break;
            case "PowerStation":
                _powerStationDarkness = Turn(_powerStationDarkness);
                _powerStationPower = !_powerStationPower;
                break;
            case "MiningRobot":
                _miningRobotDarkness = Turn(_miningRobotDarkness);
                _miningRobotPower = !_miningRobotPower;
                break;
            case "Synthesizer":
                _synthesizerDarkness = Turn(_synthesizerDarkness);
                _synthesizerPower = !_miningRobotPower;
                break;
            case "SewageTreatment":
                _sewageTreatmentDarkness = Turn(_sewageTreatmentDarkness);
                _sewageTreatmentPower = !_sewageTreatmentPower;
                break;
            case "Bedroom":
                _bedroomDarkness = Turn(_bedroomDarkness);
                _bedroomPower = !_bedroomPower;
                break;
            case "ComunicationUnit":
                _communicationUnitDarkness = Turn(_communicationUnitDarkness);
                _communicationUnitPower = !_communicationUnitPower;
                break;
        }
    }

    private Image Turn(Image roomDarkess)
    {
        if (roomDarkess.enabled)
        {
            if (_reactor.CheckCountPower())
            {
                roomDarkess.enabled = false;
                _reactor.TurnOnRoom();
            }
        }
        else if(!roomDarkess.enabled)
        {
            roomDarkess.enabled = true;
            _reactor.TurnOffRoom();
        }

        return roomDarkess;
    }

    public bool UseRoom(string roomNumber)
    {
        bool canUse = false;

        switch (roomNumber)
        {
            case "Greenhouse":
                canUse = _greenhousePower;
                break;
            case "PowerStation":
                canUse = _powerStationPower;
                break;
            case "MiningRobot":
                canUse = _miningRobotPower;
                break;
            case "Synthesizer":
                canUse = _synthesizerPower;
                break;
            case "SewageTreatment":
                canUse = _sewageTreatmentPower;
                break;
            case "Bedroom":
                canUse = _bedroomPower;
                break;
            case "ComunicationUnit":
                canUse = _communicationUnitPower;
                break;
        }

        return canUse;
    }
}
