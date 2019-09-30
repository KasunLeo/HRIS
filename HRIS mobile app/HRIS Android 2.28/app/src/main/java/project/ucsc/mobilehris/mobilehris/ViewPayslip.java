package project.ucsc.mobilehris.mobilehris;

import android.support.v7.app.AppCompatActivity;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.widget.ListView;

public class ViewPayslip extends AppCompatActivity {

    ListView listView;
    SQLiteDatabase sqLiteDatabase;
    DatabaseHelper databaseHelper;
    Cursor cursor;
    ListDataAdapter_Payslip listDataAdapterPayslip;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_payslip);

        listView =(ListView)findViewById(R.id.listView);
        listDataAdapterPayslip =new ListDataAdapter_Payslip(getApplicationContext(),R.layout.activity_raw_layout_payslip);
        listView.setAdapter(listDataAdapterPayslip);
        databaseHelper = new DatabaseHelper(getApplicationContext());
        sqLiteDatabase = databaseHelper.getReadableDatabase();
        cursor = databaseHelper.getAllPayrollData(sqLiteDatabase);
        if(cursor.moveToFirst()){
            do{
                String cMonth,salItem,amount;
                cMonth = cursor.getString(0);
                salItem = cursor.getString(1);
                amount = cursor.getString(2);
                DataProvider_Payslip dataProvider_payslip = new DataProvider_Payslip(cMonth,salItem,amount);
                listDataAdapterPayslip.add(dataProvider_payslip);

            }while(cursor.moveToNext());
        }
    }
}
