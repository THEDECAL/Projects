package localhost.models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import javax.persistence.*;
import java.util.Collection;
import java.util.HashSet;
import java.util.Set;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "accounts")
public class Account implements UserDetails {
    public enum Role implements GrantedAuthority
    {
        USER("user"),
        ADMIN("admin");

        String value;
        Role(String value){ this.value = value; }
        public String getValue(){ return value; }
        @Override
        public String getAuthority() { return value; }
    }

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    @Column(unique = true, nullable = false)
    private String login;
    @Column(nullable = false)
    private String password;
    @Column(nullable = false)
    private Boolean isEnabled;
    @ElementCollection(targetClass = Role.class, fetch = FetchType.EAGER)
    @CollectionTable(name = "accounts_roles", joinColumns = @JoinColumn(name = "account_id"))
    @Enumerated(EnumType.STRING)
    Set<Role> roles;

    public Account(String login, String password){
        this.login = login;
        this.password = password;
        roles = new HashSet<Role>();
        roles.add(Role.USER);
        isEnabled = true;
    }
    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        return getRoles();
    }
    @Override
    public String getUsername() {
        return login;
    }
    @Override
    public boolean isAccountNonExpired() {
        return true;
    }
    @Override
    public boolean isAccountNonLocked() {
        return true;
    }
    @Override
    public boolean isCredentialsNonExpired() {
        return true;
    }
    @Override
    public boolean isEnabled() {
        return isEnabled;
    }
}
