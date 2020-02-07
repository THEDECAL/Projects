package localhost.services;

import localhost.repositories.AccountRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class AccountService implements UserDetailsService {
    @Autowired
    private AccountRepository accRepo;

    @Override
    public UserDetails loadUserByUsername(String login) throws UsernameNotFoundException {
        return accRepo.findByLogin(login);
    }
}
