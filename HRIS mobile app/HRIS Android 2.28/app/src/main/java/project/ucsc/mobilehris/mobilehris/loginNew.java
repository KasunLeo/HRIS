package project.ucsc.mobilehris.mobilehris;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.nio.channels.FileChannel;
import java.util.Map;

import android.content.Context;
import android.content.Intent;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

public class loginNew extends AppCompatActivity {

    //Start plash function
    RelativeLayout rellay1, rellay2;
    Handler handler = new Handler();
    Runnable runnable = new Runnable() {
        @Override
        public void run() {
            rellay1.setVisibility(View.VISIBLE);
            rellay2.setVisibility(View.VISIBLE);
        }
    };
    //End plash function

    EditText txtUser;
    EditText txtPassword;
    Button btnLogin;
    Button btnSignUp;
    TextView tvMac;

    //Database connection related
    SharedPreferences sp;
    DatabaseHelper helper_db;
    SQLiteDatabase sqLiteDatabase;
    private ImageView logo;
    private static final int REQUEST_SIGNUP = 0;
    Button btnForgot;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_new);

        rellay1 = (RelativeLayout) findViewById(R.id.rellay1);
        rellay2 = (RelativeLayout) findViewById(R.id.rellay2);
        logo = (ImageView) findViewById(R.id.imgView_logo);

        btnForgot = (Button) findViewById(R.id.btnForgot);
        btnLogin = (Button) findViewById(R.id.btnlogin);
        btnSignUp = (Button) findViewById(R.id.btnSignUp);
        txtUser=(EditText) findViewById(R.id.txtUser);
        txtPassword=(EditText) findViewById(R.id.txtPassword) ;
        tvMac=(TextView) findViewById(R.id.tv_Sign);

        //Animation duration
        handler.postDelayed(runnable, 6000); // 2000 is time out for splash

        //Get MAC and assign
        String stM = getMacAddr();

        //Assign MAC to global accesss
        Globals strMac = Globals.getInstance();
        strMac.setMac(stM);


        sp = getSharedPreferences("key", Context.MODE_PRIVATE);

        //Check for Mac validity
        helper_db = new DatabaseHelper(getApplicationContext());
        final boolean valMac = helper_db.getMacValid(stM, sp);

        sqLiteDatabase = helper_db.getReadableDatabase();


        String strEmID;
        String strLastSync;
        //if valid MAC then display toast
        if (valMac) {
            Cursor cursorid = helper_db.getSelectedUser(stM,sqLiteDatabase);
            if(cursorid.moveToFirst())
            {
                txtUser.setText(cursorid.getString(1));
                txtPassword.setText(cursorid.getString(2));
                strEmID=(cursorid.getString(3));
                strLastSync=(cursorid.getString(4));

                //Assign value to global ID
                Globals g = Globals.getInstance();
                g.setEmpId(strEmID);
                g.setLastSync(strLastSync);
                g.setUserN(txtUser.getText().toString());
                g.setPass(txtPassword.getText().toString());

                tvMac.setText("Mac : " + stM + " | Last Sync : " + strLastSync);

                Toast.makeText(getBaseContext(), "Your mac is identified from database as autheticated MAC", Toast.LENGTH_LONG).show();
            }
            else
                {
                    Toast.makeText(getBaseContext(), "Your mac is not identified from database as autheticated MAC", Toast.LENGTH_LONG).show();
                }

            //Creating an ArrayList Of Entry objects
            //ArrayList<HashMap<String, String>> companyDetails= helper_db.GetUserByUserIdK(stM);
        }

        Animation myamim = AnimationUtils.loadAnimation(this, R.anim.mysplashanimation);
        logo.startAnimation(myamim);



        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                login();
            }
        });


        btnSignUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Start the Signup activity
                Intent intent = new Intent(getApplicationContext(), registration_main.class);
                startActivityForResult(intent, REQUEST_SIGNUP);
                finish();
                overridePendingTransition(R.anim.push_left_in, R.anim.push_left_out);
            }
        });

        btnForgot.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(getBaseContext(), "Please contact system administrator using - 0773955776", Toast.LENGTH_LONG).show();
                /*Intent intent = new Intent(getApplicationContext(), registration_main.class);
                startActivityForResult(intent, REQUEST_SIGNUP);
                finish();
                overridePendingTransition(R.anim.push_left_in, R.anim.push_left_out);*/
            }
        });
    }

    public void login() {

        try {
            if (!validate()) {
                Toast.makeText(getBaseContext(), "Login failed", Toast.LENGTH_LONG).show();
                btnLogin.setEnabled(true);
                return;
            }
            btnLogin.setEnabled(false);
        } catch (Exception e) {

            e.printStackTrace();
        } finally {

        }


        // Authentication logic here.
        helper_db = new DatabaseHelper(getApplicationContext());
        final boolean valUser = helper_db.getUserValid(txtUser.getText().toString(), txtPassword.getText().toString(), sp);
        if (valUser) {

            //Assign value to global ID
            Globals g = Globals.getInstance();
            g.setUserN(txtUser.getText().toString());
            g.setPass(txtPassword.getText().toString());

            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
        }

        new android.os.Handler().postDelayed(
                new Runnable() {
                    public void run() {
                        // On complete call either onLoginSuccess or onLoginFailed
                        btnLogin.setEnabled(true);
                        if (!valUser) {
                            Toast.makeText(getApplicationContext(), "Invalid user name  or password", Toast.LENGTH_LONG).show();
                        }
                    }
                }, 2000);
    }


    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == REQUEST_SIGNUP) {
            if (resultCode == RESULT_OK) {
                // TODO: Implement successful signup logic here
                // By default we just finish the Activity and log them in automatically
                this.finish();
            }
        }
    }

    @Override
    public void onBackPressed() {
        // Disable going back to the DBHelper
        moveTaskToBack(true);
    }

    public boolean validate() {

        boolean valid = false;
        try {
            valid = true;

            String email = txtUser.getText().toString();
            String password = txtPassword.getText().toString();

            if (email.isEmpty() ) {
                txtUser.setError("Enter a valid user name");
                valid = false;
            } else {
                txtUser.setError(null);
            }

            if (password.isEmpty() || password.length() < 3 || password.length() > 10) {
                txtPassword.setError("Enter between 3 and 10 alphanumeric characters");
                valid = false;
            } else {
                txtPassword.setError(null);
            }



        } catch (Exception e) {
            e.printStackTrace();
        }
        return valid;
    }



    public static String getMacAddr() {
        try {
            List<NetworkInterface> all = Collections.list(NetworkInterface.getNetworkInterfaces());
            for (NetworkInterface nif : all) {
                if (!nif.getName().equalsIgnoreCase("wlan0")) continue;

                byte[] macBytes = nif.getHardwareAddress();
                if (macBytes == null) {
                    return "";
                }

                StringBuilder res1 = new StringBuilder();
                for (byte b : macBytes) {
                    res1.append(Integer.toHexString(b & 0xFF) + ":");
                }

                if (res1.length() > 0) {
                    res1.deleteCharAt(res1.length() - 1);
                }
                return res1.toString();
            }
        } catch (Exception ex) {
            //handle exception
        }
        return "";
    }
}
