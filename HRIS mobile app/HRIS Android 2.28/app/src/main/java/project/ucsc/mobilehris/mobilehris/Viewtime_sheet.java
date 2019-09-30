package project.ucsc.mobilehris.mobilehris;

import android.support.v7.app.AppCompatActivity;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.widget.ListView;

public class Viewtime_sheet extends AppCompatActivity {

    ListView listView;
    SQLiteDatabase sqLiteDatabase;
    DatabaseHelper databaseHelper;
    Cursor cursor;
    ListDataAdapter_TimeSheet listDataAdapterTimeSheet;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_time_sheet);

        listView =(ListView)findViewById(R.id.listView);
        listDataAdapterTimeSheet =new ListDataAdapter_TimeSheet(getApplicationContext(),R.layout.activity_time_sheet_layout);
        listView.setAdapter(listDataAdapterTimeSheet);
        databaseHelper = new DatabaseHelper(getApplicationContext());
        sqLiteDatabase = databaseHelper.getReadableDatabase();
        cursor = databaseHelper.getAllTimeSheetData(sqLiteDatabase);
    }
}
