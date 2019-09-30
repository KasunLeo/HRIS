package project.ucsc.mobilehris.mobilehris;

import android.content.DialogInterface;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.content.Context;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;

public class MainActivity extends AppCompatActivity {

    DatabaseHelper databaseHelper;
    SQLiteDatabase sqLiteDatabase;
    private Context context = this;
    private String strRegID;
    TextView tvLastSyncDt;
    TextView tvLastDtGap;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        databaseHelper = new DatabaseHelper(context);
        sqLiteDatabase = databaseHelper.getWritableDatabase();
        databaseHelper.close();

        final ImageButton btncPayslip = (ImageButton) findViewById(R.id.btnPaySlip);
        final ImageButton btncProfile = (ImageButton) findViewById(R.id.btnProfile);
        final ImageButton btncLeave = (ImageButton) findViewById(R.id.btnLeave);
        final ImageButton btncDashboard = (ImageButton) findViewById(R.id.btnDashboard);
        final ImageButton btncLeaveRequest = (ImageButton) findViewById(R.id.btnLeaveReq);
        final ImageButton btncTimesheet = (ImageButton) findViewById(R.id.btnTimeCard);

        final ImageButton btnSetting = (ImageButton) findViewById(R.id.btnSetting);
        tvLastSyncDt = (TextView) findViewById(R.id.tvLastSync);
        tvLastDtGap = (TextView) findViewById(R.id.tvDaysFrLast);

        //Set values in form load
        Globals g = Globals.getInstance();
        strRegID = g.getEmpID();


        String strThatDay = g.getStrLastSyn();
            /*SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy");
            Date date = sdf.parse(strThatDay);
            Calendar cal = Calendar.getInstance();
            cal.setTime(date);
            Calendar today = Calendar.getInstance();

            long diff = today.getTimeInMillis() - cal.getTimeInMillis(); //result in millis
            
            float daysBetween = (diff / (1000 * 60 * 60 * 24));*/


        tvLastSyncDt.setText("On : " + strThatDay);
        tvLastDtGap.setText("01-Days");


