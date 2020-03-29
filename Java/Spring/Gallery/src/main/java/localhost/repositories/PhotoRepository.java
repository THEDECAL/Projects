package localhost.repositories;

import localhost.models.Account;
import localhost.models.Photo;
import org.springframework.data.repository.CrudRepository;

public interface PhotoRepository extends CrudRepository<Photo, Long>{
    Iterable<Photo> findPhotosByOwner(Account acc);
}
