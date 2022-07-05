using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Models;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Abstract
{
    public interface IProlongPackage
    {
        v_Get_InvoviceById_package_backup ProlongPackage_VeeamBackup(int cust_id , int vcc_id); //Prolong Package VeeamBackup Enterprise
        v_Get_InvoviceById_package_replication ProlongPackage_VeeamReplication(int cust_id, int vcc_id);//Prolong Package VeeamReplication Enterprise
        v_Get_InvoviceById_package_backup_resaller ProlongPackage_VeeamBackupResaller(int cust_id, int vcc_id);//Prolong Package VeeamBackup Rasaller
        v_Get_InvoviceById_package_replication_resaller ProlongPackage_VeeamReplicationResaller(int cust_id, int vcc_id);//Prolong Package VeeamReplication Rasaller

        //nakivo
        v_Get_InvoviceById_package_backup_Nakivo ProlongPackage_NakivoBackup(int cust_id, int vcc_id);
        v_Get_InvoviceById_package_backup_Nakivo_resaller ProlongPackage_NakivoBackupResaller(int cust_id, int vcc_id);
    }
}
