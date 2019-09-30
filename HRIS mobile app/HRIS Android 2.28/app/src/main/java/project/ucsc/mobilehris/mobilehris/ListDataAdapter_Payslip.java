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
public class ListDataAdapter_Payslip extends ArrayAdapter {
    List plist = new ArrayList();
    public ListDataAdapter_Payslip(Context context, int resource) {
        super(context, resource);
    }

    static class LayoutHandler_payslip{
        TextView cMonth,SalaryComponant,Amount;
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
        LayoutHandler_payslip layoutHandler_payslip;
        if(prow== null){
            LayoutInflater layoutInflater_publisher = (LayoutInflater)this.getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            prow = layoutInflater_publisher.inflate(R.layout.activity_raw_layout_payslip,parent,false);
            layoutHandler_payslip = new LayoutHandler_payslip();
            layoutHandler_payslip.cMonth = (TextView)prow.findViewById(R.id.payslipMonth);
            layoutHandler_payslip.SalaryComponant = (TextView)prow.findViewById(R.id.payslipItem);
            layoutHandler_payslip.Amount = (TextView)prow.findViewById(R.id.payslipAmount);
            prow.setTag(layoutHandler_payslip);
        }
        else{
            layoutHandler_payslip= (LayoutHandler_payslip)prow.getTag();
        }
        DataProvider_Payslip dataProvider_payslip = (DataProvider_Payslip)this.getItem(position);
        layoutHandler_payslip.cMonth.setText(dataProvider_payslip.getName().toString());
        layoutHandler_payslip.SalaryComponant.setText(dataProvider_payslip.getAddress().toString());
        layoutHandler_payslip.Amount.setText(dataProvider_payslip.getPhone().toString());

        return prow;
    }
}
