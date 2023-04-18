using System;
using System.Runtime.InteropServices;

namespace SharpMSS
{
    public static class MilesAPI
    {
        [DllImport("mss32.dll", EntryPoint = "_MilesGetEventLength@4")]
        public static extern void GetEventLength(int type_a);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesGetEventSystemState@8")]
        public static extern void GetEventSystemState(int type_a, int type_b);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesStopSoundInstances@12")]
        public static extern void StopSoundInstances(int type_a, int type_b, int type_c);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesPauseSoundInstances@12")]
        public static extern void PauseSoundInstances(int type_a, int type_b, int type_c);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesResumeSoundInstances@12")]
        public static extern void ResumeSoundInstances();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesStartSoundInstance@32")]
        public static extern void StartSoundInstance();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesSetBankFunctions@4")]
        public static extern void SetBankFunctions(int type_a);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesGetBankFunctions@0")]
        public static extern void GetBankFunctions();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesEventSetAuditionFunctions@4")]
        public static extern void EventSetAuditionFunctions(int type_a);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesUseTmLite@4")]
        public static extern void UseTmLite();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesUseTelemetry@4")]
        public static extern void UseTelemetry();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesFindEvent@8")]
        public static extern void FindEvent();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesClearEventQueue@0")]
        public static extern void ClearEventQueue();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesRegisterRand@4")]
        public static extern void RegisterRand();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesEnumerateSoundInstances@28")]
        public static extern void EnumerateSoundInstances();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesEnumeratePresetPersists@12")]
        public static extern void EnumeratePresetPersists();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesEnqueueEvent@24")]
        public static extern void EnqueueEvent();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesBeginEventQueueProcessing@0")]
        public static extern void BeginEventQueueProcessing();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesCompleteEventQueueProcessing@0")]
        public static extern void CompleteEventQueueProcessing();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesStartupEventSystem@16")]
        public static extern void StartupEventSystem();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesShutdownEventSystem@0")]
        public static extern void ShutdownEventSystem();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesAddSoundBank@8", CharSet = CharSet.Ansi)]
        public static extern void AddSoundBank(string name, string bankFileName);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesSetEventErrorCallback@4")]
        public static extern void SetEventErrorCallback();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesReleaseSoundBank@4")]
        public static extern void ReleaseSoundBank();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesSetSoundLabelLimits@8")]
        public static extern void SetSoundLabelLimits();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesTextDumpEventSystem@0")]
        public static extern IntPtr TextDumpEventSystem();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesEnqueueEventContext@28")]
        public static extern void EnqueueEventContext();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesEnqueueEventByName@4", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern ulong EnqueueEventByName(string name);
        
        [DllImport("mss32.dll", EntryPoint = "_MilesSetSoundStartOffset@12")]
        public static extern void SetSoundStartOffset();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesAddEventSystem@4")]
        public static extern void AddEventSystem();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesGetVarI@12")]
        public static extern void GetVarI();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesGetVarF@12")]
        public static extern void GetVarF();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesSetVarF@12")]
        public static extern void SetVarF();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesSetVarI@12")]
        public static extern void SetVarI();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesRequeueAsyncs@0")]
        public static extern void RequeueAsyncs();

        [DllImport("mss32.dll", EntryPoint = "_MilesAsyncFileRead@4")]
        public static extern void AsyncFileRead();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesAsyncFileCancel@4")]
        public static extern void AsyncFileCancel();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesAsyncFileStatus@8")]
        public static extern void AsyncFileStatus();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesAsyncStartup@0")]
        public static extern void AsyncStartup();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesAsyncShutdown@0")]
        public static extern void AsyncShutdown();
        
        [DllImport("mss32.dll", EntryPoint = "_MilesAsyncSetPaused@4")]
        public static extern void AsyncSetPaused();

    }
}
