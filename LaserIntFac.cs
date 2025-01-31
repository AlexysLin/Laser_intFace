﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaserIntFac.defing;

namespace LaserIntFac
{
    public interface ILaser
    {
        //task: open
        RetErr Open();

        //task: close
        RetErr Close();

        //task: Open Shutter & DIODE
        RetErr OpenShutterAndDIODE(bool POpen);


        //task: Set Power(W) & Freq(KHz) & Bias(V) & Mode(0-based) & SpotDelay(us)
        //note: 會設定ThermaTrack
        RetErr SetLaserPreset(double PPower, double PFreq,
                                                double PMove, double PBias,
                                                double PEpulse);
        //task: Set Power(%) & Freq(KHz)
        //note: 會設定ThermaTrack
        RetErr SetPowerAndFreq(double PPower, double PFreq);

        //task: Check Laser Ready
        //note: 會確認All Temp Reached & All Servo Locked
        //retn: ready : OperOk
        //      Not Ready : AVIA355_LaserNotReady
        RetErr CheckLaserReady();

        //task: Check Shutter & DIODE Opened
        //retn: ready : OperOk
        //      Not Open : AVIA355_ShutterOrDIODENotOpened
        RetErr CheckShutterAndDIODEOpened();

        //task: Check Laser Enabled

        RetErr CheckLaserEnabled(out EEnabledState PEnabledState);

        //task: Check Laser Fault
        //retn: 有錯誤時回傳 AVIA355_LaserHardwearFault
        RetErr CheckLaserFault();

        //task: Set Mode
        //note: Mode 的定義隨機型不同
        RetErr SetMode(int pMode);

        //task: Set Bias Voltage
        //note: Bias Voltage 定義隨機型不同
        RetErr SetBiasVoltage(double pBiasVoltage);

        //task: Get Power Voltage
        RetErr GetPowerVoltage(out double pPowerVoltage);

        //task: Get Bias Voltage
        RetErr GetBiasVoltage(out double pBiasVoltage);

        //task: Set EPulse, in khz
        RetErr SetEPulse(double PEPulse);

        //task: check if support EPulse
        RetErr HaveEPulse(out bool isSup);

        //task: Set Etime
        RetErr SetETime(int etime);

        //task: Set patternbit
        RetErr SetPatternBin(int patbin);

        //task: check if support warm-up
        RetErr HaveWarmUp(out bool isSup);

        //task: check if warming up
        RetErr IsWarmingUp(int pSecs, out bool isOK);

        //task: Standby after open
        RetErr Standby();

        //task: Shutdown after open
        RetErr Shutdown();

        //task: Set Gate
        RetErr SetGate(bool POpen);

        //task: Set Diode Current
        RetErr SetDiodeCurrent(double PDCurr);

        //task: Get Hours until now
        RetErr GetHours(out int pHours);

        RetErr GetPatBins(out char asBins);

        //task: Check Hours Status
        RetErr CheckHours();

        //task: Get Spot
        RetErr GetSpot(out int pSpot);

        // task: Get Temperature

        RetErr GetTemperatrue(out double Temperature);
    }
}
namespace LaserIntFac.defing
{    
    public  class RetErr
    {
        public Boolean flag = true;
        public string Meg = "";
        public int Num = 0;
    }
    public enum EEnabledState
    {
        esStandby,//鑰匙在Standby
        esEnabled,//鑰匙在Enabled 且正常
        esStandbyByFault//鑰匙在Enabled 但不正常
    }
    public class Num   // -1301 ~ -1350
    {
        public static int _PowerConvert = -1;
        public static int _open = -1301;
        public static int _close = -1302;
        public static int _SetLaserPreset = -1303;
        public static int _SetPowerAndFreq = -1304;
        public static int _CheckLaserReady = -1305;
        public static int _CheckShutterAndDIODEOpened = -1306;
        public static int _CheckLaserEnabled = -1307;
        public static int _CheckLaserFault = -1308;
        public static int _SetMode = -1309;
        public static int _SetBiasVoltage = -1310;
        public static int _GetPowerVoltage = -1311;
        public static int _GetBiasVoltage = -1312;
        public static int _Shutdown = -1313;
        public static int _GetTemperature = -1314;
        public static int _GetHours = -1315;
        public static int _OpenShutterAndDIODE = -1316;
        public static int _SetDiodeCurrent = -1317;

    }
}
