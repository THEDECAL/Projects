package localhost.configs;

import localhost.services.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.annotation.web.servlet.configuration.EnableWebMvcSecurity;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

import javax.sql.DataSource;

@Configuration
@EnableWebMvcSecurity
public class WebSecurityConfig extends WebSecurityConfigurerAdapter {
    @Autowired
    DataSource dataSource;
    @Autowired
    AccountService accServ;

    @Override
    protected void configure(HttpSecurity http) throws Exception {
        http
                .authorizeRequests()
                .antMatchers("/", "/index", "/regin", "/error", "/content/**", "/img/**").permitAll()
                .anyRequest().authenticated();
        http
                .formLogin().loginPage("/login")
                .usernameParameter("login").passwordParameter("password")
                .permitAll()
                .and()
                .logout().logoutSuccessUrl("/index")
                .permitAll();
    }

    @Override
    protected void configure(AuthenticationManagerBuilder auth) throws Exception{
        auth.userDetailsService(accServ)
                .passwordEncoder(passEnc());
    }

    @Bean
    protected PasswordEncoder passEnc(){ return new BCryptPasswordEncoder(11); }
}
