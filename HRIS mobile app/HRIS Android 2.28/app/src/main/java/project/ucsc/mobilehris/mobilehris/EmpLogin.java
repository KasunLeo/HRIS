package project.ucsc.mobilehris.mobilehris;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.nio.channels.FileChannel;

import butterknife.BindView;
import butterknife.ButterKnife;

public class EmpLogin extends AppCompatActivity {


    private static final String TAG = "HRISMain";
    private static final int REQUEST_SIGNUP = 0;

    @BindView(R.id.input_email)
    EditText _emailText;
    @BindView(R.id.input_password)
    EditText _passwordText;
    @BindView(R.id.btn_login)
    Button _loginButton;
    @BindView(R.id.link_signup)
    TextView _signupLink;

    DatabaseHelper helper_db;
    SharedPreferences sp;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_emp_login);
        ButterKnife.bind(this);

    sp = getSharedPreferences("key", Context.MODE_PRIVATE);

        _loginButton.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            login();
        }
    });

        _signupLink.setOnClickListener(new View.OnClickListener()
    {
        @Override
        public void onClick(View v) {
        // Start the Signup activity
        Intent intent = new Intent(getApplicationContext(), registration_main.class);
        startActivityForResult(intent, REQUEST_SIGNUP);
        finish();
        overridePendingTransition(R.anim.push_left_in, R.anim.push_left_out);
    }
    });
}

    public void login() {
        if (!validate()) {
            Toast.makeText(getBaseContext(), "Login failed", Toast.LENGTH_LONG).show();
            _loginButton.setEnabled(true);
            return;
        }
        _loginButton.setEnabled(false);

        // TODO: Implement your own authentication logic here.
        helper_db = new DatabaseHelper(getApplicationContext());
        final boolean valUser = helper_db.getUserValid(_emailText.getText().toString(), _passwordText.getText().toString(), sp);
        if (valUser) {
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
        }

        new android.os.Handler().postDelayed(
                new Runnable() {
                    public void run() {
                        // On complete call either onLoginSuccess or onLoginFailed
                        _loginButton.setEnabled(true);
                        if (!valUser) {
                            Toast.makeText(getApplicationContext(), "Invalid User Email or Password", Toast.LENGTH_LONG).show();
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
        boolean valid = true;

        String email = _emailText.getText().toString();
        String password = _passwordText.getText().toString();

        if (email.isEmpty() || !android.util.Patterns.EMAIL_ADDRESS.matcher(email).matches()) {
            _emailText.setError("Enter a valid email address");
            valid = false;
        } else {
            _emailText.setError(null);
        }

        if (password.isEmpty() || password.length() < 4 || password.length() > 10) {
            _passwordText.setError("Enter between 4 and 10 alphanumeric characters");
            valid = false;
        } else {
            _passwordText.setError(null);
        }

        return valid;
    }

}
