using UnityEngine;

public enum TurretType {Magical, Mechanical}

public class TurretData : MonoBehaviour
{
    public string _turretName;

    public int _turretLife;

    public int _turretCost;

    public int _turretLevel;

    public int _turretRateOfFire;

    public int _turretRange;

    public TurretType _turretType;

    public int ReturnTurretCost()
    {
        return _turretCost;
    }
}
