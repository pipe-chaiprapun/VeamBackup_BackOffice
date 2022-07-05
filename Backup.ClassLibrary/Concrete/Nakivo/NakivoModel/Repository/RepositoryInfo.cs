using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Repository.Info
{

    public class RepositoryInfo
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
        public int id { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string changeStatus { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long size { get; set; }
        public long free { get; set; }
        public long allocated { get; set; }
        public long consumed { get; set; }
        public bool attached { get; set; }
        public bool consistent { get; set; }
        public string path { get; set; }
        public int transporterId { get; set; }
        public string transporterName { get; set; }
        public Transportercaps transporterCaps { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int storageSize { get; set; }
        public int chunkSize { get; set; }
        public bool autoSize { get; set; }
        public string volumeType { get; set; }
        public int backupCount { get; set; }
        public Hvtypebackupcount hvTypeBackupCount { get; set; }
        public Hvtypebackuphasrootdiskcount hvTypeBackupHasRootDiskCount { get; set; }
        public string compression { get; set; }
        public int compressionRatio { get; set; }
        public bool deduplication { get; set; }
        public int deduplicationRatio { get; set; }
        public bool selfHeal { get; set; }
        public bool encryption { get; set; }
        public object encryptionPassword { get; set; }
        public bool lockedShared { get; set; }
        public bool lockedExclusive { get; set; }
        public object[] lockReasons { get; set; }
        public bool preventModification { get; set; }
        public bool wasEdited { get; set; }
        public bool wasDiscoveredOnce { get; set; }
        public bool wasImported { get; set; }
        public bool wasCreated { get; set; }
        public bool useSelfHealSchedule { get; set; }
        public object selfHealSchedule { get; set; }
        public bool selfHealOverrideJobs { get; set; }
        public bool useVerificationSchedule { get; set; }
        public object verificationSchedule { get; set; }
        public bool verificationOverrideJobs { get; set; }
        public bool useConsolidationSchedule { get; set; }
        public object consolidationSchedule { get; set; }
        public bool consolidationOverrideJobs { get; set; }
        public bool useDetachSchedule { get; set; }
        public object detachSchedule { get; set; }
        public object attachSchedule { get; set; }
        public bool deleteAndRecreateOnAttach { get; set; }
        public int progress { get; set; }
        public object operationStart { get; set; }
        public int operationStartRelative { get; set; }
        public object alertErrorCode { get; set; }
        public object alertTitle { get; set; }
        public object alertDescription { get; set; }
    }

    public class Transportercaps
    {
        public bool windowsGuestsRecoverySupport { get; set; }
        public bool cifsShareSupport { get; set; }
        public bool linuxGuestsRecoverySupport { get; set; }
        public bool vmwarevSphereSupport { get; set; }
        public bool repositoryManagementSupport { get; set; }
        public bool awsEc2Support { get; set; }
        public bool flashVmBootSupport { get; set; }
        public bool nfsShareSupport { get; set; }
        public bool msHypervSupport { get; set; }
        public bool repositoryEncryptionSupport { get; set; }
    }

    public class Hvtypebackupcount
    {
        public int VMWARE { get; set; }
        public int HYPERV { get; set; }
    }

    public class Hvtypebackuphasrootdiskcount
    {
    }

}
