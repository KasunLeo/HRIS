package project.ucsc.mobilehris.mobilehris;

import android.content.Context;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class registration_main extends AppCompatActivity {

    private EditText rname, raddress, rphone, rpassword;
    private Button register_button;
    private Context context =this;
    DatabaseHelper databaseHelper;
    SQLiteDatabase sqLiteDatabase;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration_main);
        rname = (EditText)findViewById(R.id.txtRname);
        raddress = (EditText)findViewById(R.id.txtRAddress);
        rphone = (EditText)findViewById(R.id.txtRMobile);
        rpassword = (EditText)findViewById(R.id.txtRPassword);
        register_button = (Button)findViewById(R.id.btnRegister);

        register_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String sname = rname.getText().toString().trim();
                String saddress = raddress.getText().toString().trim();
                String sphone = rphone.getText().toString().trim();
                String spassword = rpassword.getText().toString().trim();
                String mst= String.valueOf(1);
                String due= String.valueOf(1);
                databaseHelper = new DatabaseHelper(context);
                sqLiteDatabase = databaseHelper.getWritableDatabase();
                //databaseHelper.insert_tblUserData(strN, saddress, sphone, spassword, due, mst, sqLiteDatabase);
                Toast.makeText(registration_main.this,"Successfully Registered",Toast.LENGTH_LONG).show();
                databaseHelper.close();
                Intent tomain = new Intent(registration_main.this,MainActivity.class);
                startActivity(tomain);
            }
        });
    }


    /*@Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }*/

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
       /* if (id == R.id.action_settings) {
            return true;
        }*/

        return super.onOptionsItemSelected(item);
    }
}