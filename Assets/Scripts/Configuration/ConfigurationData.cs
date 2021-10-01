using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigData.csv";

    // configuration data
    public static float paddleMoveUnitsPerSecond;
    public static float ballImpulseForce;
    public static float ballLifeSpan;
    public static float minBallSpawn;
    public static float maxBallSpawn;
    public static float standardPoints;
    public static float bonusPoints;
    public static float pickUpPoints;
    public static float standardProb;
    public static float bonusProb;
    public static float pickUpProb;
    public static float ballsLeft;
    public static float freezeTime;
    public static float speedDuration;
    public static float speedValue;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifeSpan
    {
        get { return ballLifeSpan; }
    }

    public float MinBallSpawn
    {
        get { return minBallSpawn; }
    }

    public float MaxBallSpawn
    {
        get { return maxBallSpawn; }
    }

    public float StandardPoints
    {
        get { return standardPoints; }
    }

    public float BonusPoints
    {
        get { return bonusPoints; }
    }

    public float PickUpPoints
    {
        get { return pickUpPoints; }
    }

    public float StandardProb
    {
        get { return standardProb; }
    }

    public float BonusProb
    {
        get { return bonusProb; }
    }

    public float PickUpProb
    {
        get { return pickUpProb; }
    }

    public float BallsLeft
    {
        get { return ballsLeft; }
    }

    public float FreezeTime
    {
        get { return freezeTime; }
    }

    public float SpeedDuration
    {
        get { return speedDuration; }
    }

    public float SpeedValue
    {
        get { return speedValue; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string nameLine = input.ReadLine();
            string valueLine = input.ReadLine();
            string[] valueArr = valueLine.Split(',');

            paddleMoveUnitsPerSecond = float.Parse(valueArr[0]);
            ballImpulseForce = float.Parse(valueArr[1]);
            ballLifeSpan = float.Parse(valueArr[2]);
            minBallSpawn = float.Parse(valueArr[3]);
            maxBallSpawn = float.Parse(valueArr[4]);
            standardPoints = float.Parse(valueArr[5]);
            bonusPoints = float.Parse(valueArr[6]);
            pickUpPoints = float.Parse(valueArr[7]);
            standardProb = float.Parse(valueArr[8]);
            bonusProb = float.Parse(valueArr[9]);
            pickUpProb = float.Parse(valueArr[10]);
            ballsLeft = float.Parse(valueArr[11]);
            freezeTime = float.Parse(valueArr[12]);
            speedDuration = float.Parse(valueArr[13]);
            speedValue = float.Parse(valueArr[14]);
        }

        catch(Exception e)
        {
        }

        finally
        {
            if(input != null)
            {
                input.Close();
            }
        }
    }

    #endregion
}
