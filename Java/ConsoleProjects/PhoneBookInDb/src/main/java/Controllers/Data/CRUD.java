package Controllers.Data;
import lombok.NonNull;

import java.util.List;

/** Интерфейс CRUD-операций */
public interface CRUD<T> {
    T get(@NonNull Integer id);
    List<T> getAll();
    void save(@NonNull T obj);
    void update(@NonNull T obj);
    void delete(@NonNull Integer id);
}
