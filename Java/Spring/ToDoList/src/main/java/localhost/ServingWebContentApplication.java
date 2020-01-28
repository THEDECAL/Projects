package localhost;

import freemarker.template.TemplateModelException;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

import java.io.IOException;

@SpringBootApplication
@EntityScan("localhost.models")
@EnableJpaRepositories("localhost.repositories")
public class ServingWebContentApplication {
    public static void main(String[] args) throws IOException, TemplateModelException {
        SpringApplication.run(ServingWebContentApplication.class, args);
    }
}