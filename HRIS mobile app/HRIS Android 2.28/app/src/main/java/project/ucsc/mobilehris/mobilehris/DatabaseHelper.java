package project.ucsc.mobilehris.mobilehris;

import android.content.ContentValues;
import android.content.Context;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import static project.ucsc.mobilehris.mobilehris.table_stucture.tblMyProfile.MyProfileName;
import static project.ucsc.mobilehris.mobilehris.table_stucture.tblUserData.userDataName;


public class DatabaseHelper extends SQLiteOpenHelper {
    DatabaseHelper databaseHelper;
    SQLiteDatabase sqLiteDatabase;
    Context context;

    private static final String DATABASE_NAME = "dbHRISM";
    private static int DATABASE_VERSION = 1;

    private static final String CREATE_QUERY_TBLMYPROFILE =
            "CREATE TABLE IF NOT EXISTS "
                    + MyProfileName + " ( "
                    + table_stucture.tblMyProfile.MyProfileProfID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + table_stucture.tblMyProfile.MyProfileRegID + " VARCHAR(8), "
                    + table_stucture.tblMyProfile.MyProfileDispName + " VARCHAR(240), "
                    + table_stucture.tblMyProfile.MyProfileEPFNo + " VARCHAR(8), "
                    + table_stucture.tblMyProfile.MyProfileDept + " VARCHAR(170), "
                    + table_stucture.tblMyProfile.MyProfileDesig + " VARCHAR(170), "
                    + table_stucture.tblMyProfile.MyProfileType + " VARCHAR(140), "
                    + table_stucture.tblMyProfile.MyProfileNIC + " VARCHAR(12), "
                    + table_stucture.tblMyProfile.MyProfileBranch + " VARCHAR(178), "
                    + table_stucture.tblMyProfile.MyProfileGend + " VARCHAR(10), "
                    + table_stucture.tblMyProfile.MyProfileDtOfB + " DATE, "
                    + table_stucture.tblMyProfile.MyProfileDtOfJoin + " DATE, "
                    + table_stucture.tblMyProfile.MyProfileBank + " VARCHAR(78), "
                    + table_stucture.tblMyProfile.MyProfileBBranch+ " VARCHAR(115), "
                    + table_stucture.tblMyProfile.MyProfileAcc + " VARCHAR(15), "
                    + table_stucture.tblMyProfile.MyProfileBloodG + " VARCHAR(78),"
                    + table_stucture.tblMyProfile.MyProfileSynced + " INTEGER);";

    private static final String CREATE_QUERY_TBLLEAVEBALANCE =
            "CREATE TABLE IF NOT EXISTS "
                    + table_stucture.tblLeaveBalances.LeaveBalancesName + " ( "
                    + table_stucture.tblLeaveBalances.LeaveBalancesLID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + table_stucture.tblLeaveBalances.LeaveBalancesRegID + " VARCHAR(8), "
                    + table_stucture.tblLeaveBalances.LeaveBalancesLvTypeID + " VARCHAR(3), "
                    + table_stucture.tblLeaveBalances.LeaveBalancesLvName + " VARCHAR(125), "
                    + table_stucture.tblLeaveBalances.LeaveBalancesAllocate + " NUMERIC (18,2), "
                    + table_stucture.tblLeaveBalances.LeaveBalancesUtilized + " NUMERIC (18,2), "
                    + table_stucture.tblLeaveBalances.LeaveBalancesBal + " NUMERIC (18,2), "
                    + table_stucture.tblLeaveBalances.LeaveBalancesCYear + " INTEGER, "
                    + table_stucture.tblLeaveBalances.LeaveBalancesCMonth + " INTEGER );";

    private static final String CREATE_QUERY_TBLPAYROLLDATA =
            "CREATE TABLE IF NOT EXISTS "
                    + table_stucture.tblPayrollData.PayrollDataName + " ( "
                    + table_stucture.tblPayrollData.PayrollDataID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + table_stucture.tblPayrollData.PayrollDataCYear + " INTEGER, "
                    + table_stucture.tblPayrollData.PayrollDataCMonth + " INTEGER, "
                    + table_stucture.tblPayrollData.PayrollDataRegID + " VARCHAR(8), "
                    + table_stucture.tblPayrollData.PayrollDataSalItem + " VARCHAR(188), "
                    + table_stucture.tblPayrollData.PayrollDataType + " VARCHAR(3), "
                    + table_stucture.tblPayrollData.PayrollDataAmount + " NUMERIC (18,2));";