        btncPayslip.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == (MotionEvent.ACTION_UP)) {
                    btncPayslip.setImageResource(R.drawable.btnpayslip2);
                    btncPayslip.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent regiser = new Intent(MainActivity.this, ViewPayslip.class);
                            startActivity(regiser);
                        }
                    });
                } else {
                    btncPayslip.setImageResource(R.drawable.btnpayslip2);
                }
                return false;
            }
        });

        btncProfile.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == (MotionEvent.ACTION_UP)) {
                    btncProfile.setImageResource(R.drawable.btnprofile2);
                    btncProfile.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent regiser = new Intent(MainActivity.this, ProfileUI.class);
                            startActivity(regiser);
                        }
                    });
                } else {
                    btncProfile.setImageResource(R.drawable.btnprofile2);
                }
                return false;
            }
        });

        btncLeave.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == (MotionEvent.ACTION_UP)) {
                    btncLeave.setImageResource(R.drawable.btnleave);
                    btncLeave.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent regiser = new Intent(MainActivity.this, Leave_data.class);
                            startActivity(regiser);
                        }
                    });
                } else {
                    btncLeave.setImageResource(R.drawable.btnleave2);
                }
                return false;
            }
        });

        btncDashboard.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == (MotionEvent.ACTION_UP)) {
                    btncDashboard.setImageResource(R.drawable.btndashboard2);
                    btncDashboard.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent regiser = new Intent(MainActivity.this, loginMSSQL.class);
                            startActivity(regiser);
                        }
                    });
                } else {
                    btncDashboard.setImageResource(R.drawable.btndashboard2);
                }
                return false;
            }
        });

        btncLeaveRequest.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == (MotionEvent.ACTION_UP)) {
                    btncLeaveRequest.setImageResource(R.drawable.btnleave2);
                    btncLeaveRequest.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent regiser = new Intent(MainActivity.this, Leave_apply.class);
                            startActivity(regiser);
                        }
                    });
                } else {
                    btncLeaveRequest.setImageResource(R.drawable.btnleave2);
                }
                return false;
            }
        });

        btncTimesheet.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == (MotionEvent.ACTION_UP)) {
                    btncTimesheet.setImageResource(R.drawable.btnpayslip2);
                    btncTimesheet.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent regiser = new Intent(MainActivity.this, Viewtime_sheet.class);
                            startActivity(regiser);
                        }
                    });
                } else {
                    btncTimesheet.setImageResource(R.drawable.btnpayslip2);
                }
                return false;
            }
        });

        btnSetting.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == (MotionEvent.ACTION_UP)) {

                    checkConnection();
                    isOnline();
                    confirmDialog();

                } else {
                    //btnSetting.setImageResource(R.drawable.btnb);
                }
                return false;
            }
        });

    }

    protected boolean isOnline() {
        ConnectivityManager cm = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo netInfo = cm.getActiveNetworkInfo();

        if (netInfo != null && netInfo.isConnectedOrConnecting()) {
            return true;
        } else {
            return false;
        }
    }


    public void checkConnection() {
        if (isOnline()) {
            Toast.makeText(MainActivity.this, "You are connected to Internet", Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(MainActivity.this, "You are not connected to Internet", Toast.LENGTH_SHORT).show();
        }
    }


    public void confirmDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);

        builder
                .setMessage("Are you sure that you want to update yor application data upto today?")
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int id) {
                        // Yes-code
                        From_MsSQL_To_SqlLite_tblProfile("tblMyProfile", "ProfID", "RegID", "DispName",
                                "EPFNo", "Dept", "Desig",
                                "Type", "NIC", "Branch", "Gend", "DtOfB",
                                "bank", "bBranch", "account", "blood", "DtOfJoin", "Synced");

                    }
                })
                .setNegativeButton("No", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                    }
                })
                .show();
    }

    public String From_MsSQL_To_SqlLite_tblProfile(String tableName, String Column1, String Column2, String Column3, String Column4, String Column5,
                                                   String Column6, String Column7, String Column8, String Column9, String Column10, String Column11,
                                                   String Column12, String Column13, String Column14, String Column15, String Column16, String Column17) {
        ConnectionClassMSSQL connectionClass;
        //Get Cloud Database Image pass (sqlqry,imagePathColumn,SaveToMemoryLocation)
        connectionClass = new ConnectionClassMSSQL();
        Connection con = connectionClass.CONN();

        DatabaseHelper dbHandler = new DatabaseHelper(MainActivity.this);

        ResultSet rs;
        try {
            if (con == null) {
                Toast.makeText(getApplicationContext(), "Server Connection Lost with cloud database..! ", Toast.LENGTH_LONG).show();
            } else {
                //  String query = "SELECT * FROM tblSetItem ";
                String query = "SELECT ProfID,RegID,DispName,EPFNo,Dept,Desig,Type,NIC,Branch,Gend,DtOfB,bank,bBranch,account,blood,DtOfJoin,Synced  FROM tblMyProfile WHERE regID='" + strRegID + "'";
                //String query ="SELECT * FROM tblMyProfile";
                Statement stmt = con.createStatement();
                rs = stmt.executeQuery(query);
                while (rs.next()) {

                    //Write Start..
                    Integer Col1 = (rs.getInt(Column1));
                    String Col2 = (rs.getString(Column2));
                    String Col3 = (rs.getString(Column3));
                    String Col4 = (rs.getString(Column4));
                    String Col5 = (rs.getString(Column5));
                    String Col6 = (rs.getString(Column6));
                    String Col7 = (rs.getString(Column7));
                    String Col8 = (rs.getString(Column8));
                    String Col9 = (rs.getString(Column9));
                    String Col10 = (rs.getString(Column10));
                    String Col11 = (rs.getString(Column11));
                    String Col12 = (rs.getString(Column12));
                    String Col13 = (rs.getString(Column13));
                    String Col14 = (rs.getString(Column14));
                    String Col15 = (rs.getString(Column15));
                    String Col16 = (rs.getString(Column16));
                    int Col17 = (rs.getInt(Column17));

                    //Insert data to SQL Lite DB
                    boolean isInserted = dbHandler.insertProfileDataM2(Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9, Col10, Col11, Col12, Col13, Col14, Col15, Col16, Col17);

                    if (isInserted == true) {
                        //Update status of MSSQL DB ONLY RELEVANT ROWS
                        /*try {
                            query = "UPDATE tblMyProfile SET Synced=1 WHERE RegID='" + strRegID + "'";
                            stmt = con.createStatement();
                            stmt.executeUpdate(query);
                        } catch (SQLException se) {
                            Log.e("ERROR", se.getMessage());
                        }*/

                        Toast.makeText(MainActivity.this, "Data inserted succesfully", Toast.LENGTH_LONG).show();
                    } else
                        Toast.makeText(MainActivity.this, "Data not inserted", Toast.LENGTH_LONG).show();
                }
            }
            //Toast.makeText( getApplicationContext(), "!gfg "+grobleVariableUse.LoginAccountType  , Toast.LENGTH_LONG ).show();
        } catch (Exception ex) {
            Log.e("Error reading file", ex.toString());
        }

        return null;
    }

    /*public String From_MsSQL_To_SqlLite_5itemImage(String tableName, String Column1, String Column2, String Column3, String Column4, String Column5)
    {
        ConnectionClassMSSQL connectionClass;
        //Get Cloud Database Image pass (sqlqry,imagePathColumn,SaveToMemoryLocation)
        connectionClass = new ConnectionClassMSSQL();
        Connection con = connectionClass.CONN();

        DatabaseHelper dbHandler = new DatabaseHelper( MainActivity.this );

        ResultSet rs;
        try {
            if (con == null) {
                //    Toast.makeText( getApplicationContext(), "Server Connection Lost..! " , Toast.LENGTH_LONG ).show();
            } else {
                //  String query = "SELECT * FROM tblSetItem ";
                String query = "SELECT * FROM tblSetItemImage WHERE imgPath IS NOT NULL OR imgPath <> ''";
                Statement stmt = con.createStatement();
                rs = stmt.executeQuery( query );
                while (rs.next()) {

                    //Write Start..
                    Integer Col1 = (rs.getInt( Column1 ));
                    String Col2 = (rs.getString( Column2 ));
                    Integer Col3 = (rs.getInt( Column3 ));
                    String Col4 = (rs.getString( Column4 ));



                    dbHandler.insertUserDetailsItemImage( Col1, Col2, Col3, Col4 );
                }
            }
            // Toast.makeText( getApplicationContext(), "!gfg "+grobleVariableUse.LoginAccountType  , Toast.LENGTH_LONG ).show();
        } catch (Exception ex) {
            Log.e( "Error reading file", ex.toString() );
        }
        return null;
    }*/
}
