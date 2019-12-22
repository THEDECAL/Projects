package Controllers.Data;
import lombok.Cleanup;
import lombok.SneakyThrows;
import lombok.var;
import java.net.Inet4Address;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.Properties;

/** Класс подключения к БД */
public class DbContext {
    private String dbType;
    private String dbName;
    private String dbUser;
    private String dbPassword;
    private Inet4Address dbHost;
    private Integer dbPort;

    @SneakyThrows
    public DbContext() {
        var props = LoadConfigFile();

        this.dbType = props.getProperty("dbType");
        this.dbName = props.getProperty("dbName");
        this.dbUser = props.getProperty("dbUser");
        this.dbPassword = props.getProperty("dbPassword");
        this.dbHost = (Inet4Address) Inet4Address.getByName(props.getProperty("dbHost"));

        var port = Integer.parseInt(props.getProperty("dbPort"));
        if (port > 0 && port < 65536) this.dbPort = port;
        else throw new IllegalArgumentException("Введён недопустимый порт.");
    }

    @SneakyThrows
    public Connection connect() {
        //"jdbc:[dbType]://[host]:[port]/[db_name]?characterEncoding=UTF-8";
        var url = "jdbc:" + dbType + "://"
                + dbHost.getHostAddress().toString()
                + ":" + dbPort.toString() + "/"
                + dbName;
                //+ "?characterEncoding=UTF-8";
        return DriverManager.getConnection(url, dbUser, dbPassword);
    }

    @SneakyThrows
    private Properties LoadConfigFile() {
        var props = new Properties();
        var pathToConfig = Paths.get("dbConfig.cfg");
        @Cleanup var in = Files.newInputStream(pathToConfig);
        props.load(in);

        return props;
    }
}
