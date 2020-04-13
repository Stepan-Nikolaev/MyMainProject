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
        _darknessAlpha = _greenhouseDarkness.color.a;
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
        float alpha;

        switch (roomNumber)
        {
            case 1:
                alpha = Turn(_greenhouseDarkness.color.a);
                _greenhouseDarkness.color = new Color(0, 0, 0, alpha);
                _greenhousePower = !_greenhousePower;
                break;
            case 2:
                alpha = Turn(_powerStationDarkness.color.a);
                _powerStationDarkness.color = new Color(0, 0, 0, alpha);
                _powerStationPower = !_powerStationPower;
                break;
            case 3:
                alpha = Turn(_miningRobotDarkness.color.a);
                _miningRobotDarkness.color = new Color(0, 0, 0, alpha);
                _miningRobotPower = !_miningRobotPower;
                break;
            case 4:
                alpha = Turn(_synthesizerDarkness.color.a);
                _synthesizerDarkness.color = new Color(0, 0, 0, alpha);
                _synthesizerPower = !_miningRobotPower;
                break;
            case 5:
                alpha = Turn(_sewageTreatmentDarkness.color.a);
                _sewageTreatmentDarkness.color = new Color(0, 0, 0, alpha);
                _sewageTreatmentPower = !_sewageTreatmentPower;
                break;
            case 6:
                alpha = Turn(_bedroomDarkness.color.a);
                _bedroomDarkness.color = new Color(0, 0, 0, alpha);
                _bedroomPower = !_bedroomPower;
                break;
            case 7:
                alpha = Turn(_communicationUnitDarkness.color.a);
                _communicationUnitDarkness.color = new Color(0, 0, 0, alpha);
                _communicationUnitPower = !_communicationUnitPower;
                break;
        }
    }

    private float Turn(float alpha)
    {
        if (alpha == 0)
        {
            alpha = _darknessAlpha;
            _reactor.TurnOffRoom();
        }
        else
        {
            if (_reactor.CheckCountPower())
            {
                alpha = 0;
                _reactor.TurnOnRoom();
            }
        }

        return alpha;
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
