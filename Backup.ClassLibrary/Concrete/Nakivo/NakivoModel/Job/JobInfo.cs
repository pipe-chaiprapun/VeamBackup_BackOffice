using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Job.Info
{

    public class JobInfo
    {
        public string action { get; set; }
        public string method { get; set; }
        public string tid { get; set; }
        public string type { get; set; }
        public object message { get; set; }
        public object where { get; set; }
        public object cause { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Child[] children { get; set; }
        public int totalCount { get; set; }
    }

    public class Child
    {
        public string name { get; set; }
        public int id { get; set; }
        public string vid { get; set; }
        public string hvType { get; set; }
        public Hvtypebackupcount hvTypeBackupCount { get; set; }
        public Hvtypebackuphasrootdiskcount hvTypeBackupHasRootDiskCount { get; set; }
        public string status { get; set; }
        public string jobType { get; set; }
        public DateTime added { get; set; }
        public DateTime updated { get; set; }
        public int vmCount { get; set; }
        public int diskCount { get; set; }
        public int sourcesSize { get; set; }
        public bool isEnabled { get; set; }
        public bool isLicensed { get; set; }
        public bool isEdited { get; set; }
        public bool isLocked { get; set; }
        public bool isRemoved { get; set; }
        public int averageDurationMs { get; set; }
        public int averageDurationSampleCount { get; set; }
        public string crState { get; set; }
        public object crDate { get; set; }
        public int crDateRelative { get; set; }
        public int crVmPlanned { get; set; }
        public int crVmOk { get; set; }
        public int crVmFailed { get; set; }
        public int crVmStopped { get; set; }
        public int crProgress { get; set; }
        public bool crAdhoc { get; set; }
        public bool hasLastRun { get; set; }
        public string lrState { get; set; }
        public DateTime lrDate { get; set; }
        public DateTime lrFinishDate { get; set; }
        public int lrSpeed { get; set; }
        public int lrDurationMs { get; set; }
        public int lrDataKb { get; set; }
        public int lrVmOk { get; set; }
        public int lrVmFailed { get; set; }
        public int lrVmStopped { get; set; }
        public bool lrAdhoc { get; set; }
        public int lrCompressionRatio { get; set; }
        public string differentialTrackingMode { get; set; }
        public string preScriptExecutionMode { get; set; }
        public string preScriptBehavior { get; set; }
        public string preScriptErrorMode { get; set; }
        public object preScriptPath { get; set; }
        public string postScriptExecutionMode { get; set; }
        public string postScriptBehavior { get; set; }
        public string postScriptErrorMode { get; set; }
        public object postScriptPath { get; set; }
        public string thinDiskMode { get; set; }
        public string ebsVolumeMode { get; set; }
        public string temporaryVolumeType { get; set; }
        public string networkAccelerationMode { get; set; }
        public string encryptionMode { get; set; }
        public string applicationAwareMode { get; set; }
        public Retentionpolicy retentionPolicy { get; set; }
        public bool powerVmsOn { get; set; }
        public bool generateMac { get; set; }
        public object recoveryType { get; set; }
        public string transporterMode { get; set; }
        public string logTruncationMode { get; set; }
        public string screenshotVerificationMode { get; set; }
        public Object[] objects { get; set; }
        public Transporter[] transporters { get; set; }
        public Storage[] storages { get; set; }
        public Schedule[] schedules { get; set; }
        public object[] lockReasons { get; set; }
    }

    public class Hvtypebackupcount
    {
        public int VMWARE { get; set; }
    }

    public class Hvtypebackuphasrootdiskcount
    {
    }

    public class Retentionpolicy
    {
        public string retentionMode { get; set; }
        public int maxCount { get; set; }
        public object keepDayCount { get; set; }
        public object keepWeekCount { get; set; }
        public object keepMonthCount { get; set; }
        public object keepYearCount { get; set; }
    }

    public class Object
    {
        public string vid { get; set; }
        public string lrState { get; set; }
        public int lrSpeed { get; set; }
        public long lrDataTransferredUncompressed { get; set; }
        public int lrDuration { get; set; }
        public string crState { get; set; }
        public int crProgress { get; set; }
        public string sourceVid { get; set; }
        public string sourceName { get; set; }
        public string sourcePowerState { get; set; }
        public string sourceSubType { get; set; }
        public string targetVid { get; set; }
        public string targetName { get; set; }
        public string targetPowerState { get; set; }
        public object targetSubType { get; set; }
        public object verificationState { get; set; }
        public object screenshotName { get; set; }
        public string flashBootState { get; set; }
    }

    public class Transporter
    {
        public bool isAuto { get; set; }
        public bool usedAsSource { get; set; }
        public bool usedAsTarget { get; set; }
        public int maxLoadFactor { get; set; }
        public int currentTotalLoad { get; set; }
        public string vid { get; set; }
        public string name { get; set; }
        public string state { get; set; }
    }

    public class Storage
    {
        public string vid { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public long free { get; set; }
        public long used { get; set; }
        public string state { get; set; }
        public bool online { get; set; }
        public bool infiniteSize { get; set; }
        public object type { get; set; }
    }

    public class Schedule
    {
        public bool enabled { get; set; }
        public string type { get; set; }
        public string monthlyEveryType { get; set; }
        public string everyType { get; set; }
        public int every { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int dayOfWeek { get; set; }
        public int dayOfMonth { get; set; }
        public int month { get; set; }
        public string timezone { get; set; }
        public int on { get; set; }
        public object triggerItem { get; set; }
        public object triggerRunType { get; set; }
        public object triggerEvents { get; set; }
        public DateTime nextRun { get; set; }
        public int position { get; set; }
        public object triggerItemName { get; set; }
        public int timezoneOffsetMs { get; set; }
        public int nextRunRelative { get; set; }
    }

}
