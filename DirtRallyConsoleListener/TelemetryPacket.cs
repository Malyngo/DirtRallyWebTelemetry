/*
 * mostly based on https://github.com/robgray/F1Speed/blob/master/F1Speed.Core/TelemetryPacket.cs
 * without the F1Speed project, I wouldn't have come very far. So credits to robgray for his work!
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DirtRallyConsoleListener
{
    [Serializable]
    public struct TelemetryPacket : ISerializable
    {
        public TelemetryPacket(SerializationInfo info, StreamingContext context)
        {
            Time = (float)info.GetValue("Time", typeof(float));
            LapTime = (float)info.GetValue("LapTime", typeof(float));
            LapDistance = (float)info.GetValue("LapDistance", typeof(float));
            Distance = (float)info.GetValue("Distance", typeof(float));
            Speed = (float)info.GetValue("Speed", typeof(float));
            Lap = (float)info.GetValue("Lap", typeof(float));
            X = (float)info.GetValue("X", typeof(float));
            Y = (float)info.GetValue("Y", typeof(float));
            Z = (float)info.GetValue("Z", typeof(float));
            XV = 0;
            YV = 0;
            ZV = 0;
            XR = 0;
            YR = 0;
            ZR = 0;
            XD = 0;
            YD = 0;
            ZD = 0;
            SuspensionPositionRearLeft = 0;
            SuspensionPositionRearRight = 0;
            SuspensionPositionFrontLeft = 0;
            SuspensionPositionFrontRight = 0;
            SuspensionVelocitoyRearLeft = 0;
            SuspensionVelocitoyRearRight = 0;
            SuspensionVelocitoyFrontLeft = 0;
            SuspensionVelocitoyFrontRight = 0;
            WheelSpeedBackLeft = 0;
            WheelSpeedBackRight = 0;
            WheelSpeedFrontLeft = 0;
            WheelSpeedFrontRight = 0;
            Throttle = (float)info.GetValue("Throttle", typeof(float));
            Steer = 0;
            Brake = 0;
            Clutch = 0;
            Gear = (float)info.GetValue("Gear", typeof(float));
            GForceLatitudinal = 0;
            GForceLongitudinal = 0;
            EngineRevs = (float)info.GetValue("EngineRevs", typeof(float));

        }

        public float Time;
        public float LapTime;
        public float LapDistance;
        public float Distance;
        //[XmlIgnore]
        public float X;
        //[XmlIgnore]
        public float Y;
        //[XmlIgnore]
        public float Z;
        public float Speed;
        [XmlIgnore]
        public float XV;
        [XmlIgnore]
        public float YV;
        [XmlIgnore]
        public float ZV;
        [XmlIgnore]
        public float XR;
        [XmlIgnore]
        public float YR;
        [XmlIgnore]
        public float ZR;
        [XmlIgnore]
        public float XD;
        [XmlIgnore]
        public float YD;
        [XmlIgnore]
        public float ZD;
        [XmlIgnore]
        public float SuspensionPositionRearLeft;
        [XmlIgnore]
        public float SuspensionPositionRearRight;
        [XmlIgnore]
        public float SuspensionPositionFrontLeft;
        [XmlIgnore]
        public float SuspensionPositionFrontRight;
        [XmlIgnore]
        public float SuspensionVelocitoyRearLeft;
        [XmlIgnore]
        public float SuspensionVelocitoyRearRight;
        [XmlIgnore]
        public float SuspensionVelocitoyFrontLeft;
        [XmlIgnore]
        public float SuspensionVelocitoyFrontRight;
        [XmlIgnore]
        public float WheelSpeedBackLeft;
        [XmlIgnore]
        public float WheelSpeedBackRight;
        [XmlIgnore]
        public float WheelSpeedFrontLeft;
        [XmlIgnore]
        public float WheelSpeedFrontRight;
        [XmlIgnore]
        public float Throttle;
        [XmlIgnore]
        public float Steer;
        [XmlIgnore]
        public float Brake;
        [XmlIgnore]
        public float Clutch;
        //[XmlIgnore]
        public float Gear;
        [XmlIgnore]
        public float GForceLatitudinal;
        [XmlIgnore]
        public float GForceLongitudinal;
        public float Lap;
        //[XmlIgnore]
        public float EngineRevs;
        [XmlIgnore]
        public float SpeedInKmPerHour
        {
            get { return Speed * 3.60f; }
        }

        public override string ToString()
        {
            return "Lap: " + Lap + ", " +
                   "Time: " + Time + ", " +
                   "LapTime: " + LapTime + ", " +
                   "LapDistance: " + LapDistance + ", " +
                   "Distance: " + Distance + ", " +
                   "Speed: " + Speed;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Time", Time);
            info.AddValue("LapTime", LapTime);
            info.AddValue("LapDistance", LapDistance);
            info.AddValue("Distance", Distance);
            info.AddValue("Speed", Speed);
            info.AddValue("Lap", Lap);
            info.AddValue("Gear", Gear);
            info.AddValue("EngineRevs", EngineRevs);
        }
    }
}
