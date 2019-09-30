package project.ucsc.mobilehris.mobilehris;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import de.hdodenhof.circleimageview.CircleImageView;

public class EmpProfile extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_emp_profile);
        CircleImageView CIV=(CircleImageView) findViewById(R.id.profile_image);
    }
}