    private static final String CREATE_QUERY_TBLTIMECARD =
            "CREATE TABLE IF NOT EXISTS "
                    + table_stucture.tblTimeCard.TimeCardName + " ( "
                    + table_stucture.tblTimeCard.TimeCardTimeID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + table_stucture.tblTimeCard.TimeCardRegID + " VARCHAR(8), "
                    + table_stucture.tblTimeCard.TimeCardAtDate + " DATE, "
                    + table_stucture.tblTimeCard.TimeCardInTime + " DATETIME, "
                    + table_stucture.tblTimeCard.TimeCardOutTime + " DATETIME, "
                    + table_stucture.tblTimeCard.TimeCardShiftLine + " INTEGER, "
                    + table_stucture.tblTimeCard.TimeCardLateMin + " INTEGER, "
                    + table_stucture.tblTimeCard.TimeCardDayType + " VARCHAR(15),"
                    + table_stucture.tblTimeCard.TimeCardShift + " VARCHAR(15), "
                    + table_stucture.tblTimeCard.TimeCardWrkHrs + " NUMERIC (18,2), "
                    + table_stucture.tblTimeCard.TimeCardNrWorkDay + " NUMERIC (18,2), "
                    + table_stucture.tblTimeCard.TimeCardWorkUnit + " NUMERIC (18,2));";

    private static final String CREATE_QUERY_TBLMESSAGEDATA =
            "CREATE TABLE IF NOT EXISTS "
                    + table_stucture.tblMessageData.MessageDataName + " ( "
                    + table_stucture.tblMessageData.MessageDataMsgID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + table_stucture.tblMessageData.MessageDataMessage + " VARCHAR(460), "
                    + table_stucture.tblMessageData.MessageDataCriticalLevel + " INTEGER , "
                    + table_stucture.tblMessageData.MessageDataStatus + " INTEGER);";

    private static final String CREATE_QUERY_TBLLEAVEDATA =
            "CREATE TABLE IF NOT EXISTS "
                    + table_stucture.tblLeaveData.LeaveDataName + " ( "
                    + table_stucture.tblLeaveData.LeaveDataLID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + table_stucture.tblLeaveData.LeaveDataRegID + " VARCHAR(8), "
                    + table_stucture.tblLeaveData.LeaveDataRqID + " VARCHAR(10), "
                    + table_stucture.tblLeaveData.LeaveDataLvDate + " DATE, "
                    + table_stucture.tblLeaveData.LeaveDataLvType + " VARCHAR(48), "
                    + table_stucture.tblLeaveData.LeaveDataNoLv + " NUMERIC (18,2), "
                    + table_stucture.tblLeaveData.LeaveDataLvStatus + " INTEGER, "
                    + table_stucture.tblLeaveData.LeaveDataLeStatus + " VARCHAR (4));";

    private static final String CREATE_QUERY_TBLUSERDATA =
            "CREATE TABLE IF NOT EXISTS "
                    + userDataName + " ( "
                    + table_stucture.tblUserData.userID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + table_stucture.tblUserData.userName + " VARCHAR(78), "
                    + table_stucture.tblUserData.userAddress + " VARCHAR(228), "
                    + table_stucture.tblUserData.userEmail + " VARCHAR(128), "
                    + table_stucture.tblUserData.userMobile + " VARCHAR(10), "
                    + table_stucture.tblUserData.userPassword + " VARCHAR(20),"
                    + table_stucture.tblUserData.userRegID + " VARCHAR(06),"
                    + table_stucture.tblUserData.userLatGData + " DATE,"
                    + table_stucture.tblUserData.userMac + " VARCHAR(30));";

    //default testing values
    private static final String INSERT_QUERY_TBLMYPROFILE = "INSERT INTO `tblMyProfile` (`ProfID`, `RegID`, `Branch`,`DispName`, `EPFNo`, `Dept`,`Desig`, `Type`, `NIC`,`Gend`, `DtOfB`, `DtOfJoin`,`bank`,`bBranch`,`account`,`blood`,`Synced`) VALUES" +
            "(1, '000006', 'Kurunegala Branch','D K H K Weerasinghe','000012','IT Departent','IT Manager','Permanant','893663150V','Male','1989-12-31','2019-07-08','Commercial Bank','Hurunegala high','092378567328','B Positive',0);";

    private static final String INSERT_QUERY_TBLLEAVEBALANCE = "INSERT INTO `tblLeaveBalances` (`LID`, `RegID`, `LvTypeID`,`LvName`, `Allocate`, `Utilized`,`Bal`, `CYear`, `CMonth`) VALUES" +
            "(1,'000006', '002', 'Casual Leave',7,2,5,2018,1)," +
            "(2,'000006', '001', 'Anual Leave',14,2,12,2018,1)," +
            "(3,'000006', '003', 'Vacation Leave',7,2,5,2018,1)," +
            "(4,'000006', '004', 'Sick Leave',7,2,5,2018,1);";

    private static final String INSERT_QUERY_TBLTIMECARD = "INSERT INTO `tblTimeCard` (`TimeID`, `RegID`, `AtDate`,`InTime`, `OutTime`, `ShiftLine`,`DayType`, `Shift`, `WorkHrs`,`LateMin`, `NrWorkDay`, `WorkUnit`) VALUES" +
            "(1, '000006', '2019-01-01','2019-01-01 08:00:00.000','2019-01-01 17:35:00.000',1,'WRK','ESY',10,0,1,1)," +
            "(2, '000006', '2019-01-02','2019-01-02 08:01:00.000','2019-01-02 17:36:00.000',1,'WRK','ESY',10,1,1,1)," +
            "(3, '000006', '2019-01-03','2019-01-03 08:02:00.000','2019-01-03 17:37:00.000',1,'WRK','ESY',10,2,1,1)," +
            "(4, '000006', '2019-01-04','2019-01-04 08:03:00.000','2019-01-04 17:38:00.000',1,'WRK','ESY',10,3,1,1)," +
            "(5, '000006', '2019-01-05','2019-01-05 08:04:00.000','2019-01-05 17:39:00.000',1,'OFF','ESY',10,4,1,0);";

