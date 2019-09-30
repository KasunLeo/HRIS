package project.ucsc.mobilehris.mobilehris;

/**
 * Created by Kasun (thanks ravidu aiya).
 */
public class DataProvider_Payslip {
    private String cMonth;
    private String strSalItem;
    private String dblAmount;

    public String getName() {
        return cMonth;
    }

    public void setName(String cMonth) {
        this.cMonth = cMonth;
    }

    public String getAddress() {
        return strSalItem;
    }

    public void setAddress(String strSalItem) {
        this.strSalItem = strSalItem;
    }

    public String getPhone() {
        return dblAmount;
    }

    public void setPhone(String dblAmount) {
        this.dblAmount = dblAmount;
    }

    public DataProvider_Payslip(String pMonth, String pSalItem, String pAmount){
        this.cMonth = pMonth;
        this.strSalItem = pSalItem;
        this.dblAmount = pAmount;

    }
}
