package project.ucsc.mobilehris.mobilehris;

public class Globals{
    private static Globals instance;

    // Global variable
    private String strEmpID;
    private String strMac;
    private  String strLastSyn;
    private String strUserN;
    private String strPass;

    // Restrict the constructor from being instantiated
    private Globals(){}

    public void setEmpId(String d){
        this.strEmpID=d;
    }

    public String getEmpID(){
        return this.strEmpID;
    }

    public  void setMac(String m){
        this.strMac=m;
    }

    public  String getStrMac(){
    return this.strMac;
    }

    public  void setLastSync(String n){
        this.strLastSyn=n;
    }

    public  String getStrLastSyn(){
        return this.strLastSyn;
    }

    public  void setUserN(String u){
        this.strUserN=u;
    }

    public  String getUserN(){
        return this.strUserN;
    }

    public  void setPass(String p){
        this.strPass=p;
    }

    public  String getPass(){
        return this.strPass;
    }

    public static synchronized Globals getInstance(){
        if(instance==null){
            instance=new Globals();
        }
        return instance;
    }
}
