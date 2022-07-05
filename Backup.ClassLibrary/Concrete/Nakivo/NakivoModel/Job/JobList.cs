using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Job
{

    public class JobList
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
        public int id { get; set; }
        public object vid { get; set; }
        public object name { get; set; }
        public string status { get; set; }
        public Jobcount jobCount { get; set; }
        public int jobCountEnabled { get; set; }
        public int jobCountLicensed { get; set; }
        public Hvtypebackupcount hvTypeBackupCount { get; set; }
        public Hvtypebackuphasrootdiskcount hvTypeBackupHasRootDiskCount { get; set; }
        public int vmCount { get; set; }
        public int diskCount { get; set; }
        public int sourcesSize { get; set; }
        public bool isEnabled { get; set; }
        public bool isRemoved { get; set; }
        public int crJobRunning { get; set; }
        public int crVmRunning { get; set; }
        public bool hasLastRun { get; set; }
        public int lrJobOk { get; set; }
        public int lrJobFailed { get; set; }
        public int lrJobStopped { get; set; }
        public int[] childJobIds { get; set; }
        public int[] immediateChildJobIds { get; set; }
        public Transporter[] transporters { get; set; }
        public Storage[] storages { get; set; }
    }

    public class Jobcount
    {
        public VMWARE VMWARE { get; set; }
        public AWS AWS { get; set; }
        public HYPERV HYPERV { get; set; }
        public NONE NONE { get; set; }
    }

    public class VMWARE
    {
        public int REPLICATION { get; set; }
        public int BACKUP { get; set; }
        public int RECOVERY_VMS { get; set; }
        public int RECOVERY_FILES { get; set; }
        public int RECOVERY_OBJECTS { get; set; }
        public int BACKUP_COPY { get; set; }
        public int FLASH_BOOT { get; set; }
    }

    public class AWS
    {
        public int REPLICATION { get; set; }
        public int BACKUP { get; set; }
        public int RECOVERY_VMS { get; set; }
        public int RECOVERY_FILES { get; set; }
        public int RECOVERY_OBJECTS { get; set; }
        public int BACKUP_COPY { get; set; }
        public int FLASH_BOOT { get; set; }
    }

    public class HYPERV
    {
        public int REPLICATION { get; set; }
        public int BACKUP { get; set; }
        public int RECOVERY_VMS { get; set; }
        public int RECOVERY_FILES { get; set; }
        public int RECOVERY_OBJECTS { get; set; }
        public int BACKUP_COPY { get; set; }
        public int FLASH_BOOT { get; set; }
    }

    public class NONE
    {
        public int REPLICATION { get; set; }
        public int BACKUP { get; set; }
        public int RECOVERY_VMS { get; set; }
        public int RECOVERY_FILES { get; set; }
        public int RECOVERY_OBJECTS { get; set; }
        public int BACKUP_COPY { get; set; }
        public int FLASH_BOOT { get; set; }
    }

    public class Hvtypebackupcount
    {
        public int VMWARE { get; set; }
        public int HYPERV { get; set; }
    }

    public class Hvtypebackuphasrootdiskcount
    {
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

}
