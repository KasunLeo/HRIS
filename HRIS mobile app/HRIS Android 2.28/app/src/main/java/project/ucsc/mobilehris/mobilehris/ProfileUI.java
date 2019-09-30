package project.ucsc.mobilehris.mobilehris;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import android.webkit.WebView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;
import android.widget.TextView;

import org.w3c.dom.Text;


public class ProfileUI extends AppCompatActivity {

    TextView tvName,tvDesig,tvAddress,tvBranch,tvDepartment,tvEmail,tvDOB,tvAge,tvEpf,tvDOJ,tvServAge,tvNIC,tvType,tvBank,tvBBranch,tvAcc,tvBlood;

    //Database connection related
    SharedPreferences sp;
    DatabaseHelper helper_db;
    SQLiteDatabase sqLiteDatabase;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile_ui);

        tvAddress=(TextView) findViewById(R.id.tv_address);
        tvAge=(TextView) findViewById(R.id.tv_age);
        tvBranch=(TextView) findViewById(R.id.tv_branch);
        tvDepartment=(TextView) findViewById(R.id.tv_department);
        tvDesig=(TextView) findViewById(R.id.tv_desig);
        tvDOB=(TextView) findViewById(R.id.tv_DOB);
        tvEmail=(TextView) findViewById(R.id.tv_email);
        tvEpf=(TextView) findViewById(R.id.tv_Epf);
        tvName=(TextView) findViewById(R.id.tv_name);
        tvServAge=(TextView) findViewById(R.id.tv_SerAage);
        tvDOJ = (TextView) findViewById(R.id.tv_DOJ);
        tvNIC=(TextView) findViewById(R.id.tv_NIC);
        tvType=(TextView) findViewById(R.id.tv_type);
        tvBank=(TextView) findViewById(R.id.tv_bank);
        tvBranch=(TextView) findViewById(R.id.tv_bBranch);
        tvAcc=(TextView) findViewById(R.id.tv_account);
        tvBlood=(TextView) findViewById(R.id.tv_blood);

        tvAge=(TextView) findViewById(R.id.tv_age);
        tvServAge=(TextView) findViewById(R.id.tv_SerAage);

        sp = getSharedPreferences("key", Context.MODE_PRIVATE);

        Globals g = Globals.getInstance();
        //strEmp.setData("000001");

        String strEmp=g.getEmpID();
        //Check for Data in Database
        helper_db = new DatabaseHelper(getApplicationContext());


        sqLiteDatabase = helper_db.getReadableDatabase();

        Cursor cursorProfile = helper_db.getSelectedProfile(strEmp,sqLiteDatabase);

        try {
            if(cursorProfile.moveToFirst())
            {
                //datak=cursorProfile.getString(0);
                tvName.setText(cursorProfile.getString(1));
                tvDesig.setText(cursorProfile.getString(2));
                tvDepartment.setText("Employee Department : " +cursorProfile.getString(3));
                tvBranch.setText("Employee Branch : " +cursorProfile.getString(4));
                tvDOB.setText("Date of Bitrh : " + cursorProfile.getString(5));
                tvDOJ.setText("Date of Join : " + cursorProfile.getString(6));
                tvEpf.setText(cursorProfile.getString(7));
                tvNIC.setText(cursorProfile.getString(8));
                tvType.setText("Employee Type : " +cursorProfile.getString(9));
                tvBank.setText("Bank Name : " +cursorProfile.getString(10));
                tvBBranch.setText("Bank's Branch : " +cursorProfile.getString(11));
                tvAcc.setText("Aaccount No : " +cursorProfile.getString(12));
                tvBlood.setText("Blood Group : " +cursorProfile.getString(13));
                //tvEmail.setText("Blood Group : " +cursorProfile.getString(13));

                Toast.makeText(getBaseContext(), "Your profile is identified from database", Toast.LENGTH_LONG).show();
            }
            else
            {
                Toast.makeText(getBaseContext(), "Your mac is not identified from database as autheticated MAC", Toast.LENGTH_LONG).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}
