package project.ucsc.mobilehris.mobilehris;


public class table_stucture {

    public static abstract class tblMyProfile {
        public static final String MyProfileProfID = "ProfID";
        public static final String MyProfileRegID = "RegID";
        public static final String MyProfileBranch = "Branch";
        public static final String MyProfileDispName = "DispName";
        public static final String MyProfileEPFNo = "EPFNo";
        public static final String MyProfileDept = "Dept";
        public static final String MyProfileDesig = "Desig";
        public static final String MyProfileType = "Type";
        public static final String MyProfileNIC = "NIC";
        public static final String MyProfileGend = "Gend";
        public static final String MyProfileDtOfB= "DtOfB";
        public static final String MyProfileDtOfJoin = "DtOfJoin";
        public static final String MyProfileBank = "bank";
        public static final String MyProfileBBranch = "bBranch";
        public static final String MyProfileAcc = "account";
        public static final String MyProfileBloodG = "blood";
        public static final String MyProfileSynced = "Synced";
        public static final String MyProfileName = "tblMyProfile";
    }

    public static abstract class tblLeaveBalances{
        public static final String LeaveBalancesLID = "LID";
        public static final String LeaveBalancesRegID = "RegID";
        public static final String LeaveBalancesLvTypeID = "LvTypeID";
        public static final String LeaveBalancesLvName = "LvName";
        public static final String LeaveBalancesAllocate = "Allocate";
        public static final String LeaveBalancesUtilized = "Utilized";
        public static final String LeaveBalancesBal = "Bal";
        public static final String LeaveBalancesCYear = "CYear";
        public static final String LeaveBalancesCMonth = "CMonth";
        public static final String LeaveBalancesName = "tblLeaveBalances";
    }

    public static abstract class tblPayrollData{
        public static final String PayrollDataID = "PayID";
        public static final String PayrollDataRegID = "RegID";
        public static final String PayrollDataCYear = "CYear";
        public static final String PayrollDataCMonth = "CMonth";
        public static final String PayrollDataSalItem = "SalItem";
        public static final String PayrollDataType = "Type";
        public static final String PayrollDataAmount = "Amount";
        public static final String PayrollDataName = "tblPayrollData";
    }

    public static abstract class tblTimeCard {
        public static final String TimeCardTimeID = "TimeID";
        public static final String TimeCardRegID = "RegID";
        public static final String TimeCardAtDate = "AtDate";
        public static final String TimeCardInTime = "InTime";
        public static final String TimeCardOutTime = "OutTime";
        public static final String TimeCardShiftLine = "ShiftLine";
        public static final String TimeCardDayType = "DayType";
        public static final String TimeCardShift= "Shift";
        public static final String TimeCardWrkHrs = "WorkHrs";
        public static final String TimeCardLateMin= "LateMin";
        public static final String TimeCardNrWorkDay= "NrWorkDay";
        public static final String TimeCardWorkUnit= "WorkUnit";
        public static final String TimeCardName= "tblTimeCard";
    }

    public static abstract class tblMessageData {
        public static final String MessageDataMsgID = "MsgID";
        public static final String MessageDataMessage = "Message";
        public static final String MessageDataCriticalLevel = "CriticalLeavel";
        public static final String MessageDataStatus = "mStatus";
        public static final String MessageDataName = "tblMessageData";
    }

    public static abstract class tblLeaveData{
        public static final String LeaveDataLID = "LID";
        public static final String LeaveDataRegID = "RegID";
        public static final String LeaveDataRqID = "RqID";
        public static final String LeaveDataLvDate = "LvDate";
        public static final String LeaveDataLvType = "LvType";
        public static final String LeaveDataNoLv = "NoLv";
        public static final String LeaveDataLvStatus = "LvStatus";
        public static final String LeaveDataLeStatus = "LeStatus";
        public static final String LeaveDataName = "tblLeaveData";
    }

    public static abstract class tblUserData {
        public static final String userID = "C_ID";
        public static final String userName = "C_userna";
        public static final String userAddress = "C_addres";
        public static final String userEmail= "C_e_mail";
        public static final String userMobile = "C_mobnum";
        public static final String userPassword = "C_passwd";
        public static final String userRegID = "C_regID";
        public static final String userLatGData = "C_last_data";
        public static final String userMac = "C_mac";
        public static final String userDataName = "tblUserData";
    }
}
