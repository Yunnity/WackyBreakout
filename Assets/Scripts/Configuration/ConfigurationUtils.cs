using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static float paddleMoveUnitsPerSecond;
    static float ballImpulseForce;
    static float ballLifeSpan;
    static float minBallSpawn;
    static float maxBallSpawn;
    static float standardPoints;
    static float bonusPoints;
    static float pickUpPoints;
    static float standardProb;
    static float bonusProb;
    static float pickUpProb;
    static float ballsLeft;
    static float freezeTime;
    static float speedDuration;
    static float speedValue;

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    public static float BallLifeSpan
    {
        get { return ballLifeSpan; }
    }

    public static float MinBallSpawn
    {
        get { return minBallSpawn; }
    }

    public static float MaxBallSpawn
    {
        get { return maxBallSpawn; }
    }

    public static float StandardPoints
    {
        get { return standardPoints; }
    }

    public static float BonusPoints
    {
        get { return bonusPoints; }
    }

    public static float PickUpPoints
    {
        get { return pickUpPoints; }
    }

    public static float StandardProb
    {
        get { return standardProb; }
    }

    public static float BonusProb
    {
        get { return bonusProb; }
    }

    public static float PickUpProb
    {
        get { return pickUpProb; }
    }

    public static float BallsLeft
    {
        get { return ballsLeft; }
    }

    public static float FreezeTime
    {
        get { return freezeTime; }
    }

    public static float SpeedDuration
    {
        get { return speedDuration; }
    }

    public static float SpeedValue
    {
        get { return speedValue; }
    }

    public static ConfigurationData configurationData;

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
        paddleMoveUnitsPerSecond = configurationData.PaddleMoveUnitsPerSecond;
        ballImpulseForce = configurationData.BallImpulseForce;
        ballLifeSpan = configurationData.BallLifeSpan;
        minBallSpawn = configurationData.MinBallSpawn;
        maxBallSpawn = configurationData.MaxBallSpawn;
        standardPoints = configurationData.StandardPoints;
        bonusPoints = configurationData.BonusPoints;
        pickUpPoints = configurationData.PickUpPoints;
        standardProb = configurationData.StandardProb;
        bonusProb = configurationData.BonusProb;
        pickUpProb = configurationData.PickUpProb;
        ballsLeft = configurationData.BallsLeft;
        freezeTime = configurationData.FreezeTime;
        speedDuration = configurationData.SpeedDuration;
        speedValue = configurationData.SpeedValue;
    }
}
