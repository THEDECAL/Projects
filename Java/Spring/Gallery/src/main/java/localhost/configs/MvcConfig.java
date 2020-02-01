package localhost.configs;

import lombok.var;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

@Configuration
public class MvcConfig extends WebMvcConfigurerAdapter {
    @Value("${upload-relative-path}")
    private String uploadRelativePath;

    @Override
    public void addViewControllers(ViewControllerRegistry registry) {
        registry.addViewController("/login").setViewName("login");
        registry.addViewController("/logout").setViewName("logout");
    }

    @Override
    public void addResourceHandlers(ResourceHandlerRegistry registry){
        registry.addResourceHandler("content/**")
                .addResourceLocations("classpath:/content/");

        var workingDir = System.getProperty("user.dir");
        registry.addResourceHandler("/img/**")
                .addResourceLocations("file:///" +  workingDir + '/' + uploadRelativePath + '/');
    }
}