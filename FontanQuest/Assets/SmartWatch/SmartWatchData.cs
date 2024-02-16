using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SmartWatchData 
{
    public static double heartRate;

    public static double steps; 
    public static DateTime stepTimeStamp;
    public static double intensity_minutes;

    public static Boolean pastHeartActivity = false;
    public static Boolean pastStepActivitiy = false;

    public static class accelerometerSW
    {
        public static double x;
        public static double y;
        public static double z;

        public static void setValues(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }
}