    private static final String INSERT_QUERY_TBLPAYROLLDATA = "INSERT INTO `tblPayrollData` (`PayID`, `RegID`, `CYear`, `CMonth`, `SalItem`, `Type`, `Amount`) VALUES" +
            "(1, '000006', 2018, 1, 'Basic Salary', 2, '65000')," +
            "(2, '000006', 2018, 1, 'Budget Allowance', 2, '2500')," +
            "(3, '000006', 2018, 1, 'Total For EPF', 2, '67500')," +
            "(4, '000006', 2018, 1, 'No Pay', 2, '0')," +
            "(5, '000006', 2018, 1, 'Other Allowance', 2, '265000')," +
            "(6, '000006', 2018, 1, 'Vehical Allowance', 2, '165000')," +
            "(7, '000006', 2018, 1, 'Fuel LLowance', 2, '65000')," +
            "(8, '000006', 2018, 1, 'Over Time', 2, '120000')," +
            "(9, '000006', 2018, 1, 'Gross Salary', 2, '640000')," +
            "(10, '000006', 2018, 1, 'Total Deduction', 2, '65000')," +
            "(11, '000006', 2018, 1, 'Net Salary', 2, '580000');";

    private static final String INSERT_QUERY_TBLMESSAGEDATA = "INSERT INTO `tblMessageData` (`MsgID`, `Message`,`CriticalLeavel`, `mStatus`) VALUES" +
            "('1', 'You have a meeting on 2nd of January at ballroom. HR Manager',1,0)," +
            "('2', 'You have a meeting on 2nd of January at ballroom. HR Manager',2,0)," +
            "('3', 'You have a meeting on 2nd of January at ballroom. HR Manager',1,0)," +
            "('4', 'You have a meeting on 2nd of January at ballroom. HR Manager',1,1)," +
            "('5', 'You have a meeting on 2nd of January at ballroom. HR Manager',1,1);";

    private static final String INSERT_QUERY_TBLLEAVEDATA = "INSERT INTO `tblLeaveData` (`LID`, `RegID`, `RqID`,`LvDate`, `LvType`, `NoLv`,`LvStatus`,`LeStatus`) VALUES" +
            "('1', '000006', '0000001','2019-01-07','ANL',0.5,0,'0|0')," +
            "('2', '000006', '0000001','2019-01-08','ANL',1,0,'0|0')," +
            "('3', '000006', '0000001','2019-01-09','ANL',0.5,0,'0|1')," +
            "('4', '000006', '0000001','2019-01-10','CAL',1,0,'1|0')," +
            "('5', '000006', '0000001','2019-01-17','ANL',0.5,0,'0|0')," +
            "('6', '000006', '0000001','2019-01-18','CAL',1,0,'1|0')," +
            "('7', '000006', '0000001','2019-01-19','VAL',0.5,1,'0|0');";

    private static final String INSERT_QUERY_TBLUSERDATA = "INSERT INTO `tblUserData` (`C_ID`, `C_userna`, `C_addres`,`C_e_mail`, `C_mobnum`, `C_passwd`,`C_regID`,`C_last_data`,`C_mac`) VALUES" +
            "(1, 'KasunUser', 'Kasun Shoe Mart, Rambe, MaEliya','kasunsliate1@gmail.com','0773955776','1234','000006','2019-06-01','84:be:52:71:7b:af');";

    public DatabaseHelper(Context context) {

        super(context, DATABASE_NAME, null, DATABASE_VERSION);
        Log.e("DATABASE OPERATIONS", "Database Created Or Opened...");
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(CREATE_QUERY_TBLMYPROFILE);
        Log.e("DATABASE OPERATIONS", "Profile table Created...");
        db.execSQL(CREATE_QUERY_TBLLEAVEBALANCE);
        Log.e("DATABASE OPERATIONS", "Leave balance table Created...");
        db.execSQL(CREATE_QUERY_TBLPAYROLLDATA);
        Log.e("DATABASE OPERATIONS", "Payroll data table Created...");
        db.execSQL(CREATE_QUERY_TBLTIMECARD);
        Log.e("DATABASE OPERATIONS", "Time card table Created...");
        db.execSQL(CREATE_QUERY_TBLMESSAGEDATA);
        Log.e("DATABASE OPERATIONS", "Message data table Created...");
        db.execSQL(CREATE_QUERY_TBLLEAVEDATA);
        Log.e("DATABASE OPERATIONS", "Leave data table Created...");
        db.execSQL(CREATE_QUERY_TBLUSERDATA);
        Log.e("DATABASE OPERATIONS", "User data table Created...");

        db.execSQL(INSERT_QUERY_TBLMYPROFILE);
        db.execSQL(INSERT_QUERY_TBLLEAVEBALANCE);
        db.execSQL(INSERT_QUERY_TBLPAYROLLDATA);
        db.execSQL(INSERT_QUERY_TBLTIMECARD);
        db.execSQL(INSERT_QUERY_TBLMESSAGEDATA);
        db.execSQL(INSERT_QUERY_TBLLEAVEDATA);
        db.execSQL(INSERT_QUERY_TBLUSERDATA);
    }

