package project.ucsc.mobilehris.mobilehris;

public class DataProvider_Timeshhet {
    private String atDate;
    private String strIndate;
    private String strOutDate;
    private String strShift;
    private String strWorkHr;

    public String getAtDate() {
        return atDate;
    }

    public void setAtDate(String atDate) {
        this.atDate = atDate;
    }

    public String getIndate() {
        return strIndate;
    }

    public void setIndate(String strIndate) {
        this.strIndate = strIndate;
    }

    public String getOutDate() {
        return strOutDate;
    }

    public void setOutDate(String strOutDate) {
        this.strOutDate = strOutDate;
    }

    public String getShift() {
        return strShift;
    }

    public void setShift(String strOutDate) {
        this.strShift = strShift;
    }

    public String getWorkHr() {
        return strWorkHr;
    }

    public void setWorkHr(String strOutDate) {
        this.strWorkHr = strWorkHr;
    }

    public DataProvider_Timeshhet(String atDate, String strIndate, String strOutDate,String strShift,String strWorkHr){
        this.atDate = atDate;
        this.strIndate = strIndate;
        this.strOutDate = strOutDate;
        this.strShift=strShift;
        this.strWorkHr=strWorkHr;

    }
}
