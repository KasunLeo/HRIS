package project.ucsc.mobilehris.mobilehris;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import antonkozyriatskyi.circularprogressindicator.CircularProgressIndicator;

public class Leave_data extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_leave_data);

        CircularProgressIndicator circularProgress1 = findViewById(R.id.circular_progress1);
        CircularProgressIndicator circularProgress2= findViewById(R.id.circular_progress3);
        CircularProgressIndicator circularProgress3 = findViewById(R.id.circular_progress4);
        CircularProgressIndicator circularProgress4 = findViewById(R.id.circular_progress5);

        // Progress bar1
        circularProgress1.setMaxProgress(14);
        circularProgress1.setCurrentProgress(6);

        // Progress bar2
        circularProgress2.setMaxProgress(21);
        circularProgress2.setCurrentProgress(7);

        // Progress bar3
        circularProgress3.setMaxProgress(7);
        circularProgress3.setCurrentProgress(2);

        // Progress bar4
        circularProgress4.setMaxProgress(5);
        circularProgress4.setCurrentProgress(4);

        final class DefaultProgressTextAdapter implements CircularProgressIndicator.ProgressTextAdapter {

            @Override

            public String formatText(double currentProgress) {

                return String.valueOf((int) currentProgress);

            }

        }
    }
}
