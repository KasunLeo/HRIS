package project.ucsc.mobilehris.mobilehris;

import android.annotation.SuppressLint;
import android.os.StrictMode;
import android.util.Log;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * Created by K on 1/6/2019.
 */

public class ConnectionClassMSSQL {
    /*Online Database*/
    String ip = "100.42.50.204";
    String db = "anuradh2_AttendanceSync";
    String un = "anuradh2_user";
    String password = "eyedia@1212";

    /*String ip = "127.0.0.1";
    String db = "SignHR";
    String un = "sa";
    String password = "eyedia@1212";*/


    @SuppressLint("NewApi")
    public Connection CONN() {
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder()
                .permitAll().build();
        StrictMode.setThreadPolicy( policy );
        Connection conn = null;
        String ConnURL = null;
        try {
            Class.forName( "net.sourceforge.jtds.jdbc.Driver" );
            ConnURL = "jdbc:jtds:sqlserver://" + ip + ";" + "databaseName=" + db + ";user=" + un + ";password=" + password + ";";
            conn = DriverManager.getConnection( ConnURL );
        } catch (SQLException se) {
            Log.e( "ERRO", se.getMessage() );
        } catch (ClassNotFoundException e) {
            Log.e( "ERRO", e.getMessage() );
        } catch (Exception e) {
            Log.e( "ERRO", e.getMessage() );
        }
        return conn;
    }
}
