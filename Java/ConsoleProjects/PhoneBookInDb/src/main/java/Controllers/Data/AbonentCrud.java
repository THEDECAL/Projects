package Controllers.Data;
import Models.Abonent;
import lombok.Cleanup;
import lombok.NonNull;
import lombok.SneakyThrows;
import lombok.var;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Properties;

/** Класс CRUD-операций для абонентов */
public class AbonentCrud implements CRUD<Abonent> {
    /** Объект подключения к БД */
    private DbContext ctx;

    @SneakyThrows
    public AbonentCrud() {
        this.ctx = new DbContext();
    }

    @SneakyThrows
    private List<Abonent> getAbonentFromResult(ResultSet result) {
        var list = new ArrayList<Abonent>();

        while (result.next()) {
            list.add(new Abonent(result.getInt("Id"),
                    result.getString("FName"),
                    result.getString("SName"),
                    result.getString("PhoneNumber"),
                    result.getString("Country"),
                    result.getInt("Age")));
        }

        return list;
    }

    @SneakyThrows
    public Abonent get(@NonNull Integer id) {
        @Cleanup var conn = ctx.connect();
        var query = "select * from abonents where id = ?";
        var stmt = conn.prepareStatement(query);
        stmt.setInt(1, id);
        var result = stmt.executeQuery();

        return getAbonentFromResult(result).stream().findFirst().orElse(null);
    }

    @SneakyThrows
    public List<Abonent> getAll() {
        @Cleanup var conn = ctx.connect();
        var query = "select * from abonents";
        var stmt = conn.createStatement();
        var result = stmt.executeQuery(query);
        var listAbons = new ArrayList<Abonent>();

        return getAbonentFromResult(result);
    }

    @SneakyThrows
    public void save(@NonNull Abonent abon) {
        var findAbon = findByPhoneNumber(abon.getPhoneNumber());

        if(findAbon == null) {
            @Cleanup var conn = ctx.connect();
            var query = "insert Abonents (FName, SName, PhoneNumber, Country, Age) VALUES (?, ?, ?, ?, ?)";
            var stmt = conn.prepareStatement(query);

            stmt.setString(1, abon.getFname());
            stmt.setString(2, abon.getSname());
            stmt.setString(3, abon.getPhoneNumber());
            stmt.setString(4, abon.getCountry());
            stmt.setInt(5, abon.getAge());

            stmt.executeUpdate();
        }
        else throw new IllegalArgumentException("Абонент с номером " + abon.getPhoneNumber() + " уже есть.");
    }

    @SneakyThrows
    public Abonent findByPhoneNumber(@NonNull String phoneNumber) {
        @Cleanup var conn = ctx.connect();
        var query = "select * from abonents where PhoneNumber like ?";
        var stmt = conn.prepareStatement(query);
        stmt.setString(1, '%' + phoneNumber + '%');
        var result = stmt.executeQuery();

        return getAbonentFromResult(result).stream().findFirst().orElse(null);
    }

    @SneakyThrows
    public List<Abonent> findByName(@NonNull String fname, @NonNull String sname) {
        @Cleanup var conn = ctx.connect();
        var query = "select * from abonents where FName like ? and SName like ?";
        var stmt = conn.prepareStatement(query);
        stmt.setString(1, '%' + fname + '%');
        stmt.setString(2, '%' + sname + '%');
        var result = stmt.executeQuery();

        return getAbonentFromResult(result);
    }

    @SneakyThrows
    public void update(@NonNull Abonent abon) {
        @Cleanup var conn = ctx.connect();
        var query = "UPDATE `Abonents` SET " +
                "`FName` = ?," +
                "`SName` = ?," +
                "`PhoneNumber` = ?," +
                "`Country` = ?," +
                "`Age` = ?" +
                " WHERE `Id` = ?";
        var stmt = conn.prepareStatement(query);

        stmt.setString(1, abon.getFname());
        stmt.setString(2, abon.getSname());
        stmt.setString(3, abon.getPhoneNumber());
        stmt.setString(4, abon.getCountry());
        stmt.setInt(5, abon.getAge());
        stmt.setInt(6, abon.getId());

        stmt.executeUpdate();
    }

    @SneakyThrows
    public void delete(@NonNull Integer id) {
        @Cleanup var conn = ctx.connect();
        var query = "DELETE FROM Abonents WHERE id = ?";
        var stmt = conn.prepareStatement(query);

        stmt.setInt(1, id);
        stmt.executeUpdate();
    }
}