    public void insert_tblMyProfile(String strRegID, String strBranch, String strDispName, String strEpfNo, String strDept, String strDesig, String strType, String strNIC, String strGend, String strDtOfBirth, String strDtOfJoin, String strBank,String strBBranch,String strAcc,String strBlood,String strSynced, SQLiteDatabase db) {
        ContentValues MyProfileContent = new ContentValues();
        //bookcontent.put(table_stucture.book_table.TBLBOOK_ID, "");
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileRegID, strRegID);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileBranch, strBranch);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileDispName, strDispName);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileEPFNo, strEpfNo);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileDept, strDept);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileDesig, strDesig);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileType, strType);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileNIC, strNIC);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileGend, strGend);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileDtOfB, strDtOfBirth);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileDtOfJoin, strDtOfJoin);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileBank, strBank);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileBBranch, strBBranch);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileAcc, strAcc);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileBloodG, strBlood);
        MyProfileContent.put(table_stucture.tblMyProfile.MyProfileSynced, strSynced);
        db.insert(MyProfileName, null, MyProfileContent);
        Log.e("DATABASE OPERATIONS", "My profile detail inserted...");
    }

    public void insert_tblLeaveBalances(String strRegID, String strLyType, String strLvName, Double dblAllocate, Double dblUtilized, Double dblBalance, Integer intCYear, Integer intCMonth, SQLiteDatabase db) {
        ContentValues LeaveBalanceContent = new ContentValues();
        //member_details.put(table_stucture.member_table.TBLCARD_NUMBER,"");
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesRegID, strRegID);
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesLvTypeID, strLyType);
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesLvName, strLvName);
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesAllocate, dblAllocate);
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesUtilized, dblUtilized);
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesBal, dblBalance);
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesCYear, intCYear);
        LeaveBalanceContent.put(table_stucture.tblLeaveBalances.LeaveBalancesCMonth, intCMonth);
        db.insert(table_stucture.tblLeaveBalances.LeaveBalancesName, null, LeaveBalanceContent);
        Log.e("DATABASE OPERATIONS", "Leave balances detail inserted...");
    }

    public void inser_tblPayrollData(String strRegID, Integer intCYear, Integer intCMonth, String strSalItem, Integer intDtType, Double dblAmount, SQLiteDatabase db) {
        ContentValues PayrollDataContent = new ContentValues();
        PayrollDataContent.put(table_stucture.tblPayrollData.PayrollDataRegID, strRegID);
        PayrollDataContent.put(table_stucture.tblPayrollData.PayrollDataCYear, intCYear);
        PayrollDataContent.put(table_stucture.tblPayrollData.PayrollDataCMonth, intCMonth);
        PayrollDataContent.put(table_stucture.tblPayrollData.PayrollDataSalItem, strSalItem);
        PayrollDataContent.put(table_stucture.tblPayrollData.PayrollDataType, intDtType);
        PayrollDataContent.put(table_stucture.tblPayrollData.PayrollDataAmount, dblAmount);
        db.insert(table_stucture.tblPayrollData.PayrollDataName, null, PayrollDataContent);
        Log.e("DATABASE OPERATIONS", "Payroll detail inserted...");
    }

    public void insert_tblTimeCard(String strRegID, String strAtDate, String strInTime, String strOutTime, Integer intShuftLine, String strDayType, String strShift, Double dblWrkHrs, Integer intLateMin, Double dblNrWorkDay, Double dblWorkUnit, SQLiteDatabase db) {
        ContentValues timeCardContent = new ContentValues();
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardRegID, strRegID);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardAtDate, strAtDate);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardInTime, strInTime);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardOutTime, strOutTime);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardShiftLine, intShuftLine);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardDayType, strDayType);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardShift, strShift);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardWrkHrs, dblWrkHrs);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardLateMin, intLateMin);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardNrWorkDay, dblNrWorkDay);
        timeCardContent.put(table_stucture.tblTimeCard.TimeCardWorkUnit, dblWorkUnit);
        db.insert(table_stucture.tblTimeCard.TimeCardName, null, timeCardContent);
        Log.e("DATABASE OPERATIONS", "Timecard detail inserted...");
    }

    public void insert_tblMessageData(String strMessage, Integer intCriticalLevel, Integer intStatus, SQLiteDatabase db) {
        ContentValues MessageDataContent = new ContentValues();
        MessageDataContent.put(table_stucture.tblMessageData.MessageDataMessage, strMessage);
        MessageDataContent.put(table_stucture.tblMessageData.MessageDataCriticalLevel, intCriticalLevel);
        MessageDataContent.put(table_stucture.tblMessageData.MessageDataStatus, intStatus);
        db.insert(table_stucture.tblMessageData.MessageDataName, null, MessageDataContent);
        Log.e("DATABASE OPERATIONS", "Message detail inserted...");
    }

    public void insert_tblLeaveData(String strRegID, String strRqID, String strLvDate, String strLvType, Double dblNoLv, Integer intLvStatus, String strLeStatus, SQLiteDatabase db) {
        ContentValues LeaveDataContent = new ContentValues();
        LeaveDataContent.put(table_stucture.tblLeaveData.LeaveDataRegID, strRegID);
        LeaveDataContent.put(table_stucture.tblLeaveData.LeaveDataRqID, strRqID);
        LeaveDataContent.put(table_stucture.tblLeaveData.LeaveDataLvDate, strLvDate);
        LeaveDataContent.put(table_stucture.tblLeaveData.LeaveDataLvType, strLvType);
        LeaveDataContent.put(table_stucture.tblLeaveData.LeaveDataNoLv, dblNoLv);
        LeaveDataContent.put(table_stucture.tblLeaveData.LeaveDataLvStatus, intLvStatus);
        LeaveDataContent.put(table_stucture.tblLeaveData.LeaveDataLeStatus, strLeStatus);
        db.insert(table_stucture.tblLeaveData.LeaveDataName, null, LeaveDataContent);
        Log.e("DATABASE OPERATIONS", "Leavedata detail inserted...");
    }

    public void insert_tblUserData(String strUname, String strUAddress, String strUEmail, String srtrUMobile, String strUPassword,String strRegID,String strLastData,String strMac, SQLiteDatabase db) {
        ContentValues UserDataContent = new ContentValues();
        UserDataContent.put(table_stucture.tblUserData.userName, strUname);
        UserDataContent.put(table_stucture.tblUserData.userAddress, strUAddress);
        UserDataContent.put(table_stucture.tblUserData.userEmail, strUEmail);
        UserDataContent.put(table_stucture.tblUserData.userMobile, srtrUMobile);
        UserDataContent.put(table_stucture.tblUserData.userPassword, strUPassword);
        UserDataContent.put(table_stucture.tblUserData.userRegID, strRegID);
        UserDataContent.put(table_stucture.tblUserData.userLatGData, strLastData);
        UserDataContent.put(table_stucture.tblUserData.userMac, strMac);
        db.insert(userDataName, null, UserDataContent);
        Log.e("DATABASE OPERATIONS", "User detail inserted...");
    }

    public Cursor getAllTimeSheetData(SQLiteDatabase db) {
        Cursor TimeShheDataCursor;
        String[] TimeSheetData_columns = {table_stucture.tblTimeCard.TimeCardAtDate,
                table_stucture.tblTimeCard.TimeCardInTime,
                table_stucture.tblTimeCard.TimeCardOutTime,
                table_stucture.tblTimeCard.TimeCardShift,
                table_stucture.tblTimeCard.TimeCardWrkHrs};
        TimeShheDataCursor = db.query(table_stucture.tblTimeCard.TimeCardName, TimeSheetData_columns, null, null, null, null, null);
        return TimeShheDataCursor;
    }

    public Cursor getAllPayrollData(SQLiteDatabase db) {
        Cursor PayrollDataCursor;
        String[] PayrollData_columns = {table_stucture.tblPayrollData.PayrollDataCMonth,
                table_stucture.tblPayrollData.PayrollDataSalItem,
                table_stucture.tblPayrollData.PayrollDataAmount};
        PayrollDataCursor = db.query(table_stucture.tblPayrollData.PayrollDataName, PayrollData_columns, null, null, null, null, null);
        return PayrollDataCursor;
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // Drop old version table
        db.execSQL("Drop table if exists " + userDataName);

        // Create New Version table
        onCreate(db);
    }

    public boolean getUserValid(String prm_name, String prm_passwd, SharedPreferences sp) {
        SQLiteDatabase dataBase = this.getReadableDatabase();
        boolean boolRet = false;
        SharedPreferences.Editor ed = sp.edit();
        ed.clear();
        ed.commit();
        try {
            String getSQL = "SELECT * FROM " + userDataName + " WHERE C_userna='" + prm_name + "' and C_passwd='" + prm_passwd + "' ";
            Cursor c = dataBase.rawQuery(getSQL, null);
            Log.d("getRecord()", getSQL + "##Count = " + c.getCount());
            if (c.moveToFirst()) {
                boolRet = true;
                ed.putString("C_userna", c.getString(c.getColumnIndex(table_stucture.tblUserData.userName)));
            }
            ed.commit();

            c.close();
            dataBase.close();

        } catch (Exception e) {
            boolRet = false;
            Logger log = Logger.getLogger("");
            log.log(Level.WARNING, "App Error", e);
        }
        return boolRet;
    }

    public boolean getMacValid(String prm_mac, SharedPreferences sp) {
        SQLiteDatabase dataBase = this.getReadableDatabase();
        boolean boolRetm = false;
        SharedPreferences.Editor ed = sp.edit();
        ed.clear();
        ed.commit();
        try {
            String getSQL = "SELECT * FROM " + userDataName + " WHERE C_mac='" + prm_mac + "' ";
            Cursor c = dataBase.rawQuery(getSQL, null);
            Log.d("getRecord()", getSQL + "##Count = " + c.getCount());
            if (c.moveToFirst()) {
                boolRetm = true;
                ed.putString("C_mobnum", c.getString(c.getColumnIndex(table_stucture.tblUserData.userName)));
            }
            ed.commit();

            c.close();
            dataBase.close();

        } catch (Exception e) {
            boolRetm = false;
            Logger log = Logger.getLogger("");
            log.log(Level.WARNING, "App Error", e);
        }
        return boolRetm;
    }

    /*// Get User Details based on userid
    public void GetUserByUserId(String userid) {
        SQLiteDatabase db = this.getWritableDatabase();
        ArrayList<HashMap<String, String>> userList = new ArrayList<>();
        String query = "select C_ID,C_userna,C_e_mail,C_passwd,C_mobnum FROM tblUserData";
        Cursor cursor = db.query(  table_stucture.tblUserData.userDataName, new String[]{"C_ID", "C_userna", "C_e_mail","C_passwd","C_mobnum"}, "C_mobnum" , new String[]{String.valueOf( userid )}, null, null, null, null );
        if (cursor.moveToNext()) {
            HashMap<String, String> user = new HashMap<>();
            user.put( "C_ID", cursor.getString( cursor.getColumnIndex( "C_ID" ) ) );
            user.put( "C_userna", cursor.getString( cursor.getColumnIndex( "C_userna" ) ) );
            user.put( "C_e_mail", cursor.getString( cursor.getColumnIndex( "C_e_mail" ) ) );
            userList.add( user );
        }
        // return userList;
    }*/
    //Get relavant data from ID sucseed
    public Cursor getSelectedUser(String stMac, SQLiteDatabase db){

        String[] user_columns = {table_stucture.tblUserData.userID,
                table_stucture.tblUserData.userName,
                table_stucture.tblUserData.userPassword,
                table_stucture.tblUserData.userRegID,
                table_stucture.tblUserData.userLatGData};
        String selection = table_stucture.tblUserData.userMac + " LIKE ?" ;
        String [] selection_args = {stMac};
        Cursor user_cursor_s;
        user_cursor_s = db.query(userDataName,user_columns,selection,selection_args,null,null,null);
        return user_cursor_s;
    }

    // Get User Details based on userid
    public ArrayList<HashMap<String, String>> GetUserByUserIdK(String userid){
        SQLiteDatabase db = this.getWritableDatabase();
        ArrayList<HashMap<String, String>> userList = new ArrayList<>();
        String query = "select C_ID,C_userna,C_e_mail,C_passwd,C_mobnum FROM "+ userDataName;
        Cursor cursor = db.query(userDataName, new String[]{table_stucture.tblUserData.userID, table_stucture.tblUserData.userName,table_stucture.tblUserData.userEmail, table_stucture.tblUserData.userPassword,table_stucture.tblUserData.userMobile}, table_stucture.tblUserData.userMobile+ "=?",new String[]{String.valueOf(userid)},null, null, null, null);
        if (cursor.moveToNext()){
            HashMap<String,String> user = new HashMap<>();
            user.put("id",cursor.getString(cursor.getColumnIndex(table_stucture.tblUserData.userID)));
            user.put("name",cursor.getString(cursor.getColumnIndex(table_stucture.tblUserData.userName)));
            user.put("email",cursor.getString(cursor.getColumnIndex(table_stucture.tblUserData.userEmail)));
            user.put("passw",cursor.getString(cursor.getColumnIndex(table_stucture.tblUserData.userPassword)));
            user.put("mobile",cursor.getString(cursor.getColumnIndex(table_stucture.tblUserData.userMobile)));
            userList.add(user);
        }
        return  userList;
    }

    //Get relavant data from ID sucseed
    public Cursor getSelectedProfile(String strRegID, SQLiteDatabase db){

        String[] user_columns = {table_stucture.tblMyProfile.MyProfileRegID,
                table_stucture.tblMyProfile.MyProfileDispName,
                table_stucture.tblMyProfile.MyProfileDesig,
                table_stucture.tblMyProfile.MyProfileDept,
                table_stucture.tblMyProfile.MyProfileBranch,
                table_stucture.tblMyProfile.MyProfileDtOfB,
                table_stucture.tblMyProfile.MyProfileDtOfJoin,
                table_stucture.tblMyProfile.MyProfileEPFNo,
                table_stucture.tblMyProfile.MyProfileNIC,
                table_stucture.tblMyProfile.MyProfileType,
                table_stucture.tblMyProfile.MyProfileBank,
                table_stucture.tblMyProfile.MyProfileBBranch,
                table_stucture.tblMyProfile.MyProfileAcc,
                table_stucture.tblMyProfile.MyProfileBloodG};
        String selection = table_stucture.tblMyProfile.MyProfileRegID + " LIKE ?" ;
        String [] selection_args = {strRegID};
        Cursor prof_cursor_s;
        prof_cursor_s = db.query(MyProfileName,user_columns,selection,selection_args,null,null,null);
        return prof_cursor_s;
    }

    public List SqlLite_readMulitRowCombineWithTwoColoumns(String sqlLiteQry, String sqlLiteColoumn_1, String sqlLiteColoumn_2, String separatorMark) {
        List<String> listimg1;
        listimg1 = new ArrayList<String>();
        String StrColVal_1 = null;
        String StrColVal_2 = null;

        SQLiteDatabase db = this.getWritableDatabase();
        String query = sqlLiteQry;
        Cursor cursor = db.rawQuery( query, null );
        while (cursor.moveToNext()) {

            // String col11 =   cursor.getString( cursor.getColumnIndex( "Id" )  );
            StrColVal_1 = cursor.getString( cursor.getColumnIndex( sqlLiteColoumn_1 ) );
            StrColVal_2 = cursor.getString( cursor.getColumnIndex( sqlLiteColoumn_2 ) );

            // ImageUrl = ImageUrl.substring( 26 );
            listimg1.add( StrColVal_1 + " " + separatorMark + " " + StrColVal_2 );
        }
        return listimg1;
    }

    public List SqlLite_readMultyRowSingleColumnValue(String sqlLiteQry, String sqlLiteColoumn) {
        List<String> listimg1;
        listimg1 = new ArrayList<String>();
        String StrColVal = null;

        SQLiteDatabase db = this.getWritableDatabase();
        String query = sqlLiteQry;
        Cursor cursor = db.rawQuery( query, null );
        while (cursor.moveToNext()) {

            // String col11 =   cursor.getString( cursor.getColumnIndex( "Id" )  );
            StrColVal = cursor.getString( cursor.getColumnIndex( sqlLiteColoumn ) );

            // ImageUrl = ImageUrl.substring( 26 );
            listimg1.add( StrColVal );
        }
        return listimg1;
    }


    // Adding new User Details
    public boolean insertProfileDataM2(Integer ProfID, String RegID, String DispName, String EPFNo, String Dept, String Desig,
                                     String Type , String NIC, String Branch, String Gend , String DtOfB, String bank, String bBranch, String account , String blood, String DtOfJoin, int Synced ) {



        //Get the Data Repository in write mode
        SQLiteDatabase db = this.getWritableDatabase();

        //Create a new map of values, where column names are the keys
        ContentValues cValues = new ContentValues();
        cValues.put( "ProfID", ProfID );
        cValues.put( "RegID", RegID );
        cValues.put( "DispName", DispName );
        cValues.put( "EPFNo", EPFNo );
        cValues.put( "Dept", Dept );
        cValues.put( "Desig", Desig );
        cValues.put( "Type", Type );
        cValues.put( "NIC", NIC );
        cValues.put( "Branch", Branch );
        cValues.put( "Gend", Gend );
        cValues.put( "DtOfB", DtOfB );
        cValues.put( "bank", bank );
        cValues.put( "bBranch", bBranch );
        cValues.put( "account", account );
        cValues.put( "blood", blood );
        cValues.put( "DtOfJoin", DtOfJoin );
        cValues.put( "Synced", Synced );

        // Insert the new row, returning the primary key value of the new row
        db.execSQL("DELETE FROM " + MyProfileName);
        long newRowId = db.insert( MyProfileName, null, cValues );
        //Toast.makeText( getApplicationContext(), "Server Connection Lost with cloud database..! " , Toast.LENGTH_LONG ).show();
       if (newRowId==-1)
           return false;
       else
           return true;
    }

    // Update User Details
    public boolean UpdateUserDetails(String strMac, String strReg,String strUser,String strPass, int id) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cVals = new ContentValues();
        cVals.put( "C_mac", strMac );
        cVals.put( "C_regID", strReg );
        cVals.put( "C_userna", strUser );
        cVals.put( "C_passwd", strPass );
        int count = db.update( userDataName, cVals, table_stucture.tblUserData.userID + " = ?", new String[]{String.valueOf( id )} );
        if (count==-1)
            return false;
        else
            return true;
    }

    public boolean UpdateMac(String strRegID,String strMac,String strUser,String strPass,  SharedPreferences sp) {
        SQLiteDatabase dataBase = this.getReadableDatabase();
        boolean boolRet = false;
        SharedPreferences.Editor ed = sp.edit();
        ed.clear();
        ed.commit();
        try {
            String getSQL = "UPDATE " + userDataName + " SET C_mac='" + strMac + "',C_regID='" + strRegID + "' ";
            Cursor c = dataBase.rawQuery(getSQL, null);

            ed.commit();

            c.close();
            dataBase.close();

        } catch (Exception e) {
            boolRet = false;
            Logger log = Logger.getLogger("");
            log.log(Level.WARNING, "App Error", e);
        }
        return boolRet;
    }
}

