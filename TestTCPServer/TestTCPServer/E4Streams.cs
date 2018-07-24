using System;
using System.Collections.Generic;
using System.Text;

namespace TestTCPServer
{
    class E4Streams
    {
        public enum STREAMS
        {
            acc, //3-axis acceleration
            bvp, //Blood Volume Pulse
            gsr, //Galvanic Skin Response
            ibi, //Interbeat Interval and Heartbeat
            tmp, //Skin Temperature
            bat, //Device Battery
            tag //Tag taken from the device (by pressing the button)}
        };

        public static List<string> STREAMS_STRINGS = new List<string>
        {
            "acc", //3-axis acceleration
            "bvp", //Blood Volume Pulse
            "gsr", //Galvanic Skin Response
            "ibi", //Interbeat Interval and Heartbeat
            "tmp", //Skin Temperature
            "bat", //Device Battery
            "tag" //Tag taken from the device (by pressing the button)}
        };
    }
}