package project.ucsc.mobilehris.mobilehris;


import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.github.mikephil.charting.charts.PieChart;
import com.github.mikephil.charting.data.PieData;
import com.github.mikephil.charting.data.PieDataSet;
import com.github.mikephil.charting.data.PieEntry;
import com.github.mikephil.charting.utils.ColorTemplate;

import java.util.ArrayList;
import java.util.List;

public class Leave_apply extends AppCompatActivity {

    float rainfall [] ={6f,9f,7f,6.5f,8f,9f};
    String monthNames []={"Jan","Feb","Mar","Aprl","May","June"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        setupPieChart();
    }

    private void setupPieChart() {

        //Populate pie entries from array
        List<PieEntry> pieEntries=new ArrayList<>();
        for (int i = 0 ;i< rainfall.length;i++){
            pieEntries.add(new PieEntry(rainfall[i],monthNames[i]));
        }


        PieDataSet dataSet= null;
        try {
            dataSet = new PieDataSet(pieEntries,"Leave taken in the year");

        dataSet.setColors(ColorTemplate.MATERIAL_COLORS);
        PieData data=new PieData(dataSet);


        //Get the chart
        PieChart chart=(PieChart) findViewById(R.id.pieChart);
        chart.setData(data);
        //chart.animateY(1000);
        chart.invalidate();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}