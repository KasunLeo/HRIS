package project.ucsc.mobilehris.mobilehris;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

/**
 * Created to view salary slip (thanks ravindu aiya)
 * want list data adapter
 * want data provider
 */
public class ListDataAdapter_TimeSheet extends ArrayAdapter {
    List plist = new ArrayList();
    public ListDataAdapter_TimeSheet(Context context, int resource) {
        super(context, resource);
    }

    static class LayoutHandler_TimeSheet{
        TextView atDate,inTime,outTime,shift,workHr;
    }

    @Override
    public void add(Object object) {
        super.add(object);
        plist.add(object);
    }

    @Override
    public int getCount() {
        return plist.size();
    }

    @Override
    public Object getItem(int position) {
        return plist.get(position);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        View prow = convertView;
        LayoutHandler_TimeSheet LayoutHandler_TimeSheet;
        if(prow== null){
            LayoutInflater layoutInflater_publisher = (LayoutInflater)this.getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            prow = layoutInflater_publisher.inflate(R.layout.activity_time_sheet_layout,parent,false);
            LayoutHandler_TimeSheet = new ListDataAdapter_TimeSheet.LayoutHandler_TimeSheet();
            LayoutHandler_TimeSheet.atDate = (TextView)prow.findViewById(R.id.tvTDate);
            LayoutHandler_TimeSheet.inTime = (TextView)prow.findViewById(R.id.tvTIntime);
            LayoutHandler_TimeSheet.outTime = (TextView)prow.findViewById(R.id.tvTOutTime);
            LayoutHandler_TimeSheet.shift = (TextView)prow.findViewById(R.id.tvTShift);
            LayoutHandler_TimeSheet.workHr = (TextView)prow.findViewById(R.id.tvTWorkH);
            prow.setTag(LayoutHandler_TimeSheet);
        }
        else{
            LayoutHandler_TimeSheet= (ListDataAdapter_TimeSheet.LayoutHandler_TimeSheet)prow.getTag();
        }
        DataProvider_Timeshhet dataProvider_Timeshhet = (DataProvider_Timeshhet)this.getItem(position);
        LayoutHandler_TimeSheet.atDate.setText(dataProvider_Timeshhet.getAtDate().toString());
        LayoutHandler_TimeSheet.inTime.setText(dataProvider_Timeshhet.getIndate().toString());
        LayoutHandler_TimeSheet.outTime.setText(dataProvider_Timeshhet.getOutDate().toString());
        LayoutHandler_TimeSheet.shift.setText(dataProvider_Timeshhet.getShift().toString());
        LayoutHandler_TimeSheet.workHr.setText(dataProvider_Timeshhet.getWorkHr().toString());
        return prow;
    }
}