/*//Delete all records of table
db.execSQL("DELETE FROM " + TABLE_NAME);

//Reset the auto_increment primary key if you needed
        db.execSQL("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME=" + TABLE_NAME);

//For go back free space by shrinking sqlite file
        db.execSQL("VACUUM");*/
    /*
    public Cursor getall_books(SQLiteDatabase db){
        Cursor books_cursor;
        String[] book_columns = {table_stucture.book_table.TBLBOOK_ID,
                table_stucture.book_table.TBLBOOKTITLE,
                table_stucture.book_table.TBLPUBLISHERNAME};
        books_cursor = db.query(table_stucture.book_table.TABLE_NAMEBOOK,book_columns,null,null,null,null,null);
        return books_cursor;
    }

    public Cursor getselected_books(String bkname, SQLiteDatabase db){

        String[] book_columns = {table_stucture.book_table.TBLBOOK_ID,
                table_stucture.book_table.TBLBOOKTITLE,
                table_stucture.book_table.TBLPUBLISHERNAME};
        String selection = table_stucture.book_table.TBLBOOKTITLE + " LIKE ?" ;
        String [] selection_args = {bkname};
        Cursor book_cursor_s;
        book_cursor_s = db.query(table_stucture.book_table.TABLE_NAMEBOOK,book_columns,selection,selection_args,null,null,null);
        return book_cursor_s;
    }

    public Cursor getall_branches(SQLiteDatabase db){
        Cursor branch_cursor;
        String[] branch_columns = {table_stucture.branch_table.TBLBRANCH_ID,
                table_stucture.branch_table.TBLBRANCH_NAME,
                table_stucture.branch_table.TBLBRANCH_ADDRESS};
        branch_cursor = db.query(table_stucture.branch_table.TABLE_NAME_BRANCH,branch_columns,null,null,null,null,null);
        return branch_cursor;
    }

    public Cursor getselected_branch(String brname, SQLiteDatabase db){

        String[] branch_columns = {table_stucture.branch_table.TBLBRANCH_ID,
                table_stucture.branch_table.TBLBRANCH_NAME,
                table_stucture.branch_table.TBLBRANCH_ADDRESS};
        String selection = table_stucture.branch_table.TBLBRANCH_NAME + " LIKE ?" ;
        String [] selection_args = {brname};
        Cursor branch_cursor_s;
        branch_cursor_s = db.query(table_stucture.branch_table.TABLE_NAME_BRANCH,branch_columns,selection,selection_args,null,null,null);
        return branch_cursor_s;
    }


    public Cursor get_selected_publisher (String publishername,SQLiteDatabase db){
        String[] selected_publisherdb = {table_stucture.publisher_table.TBLPUBLISHER_NAME,
                table_stucture.publisher_table.TBLPUBLISHERADDRESS,
                table_stucture.publisher_table.TBLPUBLISHERPHON};
        String selection = table_stucture.publisher_table.TBLPUBLISHER_NAME + " LIKE ?" ;
        String [] selection_args = {publishername};
        Cursor publishe_cursor_s;
        publishe_cursor_s = db.query(table_stucture.publisher_table.TABL_NAMEPUBLISHER,selected_publisherdb,selection,selection_args,null,null,null);
        return publishe_cursor_s;
    }

    public Cursor get_book_details (SQLiteDatabase db){
        Cursor details_cursor_s;
        details_cursor_s= db.query(" Book B inner join Book_Author BB on B.BOOK_ID = BB.BOOK_ID ",null,null,null,null,null,null);
        return details_cursor_s;
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

    }

    public boolean getUserValid(String prm_email, String prm_passwd, SharedPreferences sp) {
        SQLiteDatabase dataBase = this.getReadableDatabase();
        boolean boolRet = false;
        SharedPreferences.Editor ed = sp.edit();
        ed.clear();
        ed.commit();

        try {
            String getSQL = "SELECT * FROM " + TABLE_user + " WHERE e_mail='" + prm_email + "' and passwd='" + prm_passwd + "' ";
            Cursor c = dataBase.rawQuery(getSQL, null);
            Log.d("getRecord()", getSQL + "##Count = " + c.getCount());
            if (c.moveToFirst()) {
                boolRet = true;
                ed.putString("userna", c.getString(c.getColumnIndex(DatabaseHelper.C_userna)));
            }
            ed.commit();

            c.close();
            dataBase.close();

        } catch (Exception e) {
            boolRet = false;
            Logger log = Logger.getLogger("");
            log.log(Level.WARNING, "App Error", e);
        }
        return boolRet;
    }

    public JSONObject saveData(ContentValues contentValues) {
        JSONObject retobj = new JSONObject();

        try {
            db = this.getWritableDatabase();
            db.insert(TABLE_user, null, contentValues);
            db.close();

            retobj.put("result", "success");
            retobj.put("message", "Data saved successfully");

        } catch (Exception e) {
            Logger log = Logger.getLogger("");
            log.log(Level.WARNING, "App Error", e);

            try {
                retobj.put("result", "fail");
                retobj.put("message", "Data saved Error");
            } catch (JSONException e1) {
                e1.printStackTrace();
            }
        }
        return retobj;
    }

}*/
