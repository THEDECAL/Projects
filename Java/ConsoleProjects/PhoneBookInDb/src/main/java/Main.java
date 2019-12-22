import Controllers.PhoneBook;
import com.mysql.fabric.jdbc.FabricMySQLDriver;
import java.sql.DriverManager;

public class Main {
    private final String userToDb = "phone_book_user";
    private final String passwordToDb = "5WXyiYme4iVH7vKB";
    private final String ipAddressToDb = "127.0.0.1";
    private final Integer porTotDb = 3306;

    public static void main(String[] args) {
        try {
            DriverManager.registerDriver(new FabricMySQLDriver());

            PhoneBook.getInstance().run();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
