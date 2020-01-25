package localhost.repositories;
import localhost.models.Account;
import org.springframework.data.repository.CrudRepository;

public interface AccountRepository extends CrudRepository<Account, Long> {
    Account findByLogin(String login);
}
