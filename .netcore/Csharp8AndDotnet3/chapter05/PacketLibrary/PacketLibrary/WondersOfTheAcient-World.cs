using System;
using System.Collections.Generic;
using System.Text;

namespace Packet.Shared 
{

    //使用enum类型存储多个值
    [System.Flags]
    public enum WondersOfTheAcientWorld : byte
    {
        None                        = 0b_0000_0000,
        GreatePyramidOfGiza         = 0b_0000_0001,
        HangingGardensOfBabylon     = 0b_0000_0010,
        StatueOfZeusAtOlympia       = 0b_0000_0100,
        TempleOfArtemisAtEphesus    = 0b_0000_1000,
        MausoleumAtHalicarnassus    = 0b_0001_0000,
        ColossusOfRhodes            = 0b_0010_0000,
        LighthouseOfAlexandria      = 0b_0100_0000
    }
}
