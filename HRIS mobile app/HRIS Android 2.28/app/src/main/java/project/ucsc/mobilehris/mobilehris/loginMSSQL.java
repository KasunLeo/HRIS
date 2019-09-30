package project.ucsc.mobilehris.mobilehris;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;

public class loginMSSQL extends AppCompatActivity {

    ConnectionClassMSSQL connectionClass;
    EditText edtuserid, edtpass;
    Button btnlogin;
    ProgressBar pbbar;
    SharedPreferences shp;
    TextView tvMac;
    ImageButton btnSetMac;
    EditText edtMac;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate( savedInstanceState );
        setContentView( R.layout.activity_login_mssql );


        connectionClass = new ConnectionClassMSSQL();
        edtuserid = (EditText) findViewById(R.id.edtuserid);
        edtpass = (EditText) findViewById(R.id.edtpass);
        btnlogin = (Button) findViewById(R.id.btnlogin);
        pbbar = (ProgressBar) findViewById(R.id.pbbar);
        pbbar.setVisibility( View.GONE);
        tvMac=(TextView) findViewById(R.id.tv_Mac);

        btnSetMac =(ImageButton) findViewById(R.id.btnSetM);
        edtMac=(EditText) findViewById(R.id.edMac) ;

        shp = this.getSharedPreferences("UserInfo", MODE_PRIVATE);

        String userid = shp.getString("UserId", "none");

        Globals g = Globals.getInstance();
        tvMac.setText(g.getStrMac());
        edtuserid.setText(g.getUserN());
        edtpass.setText(g.getPass());


        if (userid.equals("none") || userid.trim().equals("")) {

        } else {

            //Intent i = new Intent(this, MainActivity.class);
            //startActivity(i);
            //finish();

        }

        btnlogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                DoLogin doLogin = new DoLogin();
                doLogin.execute("");
            }
        });

        btnSetMac.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                UpdateUserByAdmin();
            }
        });
    }



    public class DoLogin extends AsyncTask<String, String, String>
    {
        String z = "";
        Boolean isSuccess = false;
        String userid = edtuserid.getText().toString();
        String password = edtpass.getText().toString();
        String strMacID=tvMac.getText().toString();

        @Override
        protected void onPreExecute() {
            pbbar.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(String r) {
            pbbar.setVisibility(View.GONE);
            Toast.makeText(loginMSSQL.this, r, Toast.LENGTH_SHORT).show();
            if (isSuccess) {

                SharedPreferences.Editor edit = shp.edit();
                edit.putString("UserId", userid);
                edit.commit();

                Intent i = new Intent(loginMSSQL.this, MainActivity.class);
                startActivity(i);
                finish();
            }
        }

        @Override
        protected String doInBackground(String... params)
        {

            if (userid.trim().equals( "" ) || password.trim().equals( "" ))
                z = "Please enter User Id and Password";
            else {
                try {
                    Connection con = connectionClass.CONN();
                    if (con == null) {
                        z = "Error in connection with Server";
                    } else {
                        String query = "select * from tblUserData where C_userna='"+ userid + "' and C_passwd='" + password + "' and C_mac='" + strMacID + "' and C_status = 0";
                        Statement stmt = con.createStatement();
                        ResultSet rs = stmt.executeQuery( query );
                        if (rs.next()) {
                            z = "Login successfull";
                            isSuccess = true;
                        } else {
                            z = "Invalid Credentials";
                            isSuccess = false;
                        }

                    }
                } catch (Exception ex) {
                    isSuccess = false;
                    z = "Exceptions";
                }
            }
            return z;
        }
    }

    public void UpdateUserByAdmin() {
        DatabaseHelper helper_db = new DatabaseHelper(loginMSSQL.this);

        Globals g = Globals.getInstance();
        String strEmp=edtMac.getText().toString();
        String strMac=g.getStrMac();
        String strUser=g.getUserN();
        String strPass=g.getPass();
        boolean isUpdated=helper_db.UpdateUserDetails(strMac,strEmp,strUser,strPass,1);
        //final boolean isUpdated = helper_db.UpdateMac(strEmp, strMac,strUser, strPass,shp);
        if (isUpdated == true) {
            Toast.makeText(loginMSSQL.this, "Data updated succesfully", Toast.LENGTH_LONG).show();
        } else
            Toast.makeText(loginMSSQL.this, "Data not updated", Toast.LENGTH_LONG).show();
    }

}
