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

    private float _darknessAlpha;
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

        Switch(2);
    }

    public void Switch(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                _greenhouseDarkness = Turn(_greenhouseDarkness);
                _greenhousePower = !_greenhousePower;
                break;
            case 2:
                _powerStationDarkness = Turn(_powerStationDarkness);
                _powerStationPower = !_powerStationPower;
                break;
            case 3:
                _miningRobotDarkness = Turn(_miningRobotDarkness);
                _miningRobotPower = !_miningRobotPower;
                break;
            case 4:
                _synthesizerDarkness = Turn(_synthesizerDarkness);
                _synthesizerPower = !_miningRobotPower;
                break;
            case 5:
                _sewageTreatmentDarkness = Turn(_sewageTreatmentDarkness);
                _sewageTreatmentPower = !_sewageTreatmentPower;
                break;
            case 6:
                _bedroomDarkness = Turn(_bedroomDarkness);
                _bedroomPower = !_bedroomPower;
                break;
            case 7:
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

    public bool UseRoom(int roomNumber)
    {
        bool canUse = false;

        switch (roomNumber)
        {
            case 1:
                canUse = _greenhousePower;
                break;
            case 2:
                canUse = _powerStationPower;
                break;
            case 3:
                canUse = _miningRobotPower;
                break;
            case 4:
                canUse = _synthesizerPower;
                break;
            case 5:
                canUse = _sewageTreatmentPower;
                break;
            case 6:
                canUse = _bedroomPower;
                break;
            case 7:
                canUse = _communicationUnitPower;
                break;
        }

        return canUse;
    }
}
